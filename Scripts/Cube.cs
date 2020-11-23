using Godot;
using System;

public class Cube : Node
{
    public Spatial cube;
    public Spatial parent; // Spatial node - GameObject?
  //  public PlanetChunk owner;

    public Vector3 cubeLocation;

   // private Material cubeMaterial = CustomMaterials.RetrieveMaterial(CustomMaterials.rockQuad);

    public Vector3[] frontQuadVertices = new Vector3[4];
    public Vector3[] backQuadVertices = new Vector3[4];
    public Vector3[] topQuadVertices = new Vector3[4];
    public Vector3[] bottomQuadVertices = new Vector3[4];
    public Vector3[] leftQuadVertices = new Vector3[4];
    public Vector3[] rightQuadVertices = new Vector3[4];

    public int currentX, currentY, currentZ;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    // Cube contructor
    /*
    public Cube(Spatial parent, PlanetChunk owner,
        int currentX, int currentY, int currentZ,
        Material material, int terrainType,
        Vector3 cubePosition, string chunkName)
    {
        cubeLocation = cubePosition;
        this.parent = parent;
        //   this.owner = owner;
        //   cubePhysicalState = CubePhysicalState.SOLID; // default state
        //   cube = new GameObject(chunkName + "_" + "Cube_" + Universe.BuildPlanetChunkName(cubeLocation));
        //   cube = new Spatial(chunkName + "_" + "Cube_" + "Test");
        cube = new Spatial();
           this.currentX = currentX;
        this.currentY = currentY;
        this.currentZ = currentZ;
    }
    */





    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
