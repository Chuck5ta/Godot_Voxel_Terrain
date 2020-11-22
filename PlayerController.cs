using Godot;
using System;

public class PlayerController : KinematicBody
{
    // KinematicBody player; // ????????
    public float moveSpeed = 5f;
    // Vector3 euler; // (oiler) used in the calculation for rotating the player character
    float turningSpeed = 0.01f;
    private float rotationX = 0f;
    private float rotationY = 0f;


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
        
        // Move forwards
        if (keyEvent.Scancode == (int)KeyList.W) 
        {
            MoveAndSlide(-Transform.basis.z * moveSpeed);
        }
        // Move backwards
        else if (keyEvent.Scancode == (int)KeyList.S) 
        {
            MoveAndSlide(Transform.basis.z * moveSpeed);
        }
        // Move to the left
        else if (keyEvent.Scancode == (int)KeyList.A) 
        {
            MoveAndSlide(-Transform.basis.x * moveSpeed);
        }
        // Move to the right
        else if (keyEvent.Scancode == (int)KeyList.D) 
        {
            MoveAndSlide(Transform.basis.x * moveSpeed);
        }
        // Move upwards
        else if (keyEvent.Scancode == (int)KeyList.R) 
        {
            MoveAndSlide(Transform.basis.y * moveSpeed);
        }
        // Move downwards
        else if (keyEvent.Scancode == (int)KeyList.F) 
        {
            MoveAndSlide(-Transform.basis.y * moveSpeed);
        }
    }

    /*
     * Rotate/turn the Player character
     * This only requires the mouse to move, not for a button to be pressed
     */
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            // modify accumulated mouse rotation
            rotationX += -mouseMotion.Relative.x * turningSpeed;
            rotationY += -mouseMotion.Relative.y * turningSpeed;

            // reset rotation
            Transform transform = Transform;
            transform.basis = Basis.Identity;
            Transform = transform;

            RotateObjectLocal(Vector3.Up, rotationX); // first rotate about Y
            RotateObjectLocal(Vector3.Right, rotationY); // then rotate about X
        }
    }

    // TODO: Use this for manipulating the terrain (digging/building)
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
}
