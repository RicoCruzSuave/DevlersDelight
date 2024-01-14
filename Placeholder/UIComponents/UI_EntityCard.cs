using Godot;
using System;

public partial class UI_EntityCard : Control
{
    [ExportGroup("Parameters")]
    [Export] private Entity entity;

    [ExportGroup("Dependencies")]
    [Export] private Label nameLabel, atkLabel, defLabel;
    [Export] private TextureProgressBar healthbar;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
