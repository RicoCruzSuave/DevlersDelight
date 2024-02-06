using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class RecruitingTab : Control
{
	private const string DELVER_RESOURCE_PATH = "res://Resources/Delvers";
	private const int MAXIMUM_MEMBERS_ALLOWED = 4;
	
	[Export]  private Player player;
	[Export] private Label lbl_noRecruits, recruitBtnLabel, recruitCount;
	[Export] private Control recruitPreviewCard;
	[Export] private ItemList recruitedMembers;
	[ExportGroup("Recruit Preview Elements")]
	[Export] private Label delverName, delverHP, delverDescription, delverATK, delverDEF, delverDTX;
	[Export] private TextureRect delverIcon;


	private List<EntityCard> origCardList = new List<EntityCard>();
	private List<EntityCard> availableDelvers = new List<EntityCard>();
	int currDelverIdx = 0; //default (first List item)

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		availableDelvers = LoadEntitiesFromDirectory();
		origCardList = LoadEntitiesFromDirectory(); //needed for removing // TODO find a better solution
		
		recruitBtnLabel.Text = "Recruit Members (" + availableDelvers.Count.ToString() + ")";
		if(availableDelvers.Count > 0)
		{
			SetPreview(availableDelvers.First());

			recruitPreviewCard.Visible = true;
		}else
		{
			lbl_noRecruits.Visible = true;
			recruitPreviewCard.Visible = false;
		}
	}


	private void SetPreview(EntityCard card)
	{
		delverIcon.Texture = card.Texture;

		delverName.Text = card.Name;
		delverDescription.Text = "Test_Description"; //TODO: Add fields for short descriptions in entitycard
		delverHP.Text = "Max Health: " + (card.MaxHP >= 999 ? "??": card.MaxHP.ToString());
		delverATK.Text = "ATK: " + (card.Attack >= 99 ? "??": card.Attack.ToString());
		delverDEF.Text = "DEF: " + (card.Defense  >= 99 ? "??": card.Defense.ToString());
		delverDTX.Text = "DTX: " + (card.Dexterity  >= 99 ? "??": card.Dexterity.ToString());
	}


	public void AcceptDelver()
	{
		if(recruitedMembers.ItemCount+1 > MAXIMUM_MEMBERS_ALLOWED) return;

		EntityCard recruitedMember = availableDelvers.ElementAt(currDelverIdx);
		
		recruitedMembers.AddItem(recruitedMember.Name, recruitedMember.Texture);
		player.AddMemberToTeam(recruitedMember);
		availableDelvers.Remove(recruitedMember);
		recruitCount.Text = "Recruited Members (" + recruitedMembers.ItemCount.ToString() + "/" + MAXIMUM_MEMBERS_ALLOWED.ToString() +  " )";
		
		currDelverIdx = (currDelverIdx+1 < availableDelvers.Count) ? currDelverIdx++ : 0;
		SetPreview(availableDelvers.ElementAt(currDelverIdx));

		recruitBtnLabel.Text = "Recruit Members (" + availableDelvers.Count.ToString() + ")";
	}

	public void DenyDelver()
	{
		//Todo...
	}

	public void RemoveRecruit()
	{
		int[] selectedRecruits = recruitedMembers.GetSelectedItems();
		if(selectedRecruits.Length == 0) return;

		EntityCard member = origCardList.First(item => item.Name == recruitedMembers.GetItemText(selectedRecruits[0]));

		player.RemoveMemberFromTeam(member);
		recruitedMembers.RemoveItem(selectedRecruits[0]);

		//for now add member back to availableDelvers list
		availableDelvers.Add(member);
		SetPreview(member);

		recruitBtnLabel.Text = "Recruit Members (" + availableDelvers.Count.ToString() + ")";
		recruitCount.Text = "Recruited Members (" + recruitedMembers.ItemCount.ToString() + "/" + MAXIMUM_MEMBERS_ALLOWED.ToString() +  " )";

	}


	public void NextDelver()
	{
		//If max is reached display first item instead
		if(currDelverIdx+1 >= availableDelvers.Count)
		{
			currDelverIdx = 0;
		} else
		{
			currDelverIdx++;
		}
		
		SetPreview(availableDelvers.ElementAt(currDelverIdx));
	}
	public void PreviousDelver()
	{
		//If min is reached display last item instead
		if(currDelverIdx-1 < 0)
		{
			currDelverIdx = availableDelvers.Count-1;
		} else
		{
			currDelverIdx--;
		}
		
		SetPreview(availableDelvers.ElementAt(currDelverIdx));
	}

	private List<EntityCard> LoadEntitiesFromDirectory()
	{
		List<EntityCard> availableEntities = new List<EntityCard>();
		using var dir = DirAccess.Open(DELVER_RESOURCE_PATH);
		if (dir != null)
		{
			foreach(string fileName in dir.GetFiles())
			{
				//GD.Print($"Found file: {fileName}");
				string fullResourcePath = DELVER_RESOURCE_PATH + "/" + fileName;
				availableEntities.Add(GD.Load<EntityCard>(fullResourcePath));
			}
		}
		else
		{
			GD.PrintErr("An error occurred when trying to access the path.");
			return null;
		}

		return availableEntities;

	}

}
