using Godot;
using System;

public partial class Entity : CharacterBody2D
{
    [ExportGroup("Battle Stats")]
    [Export]
    private EntityCard Card;
    [Export]
    private Resource[] StatModifiers;

    public int CurrentHP;
    public int CurrentAttack;
    public int CurrentDefense;
    public Sprite2D Sprite;
    public AnimationPlayer Animation;

    public override void _Ready()
    {
        Animation = GetNode<AnimationPlayer>("AnimationPlayer");
        Sprite = GetNode<Sprite2D>("Sprite2D");
        Sprite.Texture = Card.Texture;
        Sprite.SelfModulate = Card.Color;

        CurrentHP = Card.MaxHP;
        CurrentAttack = Card.Attack;
        CurrentDefense = Card.Defense;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        CheckForDeath();
    }

    public async void Attack(Entity Target)
    {
        Animation.Play("Attack");
        await ToSignal(Animation, AnimationPlayer.SignalName.AnimationFinished);
        Animation.PlayBackwards("Attack");
        await ToSignal(Animation, AnimationPlayer.SignalName.AnimationFinished);
        Target.CurrentHP -= CurrentAttack - Target.CurrentDefense;
    }

    public async void CheckForDeath()
    {
        if (CurrentHP <= 0)
        {
            Animation.Play("Die");
            await ToSignal(Animation, AnimationPlayer.SignalName.AnimationFinished);
            Free();
        }
    }
}
