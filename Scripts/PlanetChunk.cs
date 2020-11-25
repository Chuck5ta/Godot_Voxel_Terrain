using Godot;
using System;

public class PlanetChunk : Spatial
{
    public Cube[,,] chunkData;
    public Planet planet;

    public Node planetChunk;


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
    public PlanetChunk(Planet owner)
    {
        planet = owner;
        chunkData = new Cube[planet.chunkSize, planet.chunkSize, planet.chunkSize];

        //planetChunk = new Node();
        
    }

    /*
     * Generate the planet, but do not draw the cubes at this point.
     * We need generate first, so that we can see where quads need not be
     * drawn, due to being next to a cube that is or will be drawn during
     * the initial generation of the planet.
     */
    public void BuildTheChunk()
    {
        float red;
        float green;
        float blue;
        Random rnd = new Random();
        for (int y = 0; y < planet.chunkSize; y++)
        {
            for (int z = 0; z < planet.chunkSize; z++)
            {
                for (int x = 0; x < planet.chunkSize; x++)
                {
                    // generate cube - solid or space/air?
                    Vector3 cubePosition = new Vector3(Translation.x + x,
                                                        Translation.y + y,
                                                        Translation.z + z);

                    //         Debug.Log(" CHUNK NAME : " + planetChunk.name);
                    red = rnd.Next(0, 2);
                    green = rnd.Next(0, 2);
                    blue = rnd.Next(0, 2);
                    chunkData[x, y, z] = new Cube(this, cubePosition, new Color(red, green, blue, 1));

                    AddChild(chunkData[x, y, z]); // make the cube a child of the chunk
                    // create new cube
        /*            if (IsOuterLayer(cubePosition))
                    {
                        CubeIsSolid[x, y, z] = true;
                    }
                    else // set cube to SPACE
                    {
                        CubeIsSolid[x, y, z] = false;
                    } */

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
                    //       if (CubeIsSolid[x, y, z])
                    //       {
                    // draw the cube and set it to SOLID
                    chunkData[x, y, z].DrawCube();
                    //       }
                    //   }
                }
            }
            //      CombineCubes();
            //      MeshCollider collider = planetChunk.gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
            //      collider.sharedMesh = planetChunk.transform.GetComponent<MeshFilter>().mesh;
        }

    }

}
