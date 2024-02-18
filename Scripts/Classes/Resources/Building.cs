using Godot;
using System;

public partial class Building : Resource
{
    [Export] public string BuildingName {get;set;}
    [Export] public int PopulationSpace = 0;

    [Export] public GlobalStuff.BuildingTypes Type;
}
