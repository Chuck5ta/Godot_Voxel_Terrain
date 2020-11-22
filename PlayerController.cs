using Godot;
using System;

public class PlayerController : KinematicBody
{
    // KinematicBody player; // ????????
    public float moveSpeed = 5f;
    public float sensitivity = 1;
    Vector3 euler; // (oiler) used in the calculation for rotating the player character

    private float rotationX = 0f;
    private float rotationY = 0f;
    float LookAroundSpeed = 0.01f;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Initialisation here

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
    }

    /*
     * Move the Player character
     */
    public override void _UnhandledKeyInput(InputEventKey keyEvent)
    {
        base._UnhandledKeyInput(keyEvent);

        if (keyEvent.Scancode == (int)KeyList.W) // Move forwards
        {
            MoveAndSlide(-Transform.basis.z * moveSpeed);
        }
        else if (keyEvent.Scancode == (int)KeyList.S) // Move backwards
        {
            MoveAndSlide(Transform.basis.z * moveSpeed);
        }
        else if (keyEvent.Scancode == (int)KeyList.A) // Move to the left
        {
            MoveAndSlide(-Transform.basis.x * moveSpeed);
        }
        else if (keyEvent.Scancode == (int)KeyList.D) // Move to the right
        {
            MoveAndSlide(Transform.basis.x * moveSpeed);
        }
        else if (keyEvent.Scancode == (int)KeyList.R) // Move upwards
        {
            MoveAndSlide(Transform.basis.y * moveSpeed);
        }
        else if (keyEvent.Scancode == (int)KeyList.F) // Move downwards
        {
            MoveAndSlide(-Transform.basis.y * moveSpeed);
        }
    }

    /*
     * Rotate the Player character
     */
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            // modify accumulated mouse rotation
            rotationX += -mouseMotion.Relative.x * LookAroundSpeed;
            rotationY += -mouseMotion.Relative.y * LookAroundSpeed;

            // reset rotation
            Transform transform = Transform;
            transform.basis = Basis.Identity;
            Transform = transform;

            RotateObjectLocal(Vector3.Up, rotationX); // first rotate about Y
            RotateObjectLocal(Vector3.Right, rotationY); // then rotate about X
        }
    }

    // TODO: DELETE THIS WHEN NO LONGER NEEDED
    public override void _UnhandledInput(InputEvent mouseEvent)
    {
        base._UnhandledInput(mouseEvent);

        // Turning
        if (mouseEvent is InputEventMouseButton eventMouseButton)
        {
            if (eventMouseButton.ButtonIndex == (int)ButtonList.Left)
                GD.Print("Left Mouse");
            else if (eventMouseButton.ButtonIndex == (int)ButtonList.Middle)
                GD.Print("Middle Mouse");
            else if (eventMouseButton.ButtonIndex == (int)ButtonList.Right)
            {
                GD.Print("Right Mouse");
                RotateObjectLocal(Vector3.Right, Mathf.Pi);
            }
        }

    }


    // TODO: DELETE THIS WHEN NO LONGER NEEDED
    public void ChangeDirection()
    {
        // Due to technical limitations on structs in C# the default
        // constructor will contain zero values for all fields.
        var defaultBasis = new Basis();
        GD.Print(defaultBasis); // prints: ((0, 0, 0), (0, 0, 0), (0, 0, 0))

        // Instead we can use the Identity property.
        var identityBasis = Basis.Identity;
        GD.Print(identityBasis.x); // prints: (1, 0, 0)
        GD.Print(identityBasis.y); // prints: (0, 1, 0)
        GD.Print(identityBasis.z); // prints: (0, 0, 1)

        // The Identity basis is equivalent to:
        var basis = new Basis(Vector3.Right, Vector3.Up, Vector3.Back);
        GD.Print(basis); // prints: ((1, 0, 0), (0, 1, 0), (0, 0, 1))


        RotateObjectLocal(Vector3.Right, Mathf.Pi);
    }
}
