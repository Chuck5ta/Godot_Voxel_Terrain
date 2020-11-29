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

public class Universe : Node
{
    public static Planet planet;

    public static string BuildPlanetChunkName(Vector3 position) // for a 3D terrain
    {
        return (int)position.x + "_" +   // leave this, as we may need to implement a cubish world, instead of the quad one we have
                (int)position.y + "_" +
                (int)position.z;
    }

    public static string BuildPlanetChunkName(float X, float Y, float Z) // for a 3D terrain
    {
        return (int)X + "_" +   // leave this, as we may need to implement a cubish world, instead of the quad one we have
                (int)Y + "_" +
                (int)Z;
    }

    /*
     * This kicks off the building of a single planet
     */
    void GeneratePlanet()
    {
        planet = new Planet();
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
