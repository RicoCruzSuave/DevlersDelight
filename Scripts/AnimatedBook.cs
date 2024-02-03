using Godot;
using System;

public partial class AnimatedBook : AnimatedSprite2D
{
	[Export] private TextureRect openBook;
	bool buttonPressed = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	public override void _Input(InputEvent @event)
	{
		if(buttonPressed) return;

		if ((@event is InputEventKey keyEvent && keyEvent.Pressed) || (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed))
    	{
			//Any button (mouse or keyboard) was pressed
			//Play Animation and hide yourself
			buttonPressed = true;
			this.GetNode<Label>("Label").Visible = false;
			this.GetNode<Label>("Label2").Visible = false;
			this.Play();
		}
	}

	public void FinishedAnimation()
	{
		openBook.Visible = true;
		this.Visible = false;
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
