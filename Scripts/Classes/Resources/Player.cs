using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Player : Resource
{
	[Export] public string PlayerName;
	[Export] public float Experience;

	//Todo: Since export is not supported for Lists, default members must be set somewhere else
	private List<EntityCard> TeamComposition = new List<EntityCard>(); 
	private Inventory inventory = new Inventory(); //Manages Money and Items
	private Settlement settlement = new Settlement();




	

	//Settlement Functions
	public void AddPopulation(int amount)
	{
		settlement.AddPopulation(amount);
	}

	//Inventory Functions
	public void AddMoney(float amount)
	{
		inventory.AddMoney(amount);
	}
	public float GetTotalMoney()
	{
		return inventory.GetMoney();
	}

	//Team-Managing Functions
	public int GetTeamMemberCount()
	{
		return this.TeamComposition.Count();
	}
	public void SetPlayerTeam(List<EntityCard> team)
	{
		this.TeamComposition = team;
	}
	public void AddMemberToTeam(EntityCard member)
	{
		this.TeamComposition.Add(member);
	}
	public void RemoveMemberFromTeam(EntityCard member)
	{
		this.TeamComposition.Remove(member);
	}	

}
