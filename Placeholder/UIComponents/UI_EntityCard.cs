using Godot;
using System;

public partial class UI_EntityCard : Control
{
    [ExportGroup("Parameters")]
    [Export] public EntityCard entityCard;

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

    public void setEntity(EntityCard newCard)
    {
        entityCard = newCard;
        nameLabel.Text = entityCard.Name;
        atkLabel.Text = entityCard.Attack.ToString();
        defLabel.Text = entityCard.Defense.ToString();
        healthbar.MaxValue = entityCard.MaxHP;

    }
}
