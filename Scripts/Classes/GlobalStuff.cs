using Godot;
using System;

public partial class GlobalStuff : Node
{
	//Paths
	public const string ROOT_RESOURCE_PATH = "res://Resources";
	public const string ROOT_DELVERS_PATH = ROOT_RESOURCE_PATH + "/Creatures/Delvers";
	public const string ROOT_MONSTERS_PATH = ROOT_RESOURCE_PATH + "/Creatures/Monsters";
	public const string ROOT_ITEMS_PATH = ROOT_RESOURCE_PATH + "/Items";
	public const string ROOT_SAVES_PATH = ROOT_RESOURCE_PATH + "/Saves";

	//Default Values
	public const float STARTER_MONEY = 100;

	//Limitations
	public const int MAX_MEMBER_PER_TEAM = 4;
	

	//Enums
	public enum MenuItems{
		undefined = 0,
		PreGame,
		MainOverview,
		TeamManager,
		Map
	}

	public enum ItemTypes{
		Undefined = 0,
		Resource,
		Food,
		Tool,
	}
}
