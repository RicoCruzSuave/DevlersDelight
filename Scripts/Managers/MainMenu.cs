using Godot;
using System;

public partial class MainMenu : Control
{
	

	[ExportGroup("Dependencies")]
	[Export] private Player player;
	[Export] Label playerName, playerMoney, playerExperience;
	private ButtonManager bm;
	public override void _Ready()
	{
		bm = GetTree().Root.GetNode<ButtonManager>("StartMenu/ButtonManager");
		SetPlayerAndUI();
	}
	public void SetPlayerAndUI(Player playerDat = null)
	{
		Player playerData = (playerDat == null) ? player : playerDat;
		//Set stats
		playerName.Text = playerData.PlayerName;
		playerMoney.Text ="Money: " + playerData.Money.ToString();
		playerExperience.Text = "Experience: " + playerData.Experience.ToString();
		/*playerTeamMemberCount.Text = "Members recruited: " + playerData.GetTeamMemberCount().ToString() + "/4";*/
	}


	/*public void SwitchToTeamManager()
	{
		
		//bm.SwitchToTeamManager();
	}
	public void QuitGame()
	{
		bm.QuitGame();
	}*/
}
