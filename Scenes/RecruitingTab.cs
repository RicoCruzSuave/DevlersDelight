using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class RecruitingTab : Control
{
	private const string DELVER_RESOURCE_PATH = "res://Resources/Delvers";
	

	[Export] private Label lbl_noRecruits, recruitBtnLabel;
	[Export] private Control recruitPreviewCard;
	[ExportGroup("Recruit Preview Elements")]
	[Export] private Label lbl_recruitCount, delverName, delverHP, delverDescription, delverATK, delverDEF, delverDTX;
	[Export] private TextureRect delverIcon;


	private List<EntityCard> availableDelvers = new List<EntityCard>();
	int currDelverIdx = 0; //default (first List item)
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		availableDelvers = LoadEntitiesFromDirectory();

		recruitBtnLabel.Text = "Recruit Members (" + availableDelvers.Count.ToString() + ")";
		if(availableDelvers.Count > 0)
		{
			lbl_noRecruits.Visible = false;
			
			lbl_recruitCount.Text = availableDelvers.Count.ToString() + " new recruits!";
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
		if(currDelverIdx-1 <= 0)
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
