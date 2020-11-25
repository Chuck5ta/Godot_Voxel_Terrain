using Godot;
using System;

public class Planet : Node
{
    public int planetSize = 5; // number of chunks (e.g. size of 3 means 3x3x3 = 27 chunks in total)
    public int chunkSize = 5; // diameter -  size of chunk in cubes (e.g. size of 10 = 10x10x10 = 1000 cubes in total)
    public int planetRadius = 8; // number of cubes (e.g. size if 12 = radius of 12 and therefore a diameter of 24)
    public float fPlanetCentreXYZValue = 0;
    public Vector3 planetCentre; // X, Y, Z coordinates - calculate this based on the other values : (planetSize * chunkSize) / 2

    // Planet constructor 
    public Planet()
    {
        // build the planet
        GenerateWorld();
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }


    public void GenerateWorld()
    {
        PlanetChunk planetChunk = new PlanetChunk(this); // this is the owner of the chunk
        planetChunk.BuildTheChunk();
        planetChunk.DrawChunk();
        AddChild(planetChunk); // add chunk to the planet
    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
