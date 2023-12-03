using Godot;
using System;
using System.Linq;

public partial class BattleManager : Node2D
{
    [ExportGroup("Teams")]
    [Export]
    private NodePath PlayerTeamPath;
    [Export]
    private NodePath EnemyTeamPath;

    private Node2D PlayerTeam;
    private Node2D EnemyTeam;
    private bool InBattle = true;
    private int CurrentEntityIndex = 0;
    private int CurrentEntityCount;
    private Entity[] EntityOrder;

    public override void _Ready()
    {
        base._Ready();
        PlayerTeam = GetNode<Node2D>(PlayerTeamPath);
        EnemyTeam = GetNode<Node2D>(EnemyTeamPath);
        BuildTurnOrder();
    }
    public override void _Process(double delta)
    {
        base._Process(delta);
        if (InBattle)
        {
            if (EnemyTeam.GetChildCount() <= 0)
            {
                InBattle = false;
                return;
            }
            BattleTurn();
        }
        else
        {
            PlayerTeam.Position += new Vector2(25.0F, 0.0F);
        }
    }

    private void BuildTurnOrder()
    {
        CurrentEntityCount = PlayerTeam.GetChildCount() + EnemyTeam.GetChildCount();
        Entity[] AllEntities = new Entity[CurrentEntityCount];
        PlayerTeam.GetChildren().ToArray().CopyTo(AllEntities, 0);
        EnemyTeam.GetChildren().ToArray().CopyTo(AllEntities, PlayerTeam.GetChildCount());
        EntityOrder = AllEntities.OrderBy(e => e.CurrentDexterity).ToArray();
    }

    public void BattleTurn()
    {
        // Resetting turn order in case anything changed
        BuildTurnOrder();

        Entity CurrentEntity = EntityOrder[CurrentEntityIndex];
        Entity PreviousEntity = EntityOrder[Mathf.Wrap(CurrentEntityIndex - 1, 0, CurrentEntityCount)];
        if (!IsInstanceValid(CurrentEntity)) { NextEntity(); return; }
        if (PreviousEntity.Animation.IsPlaying())
        {
            return;
        }
        CurrentEntity.Attack(GetTarget(CurrentEntity.Card.Target));
        NextEntity();
    }

    public void NextEntity()
    {
        // Move to next in turn order
        CurrentEntityIndex = Mathf.Wrap(CurrentEntityIndex + 1, 0, CurrentEntityCount);

    }

    public Entity GetTarget(EntityCard.Targets TargetSelection)
    {
        switch (TargetSelection)
        {
            case EntityCard.Targets.FIRST_ALLY:
                return (Entity)PlayerTeam.GetChild(0);
            case EntityCard.Targets.LAST_ENEMY:
                return (Entity)EnemyTeam.GetChild(-1);
            case EntityCard.Targets.LAST_ALLY:
                return (Entity)PlayerTeam.GetChild(-1);
            default:
            case EntityCard.Targets.FIRST_ENEMY:
                return (Entity)EnemyTeam.GetChild(0);

        }
    }
}
