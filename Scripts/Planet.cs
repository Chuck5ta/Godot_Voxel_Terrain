using Godot;
using System;

public class Planet : Node
{

    // Planet constructor 
    public Planet()
    {
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }


    public void GenerateWorld()
    {
        PlanetChunk planetChunk = new PlanetChunk();
        planetChunk.BuildTheChunk();
        AddChild(planetChunk); // add chunk to the planet
    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
