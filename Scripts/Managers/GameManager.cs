using Godot;
using System;
using System.Linq;

public partial class GameManager : Node
{
	//Reference to Player Resource
	[Export] private Player player;
	//Reference to UIManager
	[Export] UIManager ui;
	[Export] NavigationManager navManager;

	[ExportGroup("Pre Game")]
	[Export] private LineEdit in_playerName;

	//Gets called when the player clicks the "Click here to start" Button and Sets his initial Data
	public void SetPlayerName()
	{
		string playerName = in_playerName.Text;
		if(string.IsNullOrWhiteSpace(playerName))
		{
			ui.SetPreGameInfoLabel("Please fill in all information to continue.");
			return;
		} 

		player.PlayerName = playerName;
		ui.UpdatePlayerStatsUI(player);
		navManager.SwitchToMainMenu();

	}
}
