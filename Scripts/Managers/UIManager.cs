using Godot;
using System;

public partial class UIManager : Node
{

	[ExportGroup("Pre Game")]
	[Export] private Label infoLabel;

	[ExportGroup("Player Profile")]
	[Export] private Label playerName, playerMoney, playerExperience;

	//Functions
	public void UpdatePlayerStatsUI(Player playerData)
	{
		playerName.Text = playerData.PlayerName;
		playerMoney.Text ="Money: " + playerData.Money.ToString();
		playerExperience.Text = "Experience: " + playerData.Experience.ToString();
	}

	public void SetPreGameInfoLabel(string message)
	{
		infoLabel.Text = message;
	}
	//Event Functions
}
