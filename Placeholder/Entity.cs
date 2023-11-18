using Godot;
using System;

public partial class Entity : CharacterBody2D
{
    [ExportGroup("Battle Stats")]
    [Export]
    private EntityCard Card;
    [Export]
    private Resource[] StatModifiers;

    private int CurrentHP;
    private int CurrentAttack;
    private int CurrentDefense;
    private Sprite2D Sprite;

    public override void _Ready()
    {
        Sprite = GetNode<Sprite2D>("Sprite2D");
        Sprite.Texture = Card.Texture;
        Sprite.SelfModulate = Card.Color;

        CurrentHP = Card.MaxHP;
        CurrentAttack = Card.Attack;
        CurrentDefense = Card.Defense;
    }
}
