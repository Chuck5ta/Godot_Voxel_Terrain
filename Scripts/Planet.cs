using Godot;
using System;
using System.Collections.Generic; // Dictionary structure

public class Planet : Spatial
{
    public int planetSize = 4; // number of chunks (e.g. size of 3 means 3x3x3 = 27 chunks in total)
    public int chunkSize = 2; // diameter -  size of chunk in cubes (e.g. size of 10 = 10x10x10 = 1000 cubes in total)
    public int planetRadius = 6; // number of cubes (e.g. size if 12 = radius of 12 and therefore a diameter of 24)
    public float fPlanetCentreXYZValue = 0;
    public Vector3 planetCentre; // X, Y, Z coordinates - calculate this based on the other values : (planetSize * chunkSize) / 2

    public Dictionary<string, PlanetChunk> planetChunks;

    Color red = new Color(1,0,0,1);
    Color green = new Color(0, 1, 0, 1);
    Color blue = new Color(0, 0, 1, 1);
    Color brown = new Color(1, 0, 1, 1);
    Color purple = new Color(1, 1, 0, 1);
    Color black = new Color(0, 0, 0, 1);
    Color white = new Color(1, 1, 1, 1);
    int previousColour = 99;


    // Planet constructor 
    public Planet()
    {
        fPlanetCentreXYZValue = planetSize * chunkSize / 2;
        planetCentre = new Vector3(fPlanetCentreXYZValue, fPlanetCentreXYZValue, fPlanetCentreXYZValue);

        planetChunks = new Dictionary<string, PlanetChunk>();

        // build the planet
        GeneratePlanet();
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }


    /*
     * This is used to give the chunks each a different material.
     * TODO: Delete this when no longer requred - when everything works
     */
    public Color GetNextColor()
    {
        int pickColour = 1;
        Random rnd = new Random();
        {
            pickColour = rnd.Next(0, 8);
        } while (pickColour == previousColour) ; // stop it picking the same colour in a row
        switch (pickColour)
        {
            case 1:
                return red;
            case 2:
                return green;
            case 3:
                return blue;
            case 4:
                return brown;
            case 5:
                return purple;
            case 6:
                return black;
            case 7:
                return white;
            default:
                return brown;
        }
    }


    public void GeneratePlanet()
    {
        int cubeCount = 1;
        for (int chunkYIndex = 0; chunkYIndex < planetSize; chunkYIndex++)
        {
            for (int chunkZIndex = 0; chunkZIndex < planetSize; chunkZIndex++)
            {
                for (int chunkXIndex = 0; chunkXIndex < planetSize; chunkXIndex++)
                {
                    Vector3 chunkPosition = new Vector3(Translation.x + (chunkXIndex * chunkSize),
                                                        Translation.y + (chunkYIndex * chunkSize),
                                                        Translation.z + (chunkZIndex * chunkSize));

                    // THREADING http://www.albahari.com/threading/
             //       chunkMaterial = GetNextMaterial(cubeCount);

                    PlanetChunk planetChunk = new PlanetChunk(this, 
                        chunkPosition, GetNextColor(), chunkXIndex, chunkYIndex, chunkZIndex); // CHANGE THIS!!! include parameter stating biome (desert, jungle, etc.)

                    planetChunks.Add(planetChunk.name, planetChunk);

                    planetChunk.BuildTheChunk();
                    planetChunk.DrawChunk();
                    AddChild(planetChunk); // add chunk to the planet

             //     planetChunk.Translate(new Vector3(20, 20, 20));
                    planetChunk.GlobalTranslate(new Vector3(chunkXIndex * chunkSize, chunkYIndex * chunkSize, chunkZIndex * chunkSize));

                    cubeCount++;
                    if (cubeCount > 3)
                        cubeCount = 1;
                }
            }
        }

    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
