using Godot;
using System;

public partial class Entity : CharacterBody2D
{
    [ExportGroup("Battle Stats")]
    [Export]
    public EntityCard Card;
    [Export]
    private Resource[] StatModifiers;
    [Export]
    private bool IsFacingRight = true;

    public int CurrentHP;
    public int CurrentAttack;
    public int CurrentDefense;
    public int CurrentDexterity;
    public Sprite2D Sprite;
    public AnimatedSprite2D animatedSprite;
    public AnimationPlayer Animation;

    public override void _Ready()
    {
        Animation = GetNode<AnimationPlayer>("AnimationPlayer");
        //Sprite = GetNode<Sprite2D>("Sprite2D");
        //Sprite.Texture = Card.Texture;
        //Sprite.SelfModulate = Card.Color;
        animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        animatedSprite.Play("idle");

        CurrentHP = Card.MaxHP;
        CurrentAttack = Card.Attack;
        CurrentDefense = Card.Defense;
        CurrentDexterity = Card.Dexterity;

        Label DexLabel = GetNode<Label>("Label");
        DexLabel.Text = CurrentDexterity.ToString();
        if (!IsFacingRight)
        {
            var LabelScale = DexLabel.Scale;
            LabelScale.X = -1;
            DexLabel.Scale = LabelScale;
            ProgressBar HealthBar = GetNode<ProgressBar>("ProgressBar");
            var HealthBarScale = HealthBar.Scale;
            HealthBarScale.X = 1;
            HealthBar.Scale = HealthBarScale;
        }
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        ProgressBar HealthBar = GetNode<ProgressBar>("ProgressBar");
        HealthBar.Value = (float)CurrentHP / (float)Card.MaxHP;
    }
    public void Run()
    {
        animatedSprite.Play("run");
    }
    public void Idle()
    {
        animatedSprite.Play("idle");
    }
    public async void Attack(Entity Target)
    {
        if (CheckForDeath()) { return; }
        Animation.Play("Attack");
        await ToSignal(Animation, AnimationPlayer.SignalName.AnimationFinished);
        Animation.PlayBackwards("Attack");
        await ToSignal(Animation, AnimationPlayer.SignalName.AnimationFinished);
        Target.Hit(this.CurrentAttack);
    }

    public void Hit(int Damage)
    {
        CurrentHP -= Damage - CurrentDefense;
        CheckForDeath();
    }

    public bool CheckForDeath()
    {
        if (CurrentHP <= 0)
        {
            Animation.Stop();
            Animation.Play("Die");
            Animation.AnimationFinished += (_anim_name) => Free();
            return true;
        }
        return false;
    }
}
