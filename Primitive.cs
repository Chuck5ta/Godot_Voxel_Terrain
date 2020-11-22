using Godot;
using System;

public class Primitive : MeshInstance
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    void generateTriangle()
    {
     //   GD.Print("TRIANGLE??");
        // Generate triangle mesh
        Vector3[] vertices = { new Vector3(0f, 1f, 0f),
                                new Vector3(1f, 0f, 0f),
                                new Vector3(0f, 0f, 1f) };

        // Initialize the ArrayMesh.
        ArrayMesh arr_mesh = new ArrayMesh();

        //    var[] arrays;

        Godot.Collections.Array arrays = new Godot.Collections.Array();
        // arrays.resize(ArrayMesh.ARRAY_MAX)
        //   arrays.Resize(ArrayMesh)
        //    arrays[ArrayMesh.ARRAY_VERTEX] = vertices
        arrays.Add(vertices);
        // Create the Mesh.                
        arr_mesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, arrays);
        MeshInstance m = new MeshInstance();
        m.Mesh = arr_mesh;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
