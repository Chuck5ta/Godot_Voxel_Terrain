using Godot;
using System;

public class CustomMaterials : Node
{
    // Required so that the material set in the inspector is accessible from other classes
    private static SpatialMaterial[] material;

    // grass 0, dirt 1, sand 2, rock 4 - bitflags and bitwise operations ??????
    public static int grassQuad = 0;
    public static int dirtQuad = 1;
    public static int sandQuad = 2;
    public static int rockQuad = 3;

    /*
     * CustomMaterials contrustor
     */
    public CustomMaterials()
    {
        // Load all materials
        InitiliseMaterials();
    }

    private void LoadMaterials(int materialIndex, string pathToMaterial)
    {
        ImageTexture imageTexture = new ImageTexture();

        Image image = (Image)GD.Load(pathToMaterial);

        imageTexture.CreateFromImage(image);

        // Set the material
        SpatialMaterial newMaterial = new SpatialMaterial();
        newMaterial.AlbedoTexture = imageTexture;

        material[materialIndex] = newMaterial;
    }

    private void InitiliseMaterials()
    {
        // load the materials
        material = new SpatialMaterial[16];

        // Load grass
        LoadMaterials(grassQuad, "res://Textures/seamless-grass-texture.jpg");
        // Load dirt
        LoadMaterials(dirtQuad, "res://Textures/dirt.png");
        // Load sand
        LoadMaterials(sandQuad, "res://Textures/Seamlesssand.jpg");
        // Load rock
        LoadMaterials(rockQuad, "res://Textures/SeamlessRock.jpg");

    }

    public SpatialMaterial RetrieveMaterial(int materialIndex)
    {
        return material[materialIndex];
    }
}
