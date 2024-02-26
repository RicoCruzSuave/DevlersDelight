using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

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

    //Getting references to the Entity Display
    [Export] private Control playerPartyGridContainer, enemyPartyGridContainer;
    public override void _Ready()
    {
        regionLabel.Text = RegionName != null ? RegionName : "Region Title";
        sectionLabel.Text = "[" + (SectionName != null ? SectionName : "Section-1") + "]";
        depthLabel.Text = "Current Depth: " + Depth.ToString("N1") + " m";
    }

    public void AssignPlayerTeam(List<EntityCard> team)
    {
        var control_array = playerPartyGridContainer.GetChildren();
        for (int i = 0; i < team.Count; i++)
        {
            ((UI_EntityCard)control_array[i]).entityCard = team[i];
        }
    }
}
