using Godot;
using System;

public partial class PlayScreenUI : Control
{
    [ExportGroup("Parameters")]
    [Export] public string RegionName { get; set; }
    [Export] public string SectionName { get; set; }
    [Export] public float Depth { get; set; }
    [Export] public float SecondsTillFinish { get; set; }

    [ExportGroup("Dependencies")]
    [Export] private Label regionLabel, sectionLabel, depthLabel;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        regionLabel.Text = RegionName != null ? RegionName : "Region Title";
        sectionLabel.Text = "[" + (SectionName != null ? SectionName : "Section-1") + "]";
        depthLabel.Text = "Current Depth: " + Depth.ToString("N1") + " m";
	}

}
