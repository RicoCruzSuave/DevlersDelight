using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class TeamManager : Control
{

	[ExportGroup("Dependencies")]
	[Export] private ItemList availableMembers, selectedMembers;
	[Export] private Label teamcap, available , delverName, delverATK, delverDEF, delverDTX, delverHP;
	[Export] private TextureRect delverIcon;
	[Export] private Player player;
	
	private List<EntityCard> availableDelvers, teamComposition;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//bm = GetTree().Root.GetNode<ButtonManager>("GameManager/ButtonManager");
		availableDelvers = Helpers.LoadEntitiesFromDirectory("Delvers");
		foreach(EntityCard card in availableDelvers)
		{
			//GD.Print(card.Name);
			availableMembers.AddItem(card.Name, card.Texture);
		}
		teamComposition = new List<EntityCard>();

		UpdateUI();
	}

	//Attached to the "item_selected" Signal from both the availableDelver List
	public void AvailableDelverSelectedEvent(int idx)
	{
		selectedMembers.DeselectAll();//Otherwise you can select one of each list wich breaks code ^^"
		EntityCard card = availableDelvers.First(item => item.Name == availableMembers.GetItemText(idx));
		PreviewDelver(card);
	}
	//Attached to the "item_selected" Signal from both the SelectedDelver List
	public void TeamCompositionSelectedEvent(int idx)
	{
		availableMembers.DeselectAll();//Otherwise you can select one of each list wich breaks code ^^"
		EntityCard card = teamComposition.First(item => item.Name == selectedMembers.GetItemText(idx));
		PreviewDelver(card);
	}
	//Attached to the "pressed()" Signal of the AddDelver-Button
	public void AddDelverToTeam()
	{
		if(selectedMembers.ItemCount > 3) //Max Team Capacity
		{
			GD.Print("Maximum team capacity reached! You can't add more.");
			return;
		}
			
		
		SwapItems(availableMembers, selectedMembers);
	}

	//Attached to the "pressed()" Signal of the RemoveDelver-Button
	public void RemoveDelverFromTeam()
	{
		SwapItems(selectedMembers, availableMembers,false);
	}

	//AddMember is a flag to swap between Adding or removing a member from a list
	private void SwapItems(ItemList origItemList, ItemList targetItemList, bool AddMember = true) 
	{
		List<EntityCard> origCardList, targetCardList;
		//Set Lists accordingly
		if(AddMember)
		{
			origCardList = availableDelvers;
			targetCardList = teamComposition;
		}else
		{
			origCardList = teamComposition;
			targetCardList = availableDelvers;
		}

		int[] selectedIdxList = origItemList.GetSelectedItems();
		if(selectedIdxList.Length == 1 ) //Can only be 1 or 0 since Itemlist-type is "single"
		{
			int idx = selectedIdxList[0];

			EntityCard card = origCardList.First(item => item.Name == origItemList.GetItemText(idx));
			//Update Itemlists
			origItemList.RemoveItem(idx);
			targetItemList.AddItem(card.Name, card.Texture);
			//Update actual EntityCard-Lists
			targetCardList.Add(card);
			origCardList.Remove(card);

			UpdateUI();

		}else
		{
			GD.Print("Selected Array returned too much or nothing at all.");
		}
	}

	//Update UI
	private void UpdateUI()
	{
		availableMembers.SortItemsByText();
		selectedMembers.SortItemsByText();
		
		available.Text = "Available for recruitment (" + availableMembers.ItemCount + ")";
		teamcap.Text = "Team capacity: (" + selectedMembers.ItemCount + "/4)";
	}

	private void PreviewDelver(EntityCard cardData)
	{
		delverIcon.Texture = cardData.Texture;
		delverName.Text = cardData.Name;
		//?? is just cosmetic and can be removed if you want.
		delverHP.Text = "Max Health: " + (cardData.MaxHP <= 999 ? cardData.MaxHP.ToString() : "??");
		delverATK.Text = "ATK: " + (cardData.Attack <= 99 ? cardData.Attack.ToString() : "??");
		delverDEF.Text = "DEF: " + (cardData.Defense  <= 99 ? cardData.Defense.ToString() : "??");
		delverDTX.Text = "DTX: " + (cardData.Dexterity  <= 99 ? cardData.Dexterity.ToString() : "??");
	}


	public void SwitchToMainMenu()
	{
		//player.SetPlayerTeam(teamComposition);
		//bm.SwitchToMainMenu();
	}
}
