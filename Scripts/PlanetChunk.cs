using Godot;
using System;

public class PlanetChunk : Spatial
{
    public Cube[,,] chunkData;
    public Planet planet;
    public string name;

    public Spatial planetChunk;
    public CSGCombiner combiner; // combine all the cubes into the one chunk (seems to be the best way to do this in Godot)

    public Vector3 chunkPosition; // is this used here??????
    public float chunkXIndex, chunkYIndex, chunkZIndex; // chunk location in the world, where 1st chunk is 0,0,0 next chunk along the X axis is 1,0,0 and next is 2,0,0
                                                        // next chunk from 0,0,0 along the Y axis is 0,1,0 and the next is 0,2,0 etc.
                                                        // These are required for calculating which parts of the chunk to draw for the planet

    Color chunkColour;

    public bool[,,] CubeIsSolid; // states if a block/cube is space or a solid 


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }


    /*
     * Constructor
     * parent, is the GameObject of the parent object (planet, in this case)
     * owner, is the owner class (Planet, in this case)
     * position is the location of the chunk we are currently working on
     * material, is the material that will cover the chunk - TODO: make it so that there is a material for each cube/quad
     * 
     * e.g. chunk 0 will be based at 0,0,0 in the Universe
     */
    public PlanetChunk(Planet owner, Vector3 chunkPosition, Color chunkColour, float chunkXIndex, float chunkYIndex, float chunkZIndex)
    {
        planetChunk = new Spatial();
        name = "Chunk_" + Universe.BuildPlanetChunkName(chunkXIndex, chunkYIndex, chunkZIndex);

        combiner = new CSGCombiner();

        planet = owner; // the planet this chunk is part of (child of) TODO: IS THIS NEEDED??? I do no think so


        this.chunkPosition = chunkPosition;

        this.chunkXIndex = chunkXIndex;
        this.chunkYIndex = chunkYIndex;
        this.chunkZIndex = chunkZIndex;

        this.chunkColour = chunkColour;

        chunkData = new Cube[planet.chunkSize, planet.chunkSize, planet.chunkSize];
        CubeIsSolid = new bool[owner.chunkSize, owner.chunkSize, owner.chunkSize];

    }

    public PlanetChunk() // TODO: is this needed?????
    {
    }

    /*
     * Generate the planet, but do not draw the cubes at this point.
     * We need generate first, so that we can see where quads need not be
     * drawn, due to being next to a cube that is or will be drawn during
     * the initial generation of the planet.
     */
    public void BuildTheChunk()
    {
        for (int y = 0; y < planet.chunkSize; y++)
        {
            for (int z = 0; z < planet.chunkSize; z++)
            {
                for (int x = 0; x < planet.chunkSize; x++)
                {
                    // generate cube - solid or space/air?
              //      Vector3 cubePosition = new Vector3(Translation.x + x,
              //                                          Translation.y + y,
              //                                          Translation.z + z);

                    Vector3 cubePosition = new Vector3(x, y, z);

                    chunkColour = planet.GetNextColor();

                    chunkData[x, y, z] = new Cube(this, cubePosition, chunkColour);

                    AddChild(chunkData[x, y, z].cube);

                    // create new cube
                    if (IsOuterLayer(cubePosition))
                    {
                        CubeIsSolid[x, y, z] = true;
                    }
                    else // set cube to SPACE
                    {
                        CubeIsSolid[x, y, z] = false;
                    } 

                }
            }
        }

    }


    /*
     * Draw the cubes that are on the surface of the planet.
     * Cubes within the planet will be drawn as and when digging/terrain 
     * manipulation occurs.
     */
    public void DrawChunk()
    {
        // DRAW THE CHUNK
        for (int y = 0; y < planet.chunkSize; y++)
        {
            for (int z = 0; z < planet.chunkSize; z++)
            {
                for (int x = 0; x < planet.chunkSize; x++)
                {
                    // display cubes that are set to SOLID (surface area cubes only)
                    if (CubeIsSolid[x, y, z])
                    {
                        // draw the cube and set it to SOLID
                        chunkData[x, y, z].DrawCube();
                    }
                }
            }
        }

    }

    /*
     * Tests to see if the cube is part of the outer layer of the planet. If so
     * then we want to have it visible.
     * If the cube is not on the outer layer, then it is set to SPACE and is invisible
     */
    private bool IsOuterLayer(Vector3 cubePosition)
    {
        // d is the distance from the cube's location to the centre of the planet
        // d = ((x2 - x1)^2 + (y2 - y1)^2 + (z2 - z1)^2)^1/2  
        float d = Mathf.Sqrt(((cubePosition.x + chunkXIndex * planet.chunkSize - planet.planetCentre.x) * (cubePosition.x + chunkXIndex * planet.chunkSize - planet.planetCentre.x)) +
                              ((cubePosition.y + chunkYIndex * planet.chunkSize - planet.planetCentre.y) * (cubePosition.y + chunkYIndex * planet.chunkSize - planet.planetCentre.y)) +
                              ((cubePosition.z + chunkZIndex * planet.chunkSize - planet.planetCentre.z) * (cubePosition.z + chunkZIndex * planet.chunkSize - planet.planetCentre.z))
                            );

        //   Debug.Log("D is " + d + " : " + "Planet radius: " + owner.planetRadius + " - centre: " + owner.planetCentre);
        //   Debug.Log("Chunk size is " + owner.chunkSize);
        //   Debug.Log("Chunk position is " + chunkPosition);
        //   Debug.Log("Cube position is " + cubePosition);

        if (d < planet.planetRadius && planet.planetRadius - d < 2) // ensures that only the surface cubes are generated
            return true;

        return false;
    }

}
