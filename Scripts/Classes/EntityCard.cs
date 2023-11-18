using Godot;
using System;

public partial class EntityCard : Resource
{
    [ExportGroup("Stats")]
    [Export]
    public int MaxHP = 100;
    [Export]
    public int Attack = 10;
    [Export]
    public int Defense = 10;

    [ExportGroup("Visuals")]
    [Export]
    public Texture2D Texture;
    [Export]
    public Color Color = new Color(1.0F, 1.0F, 1.0F);

}
