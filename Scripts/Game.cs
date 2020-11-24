using Godot;
using System;
using System.Collections;

public class Game : Spatial
{
    public Cube[,,] chunkData;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("Game cs - Starting");
        chunkData = new Cube[4, 4, 4];
        chunkData[0, 0, 0] = new Cube();
        GD.Print("Game cs - calling Drawing cube");
        chunkData[0, 0, 0].DrawCube();
     //   chunkData[0, 0, 0].CreateQuad();

        AddChild(chunkData[0, 0, 0]); // place cube into the world
    }

    void GenMesh()
    {
        MeshInstance newMesh = new MeshInstance();
        newMesh.Mesh = new CubeMesh();

        this.AddChild(newMesh);

    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }



    public void GeneratePlanetWorld()
    {
        // TEST - create a cube

    }


    IEnumerator BuildWorld()
    {
        // GenerateFlatWorld();
        GeneratePlanetWorld();

        yield return null;

    }



}
