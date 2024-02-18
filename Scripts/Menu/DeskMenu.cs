using Godot;
using System;



public partial class DeskMenu : Node
{
	private static Control MainOverview, TeamManager, PreGameNode, Map;

    public override void _Ready()
    {
		PreGameNode = GetTree().Root.GetNode<Control>("@Control@3/Desk/PreGamePage");
		MainOverview = GetTree().Root.GetNode<Control>("@Control@3/Desk/MainOverview"); //@Control@3 = "DeskMenu" Control/Scene for some reason
		TeamManager = GetTree().Root.GetNode<Control>("@Control@3/Desk/TeamManager");
		Map = GetTree().Root.GetNode<Control>("@Control@3/Desk/Map");
    }

	//TODO: Better Navigation System still?...:/
    public static void SwitchScene(GlobalStuff.MenuItems switchTo)
	{
		switch(switchTo)
		{
			case GlobalStuff.MenuItems.PreGame:
				PreGameNode.Visible = true;
				MainOverview.Visible = false;
				TeamManager.Visible = false;
				Map.Visible = false;
			break;
			case GlobalStuff.MenuItems.MainOverview:
				PreGameNode.Visible = false;
				MainOverview.Visible = true;
				TeamManager.Visible = false;
				Map.Visible = false;
			break;
			case GlobalStuff.MenuItems.TeamManager:
				PreGameNode.Visible = false;
				MainOverview.Visible = false;
				TeamManager.Visible = true;
				Map.Visible = false;
			break;
			case GlobalStuff.MenuItems.Map:
				PreGameNode.Visible = false;
				MainOverview.Visible = false;
				TeamManager.Visible = false;
				Map.Visible = true;
			break;

			default:
				//Todo
			break;
		}
	}
}
