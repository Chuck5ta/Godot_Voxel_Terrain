using Godot;
using System;

public class Cube : Node
{
    public Node cube;

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

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }

    // Cube contructor
    public Cube()
    {
        GD.Print("Cube constructor");
        //    cubeLocation = cubePosition;
        cube = new Node();
    //    this.currentX = currentX;
    //    this.currentY = currentY;
    //    this.currentZ = currentZ;
    }

    public void CreateQuad(Vector3 vertex0, Vector3 vertex1, Vector3 vertex2, Vector3 vertex3)
    {
        GD.Print("Creating quad");
        // Generate quad mesh (2 triangles)

        Vector3[] vertices = { vertex0,   //top-left
                               vertex1,   //top-right
                               vertex2,   //bottom-left
                               vertex3 }; //bottom-right

        int[] index = new int[6] { 0, 1, 2, 3, 2, 1 };

        // UVs
        Vector2[] uvs = { new Vector2(0f, 1f),   //top-left
                          new Vector2(1f, 1f),   //top-right
                          new Vector2(0f, 0f),   //bottom-left
                          new Vector2(1f, 0f) }; //bottom-right

        // Normals
        Vector3[] normals = new Vector3[4]
            { Vector3.Up, Vector3.Up, Vector3.Up, Vector3.Up };
        
        Godot.Collections.Array arrays = new Godot.Collections.Array();
        arrays.Resize(9);

        arrays[0] = vertices;
        arrays[1] = normals;
        arrays[4] = uvs;
        arrays[8] = index;

        // Create the Mesh.     

        // Initialize the ArrayMesh.
        ArrayMesh arr_mesh = new ArrayMesh();

        arr_mesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, arrays);
        MeshInstance quad = new MeshInstance();
        quad.Mesh = arr_mesh;

        // Set the material and colour
        SpatialMaterial newMaterial = new SpatialMaterial();
        newMaterial.AlbedoColor = new Color(1, 0, 0, 1); // red
        quad.MaterialOverride = newMaterial;

        AddChild(quad); // add quad to the cube node (makes it visible?)
        GD.Print("Creating quad completed");
    }
    public void DrawCube()
    {
        GD.Print("Drawing cube sides");
        // if neighbouring cube is SPACE, then draw the quad
        //     if (!HasSolidNeighbour(currentX, currentY, currentZ - 1))
        GenerateFrontQuad();
   //     if (!HasSolidNeighbour(currentX, currentY + 1, currentZ))
            GenerateTopQuad();
   //     if (!HasSolidNeighbour(currentX, currentY - 1, currentZ))
            GenerateBottomQuad();
   //     if (!HasSolidNeighbour(currentX, currentY, currentZ + 1))
            GenerateBackQuad();
   //     if (!HasSolidNeighbour(currentX - 1, currentY, currentZ))
            GenerateLeftQuad();
   //     if (!HasSolidNeighbour(currentX + 1, currentY, currentZ))
            GenerateRightQuad();
    }

    public void GenerateFrontQuad()
    {
        // Front quad
        frontQuadVertices[0] = new Vector3(cubeLocation.x, cubeLocation.y, cubeLocation.z);
        frontQuadVertices[1] = new Vector3(cubeLocation.x, cubeLocation.y + 1, cubeLocation.z);
        frontQuadVertices[2] = new Vector3(cubeLocation.x + 1, cubeLocation.y, cubeLocation.z);
        frontQuadVertices[3] = new Vector3(cubeLocation.x + 1, cubeLocation.y + 1, cubeLocation.z);

        DisplayQuad(frontQuadVertices);
    }
    void GenerateTopQuad()
    {
        // Top quad
        topQuadVertices[0] = new Vector3(cubeLocation.x, cubeLocation.y + 1, cubeLocation.z);
        topQuadVertices[1] = new Vector3(cubeLocation.x, cubeLocation.y + 1, cubeLocation.z + 1);
        topQuadVertices[2] = new Vector3(cubeLocation.x + 1, cubeLocation.y + 1, cubeLocation.z);
        topQuadVertices[3] = new Vector3(cubeLocation.x + 1, cubeLocation.y + 1, cubeLocation.z + 1);

        DisplayQuad(topQuadVertices);
    }
    void GenerateBottomQuad()
    {
        // Bottom quad
        bottomQuadVertices[0] = new Vector3(cubeLocation.x + 1, cubeLocation.y, cubeLocation.z);
        bottomQuadVertices[1] = new Vector3(cubeLocation.x + 1, cubeLocation.y, cubeLocation.z + 1);
        bottomQuadVertices[2] = new Vector3(cubeLocation.x, cubeLocation.y, cubeLocation.z);
        bottomQuadVertices[3] = new Vector3(cubeLocation.x, cubeLocation.y, cubeLocation.z + 1);

        DisplayQuad(bottomQuadVertices);
    }
    void GenerateBackQuad()
    {
        // Back quad
        backQuadVertices[0] = new Vector3(cubeLocation.x + 1, cubeLocation.y, cubeLocation.z + 1);
        backQuadVertices[1] = new Vector3(cubeLocation.x + 1, cubeLocation.y + 1, cubeLocation.z + 1);
        backQuadVertices[2] = new Vector3(cubeLocation.x, cubeLocation.y, cubeLocation.z + 1);
        backQuadVertices[3] = new Vector3(cubeLocation.x, cubeLocation.y + 1, cubeLocation.z + 1);

        DisplayQuad(backQuadVertices);
    }
    void GenerateLeftQuad()
    {
        // Left quad
        leftQuadVertices[0] = new Vector3(cubeLocation.x, cubeLocation.y, cubeLocation.z + 1);
        leftQuadVertices[1] = new Vector3(cubeLocation.x, cubeLocation.y + 1, cubeLocation.z + 1);
        leftQuadVertices[2] = new Vector3(cubeLocation.x, cubeLocation.y, cubeLocation.z);
        leftQuadVertices[3] = new Vector3(cubeLocation.x, cubeLocation.y + 1, cubeLocation.z);

        DisplayQuad(leftQuadVertices);
    }
    void GenerateRightQuad()
    {
        // Right quad
        rightQuadVertices[0] = new Vector3(cubeLocation.x + 1, cubeLocation.y, cubeLocation.z);
        rightQuadVertices[1] = new Vector3(cubeLocation.x + 1, cubeLocation.y + 1, cubeLocation.z);
        rightQuadVertices[2] = new Vector3(cubeLocation.x + 1, cubeLocation.y, cubeLocation.z + 1);
        rightQuadVertices[3] = new Vector3(cubeLocation.x + 1, cubeLocation.y + 1, cubeLocation.z + 1);

        DisplayQuad(rightQuadVertices);
    }

    public void DisplayQuad(Vector3[] quadVertices)
    {
        GD.Print("DisplayQuad");
        CreateQuad(quadVertices[0], quadVertices[1], quadVertices[2], quadVertices[3]); // TODO: need to name the quad!!!
    }

}
