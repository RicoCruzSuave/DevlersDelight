using Godot;
using System;

public partial class UI_EntityCard : Control
{
    [ExportGroup("Parameters")]
    [Export]
    public EntityCard entityCard;
    [ExportGroup("Dependencies")]
    [Export] private Label nameLabel, atkLabel, defLabel;
    [Export] private TextureProgressBar healthbar;
    [Export] private TextureRect icon;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Visible = false;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void setCard(EntityCard newCard)
    {
        Visible = true;
        entityCard = newCard;
        nameLabel.Text = entityCard.Name;
        atkLabel.Text = "ATK: " + entityCard.Attack.ToString();
        defLabel.Text = "DEF: " + entityCard.Defense.ToString();
        healthbar.MaxValue = entityCard.MaxHP;
        icon.Texture = entityCard.Texture;
        icon.Modulate = entityCard.Color;
        GD.Print(entityCard.Name);
    }
}
