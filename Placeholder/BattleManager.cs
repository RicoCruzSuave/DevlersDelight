using Godot;
using System;

public partial class BattleManager : Node2D
{
    [ExportGroup("Teams")]
    [Export]
    private NodePath PlayerTeamPath;
    [Export]
    private NodePath EnemyTeamPath;

    private Node2D PlayerTeam;
    private Node2D EnemyTeam;
    private Entity CurrentPlayer;
    private Entity CurrentEnemy;
    private bool InBattle = true;

    public override void _Ready()
    {
        base._Ready();
        PlayerTeam = GetNode<Node2D>(PlayerTeamPath);
        EnemyTeam = GetNode<Node2D>(EnemyTeamPath);
    }
    public override async void _Process(double delta)
    {
        base._Process(delta);
        if (InBattle)
        {
            if (EnemyTeam.GetChildCount() <= 0)
            {
                InBattle = false;
                return;
            }
            CurrentPlayer = (Entity)PlayerTeam.Call("get_current_node");
            CurrentEnemy = (Entity)EnemyTeam.Call("get_current_node");
            CurrentPlayer.Attack(CurrentEnemy);
            await ToSignal(CurrentPlayer.Animation, AnimationPlayer.SignalName.AnimationFinished);
            CurrentEnemy.Attack(CurrentPlayer);
            await ToSignal(CurrentEnemy.Animation, AnimationPlayer.SignalName.AnimationFinished);
            GD.Print(CurrentPlayer.Name + ": " + CurrentPlayer.CurrentHP);
        }
        else
        {
            PlayerTeam.Position += new Vector2(25.0F, 0.0F);
        }
    }
}
