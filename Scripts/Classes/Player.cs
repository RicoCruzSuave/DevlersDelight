using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Player : Resource
{
	[Export] public string PlayerName;
	[Export] public float Experience;
	[Export] public float Money;

	//Todo: Since export is not supported, default members must be set somewhere else
	private List<EntityCard> TeamComposition = new List<EntityCard>(); 

	public int GetTeamMemberCount()
	{
		return TeamComposition.Count();
	}
	
	public void SetPlayerTeam(List<EntityCard> team)
	{
		this.TeamComposition = team;
	}
}
