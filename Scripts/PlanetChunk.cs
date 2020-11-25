using Godot;
using System;

public class PlanetChunk : Node
{
    public Cube[,,] chunkData;


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
    public PlanetChunk()
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
        GD.Print("Game cs - Starting");
        chunkData = new Cube[4, 4, 4];
        chunkData[0, 0, 0] = new Cube(new Vector3(0, 0, 0), new Color(1, 0, 0, 1));
        chunkData[1, 0, 0] = new Cube(new Vector3(1, 0, 0), new Color(0, 1, 0, 1));
        GD.Print("Game cs - calling Drawing cube");

        chunkData[0, 0, 0].DrawCube();
        chunkData[1, 0, 0].DrawCube();

        AddChild(chunkData[0, 0, 0]); // place cube to chunk
        AddChild(chunkData[1, 0, 0]); // place cube to chunk
    }

}
