using Godot;
using System;

public class PlayerController : KinematicBody
{
    // KinematicBody player; // ????????
    public float moveSpeed = 5f;
    // Vector3 euler; // (oiler) used in the calculation for rotating the player character
    float turningSpeed = 0.01f;
    float rotationSpeed = 0.05f;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Initialisation here

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
 //   public override void _Process(float delta)
 //   {
 //   }


    /*
     * Rotate/turn the Player character
     * This only requires the mouse to move, not for a button to be pressed
     */
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            float horizontalMovement = turningSpeed * mouseMotion.Relative.x;
            float verticalMovement = turningSpeed * mouseMotion.Relative.y;
            RotateObjectLocal(Vector3.Up, -horizontalMovement); // first rotate about Y
            RotateObjectLocal(Vector3.Right, -verticalMovement); // then rotate about X
            // TODO: left and right turning is a little odd - tends to lean
        }

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
        // Turn anticlockwise
        else if (keyEvent.Scancode == (int)KeyList.Q)
        {
            RotateObjectLocal(Vector3.Back, rotationSpeed);
        }
        // Turn clockwise
        else if (keyEvent.Scancode == (int)KeyList.E)
        {
            RotateObjectLocal(Vector3.Forward, rotationSpeed);
        }
    }


    // TODO: Use this for manipulating the terrain (digging/building)
    public override void _UnhandledInput(InputEvent mouseEvent)
    {
        base._UnhandledInput(mouseEvent);

        if (mouseEvent is InputEventMouseButton eventMouseButton)
        {
            /*
            if (eventMouseButton.ButtonIndex == (int)ButtonList.Left)
                GD.Print("Left Mouse");
            else if (eventMouseButton.ButtonIndex == (int)ButtonList.Middle)
                GD.Print("Middle Mouse");
            else if (eventMouseButton.ButtonIndex == (int)ButtonList.Right)
            {
                GD.Print("Right Mouse");
           //    RotateObjectLocal(Vector3.Right, Mathf.Pi);
            }
            */
        }

    }
}
