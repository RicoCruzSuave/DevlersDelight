using Godot;
using System;

public partial class ButtonManager : Node
{
	[Export] private Control TeamManagerNode, MainMenuNode;
	

	public void SwitchToTeamManager()
	{
		MainMenuNode.Visible = false;
		TeamManagerNode.Visible = true;
	}
	public void SwitchToMainMenu()
	{
		MainMenu menuInstance = MainMenuNode as MainMenu;
		menuInstance.SetPlayerAndUI(); //Updates Player Stats on the MainMenu

		TeamManagerNode.Visible = false;
		MainMenuNode.Visible = true;
	}


	public void QuitGame()
	{
		GetTree().Quit();
	}
}
