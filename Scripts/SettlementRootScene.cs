using Godot;
using System;

public partial class SettlementRootScene : Control
{
	[Export] PackedScene OverviewScene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void ChangeScene(string sceneName)
	{
		switch(sceneName)
		{
			case "MainOverview":
				SceneManager.Instance.SwitchScene(OverviewScene);
			break;
			default:
			break;
		}
	}
}
