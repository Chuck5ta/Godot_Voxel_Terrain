using Godot;
using System;
/*
 * The Universe class controls the building of the Universe in planets.
 * Each planet is made up of chunks.
 * Each chunk is made up of cubes. 
 * Each cube is made up of quads.
 * And each quad is made up of 2 triangles.
 * 
 *
 */

public class Universe : Spatial
{
    public static Planet planet;

    /*
     * This kicks off the building of a single planet
     */
    void GeneratePlanet()
    {
        planet = new Planet();
        planet.GenerateWorld();
        AddChild(planet); // add planet to universe
    }

    /*
     * This will be used to kick off the building of planets (1 or more)
     * 
     */
    public void BuildUniverse()
    {
        // this will be within a loop to generate x number of planets
        GeneratePlanet();
    }




    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        BuildUniverse();
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
