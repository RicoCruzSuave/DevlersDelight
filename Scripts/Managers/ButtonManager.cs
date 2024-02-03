using Godot;
using System;

public partial class ButtonManager : Node
{
	[Export] private Control PreGameNode, MainMenuNode;
	
	[Export] private AnimatedSprite2D pageFlipAnim;

	private Control gotoPage;
	public void SwitchToMainMenu()
	{
		

		MainMenu menuInstance = MainMenuNode as MainMenu;
		menuInstance.SetPlayerAndUI(); //Updates Player Stats on the MainMenu

		PreGameNode.Visible = false;
		gotoPage = MainMenuNode;
		pageFlipAnim.Visible = true;
		pageFlipAnim.Play();
	}

	public void PageFlipFinished(){

		if(gotoPage == null) return;

		gotoPage.Visible = true;
		pageFlipAnim.Visible = false;
		gotoPage = null;
	}

	public void QuitGame()
	{
		GetTree().Quit();
	}
}
