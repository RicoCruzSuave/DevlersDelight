using Godot;
using System;

public partial class UI_EntityCard : Control
{
    [ExportGroup("Parameters")]
    [Export] public string EntityName { get; set; }
    [Export] public float Health { get; set; }
    [Export] public string AtkStat { get; set; }
    [Export] public float DefStat { get; set; }
    

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
