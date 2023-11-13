using Godot;
using System;

public partial class Entity : CharacterBody2D
{
    [ExportGroup("Stats")]
    [Export]
    private int HP;
    [Export]
    private int attack;
    [Export]
    private int defense;
}
