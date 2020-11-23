using Godot;
using System;
using System.Collections;

public class Game : Spatial
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";


   // Called when the node enters the scene tree for the first time.
   public override void _Ready()
    {
        //   GD.Print("hello");
        //BuildWorld();

        // Generate triangle mesh

        // 1st location in the array (0)
        Vector3[] vertices = { new Vector3(0, 1, 0),
                               new Vector3(0, 1, 1),
                               new Vector3(1, 1, 0),
                               new Vector3(1, 1, 1) };

        int[] index = new int[6] { 0, 1, 2, 3, 2, 1 };

        // UVs
        Vector2[] uvs = { new Vector2(0f, 1f),   //top-left
                          new Vector2(1f, 1f),   //top-right
                          new Vector2(0f, 0f),   //bottom-left
                          new Vector2(1f, 0f) }; //bottom-right

        // Normals
        Vector3[] normals = new Vector3[4] { Vector3.Up, Vector3.Up, Vector3.Up, Vector3.Up };



        // 4th location in the array (3)
     //      Color[] colors = { new Color(1, 1, 1, 1), // blue
     //                          new Color(1, 1, 1, 1),
     //                          new Color(1, 1, 1, 1),
     //                          new Color(1, 1, 1, 1) }; 

        //    var[] arrays;

        Godot.Collections.Array arrays = new Godot.Collections.Array();
        arrays.Resize(9);
        //    arrays.Resize((int)ArrayMesh.ArrayType.Max);
        arrays[0] = vertices;
        arrays[1] = normals;
     //   arrays[3] = colors;
        arrays[4] = uvs;
        arrays[8] = index;

        //  arrays[ArrayMesh.ArrayType.Vertex] = vertices;
        // Create the Mesh.     

        // Initialize the ArrayMesh.
        ArrayMesh arr_mesh = new ArrayMesh();
        
        arr_mesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, arrays);
        MeshInstance quad = new MeshInstance();
        quad.Mesh = arr_mesh;

        AddChild(quad); // make the mesh a chils of the Game node

      //  GenMesh();
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
