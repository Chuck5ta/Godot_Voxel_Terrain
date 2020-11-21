using Godot;
using System;

public class PlayerController : KinematicBody
{
    // KinematicBody player; // ????????
    public float moveSpeed = 5f;
    public float sensitivity = 1;
    Vector3 euler; // (oiler) used in the calculation for rotating the player character

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Initialisation here

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
    }

    public override void _UnhandledKeyInput(InputEventKey keyEvent)
    {
        base._UnhandledKeyInput(keyEvent);

        if (keyEvent.Scancode == (int)KeyList.W) // Move forwards
        {
        //    GD.Print("Moving forwards");
        //    this.GlobalTranslate(new Vector3(0,0,-0.1f));
            this.MoveAndSlide(Vector3.Forward * moveSpeed);
        }
        else if (keyEvent.Scancode == (int)KeyList.S) // Move backwards
        {
            this.MoveAndSlide(-Vector3.Forward * moveSpeed);
        }
        else if (keyEvent.Scancode == (int)KeyList.A) // Move to the left
        {
            this.MoveAndSlide(Vector3.Left * moveSpeed);
        }
        else if (keyEvent.Scancode == (int)KeyList.D) // Move to the right
        {
            this.MoveAndSlide(Vector3.Right * moveSpeed);
        }
        else if (keyEvent.Scancode == (int)KeyList.R) // Move upwards
        {
            this.MoveAndSlide(Vector3.Up * moveSpeed);
        }
        else if (keyEvent.Scancode == (int)KeyList.F) // Move downwards
        {
            this.MoveAndSlide(Vector3.Down * moveSpeed);
        }
    }


    public void ChangeDirection()
    {

    }
}
