using Godot;
using System;

public partial class NavigationManager : Node
{
	[Export] Camera2D BookCam, OpenDeskCam;
	
	[ExportGroup("Transitions and Animations")]
	[Export] AnimatedSprite2D pageFlipLeft;

	//Pages
	[ExportGroup("Pages")]
	[Export] private Control PreGameNode, MainMenuNode, TeamManagerNode, MapNode;

	//Has the page the player wants to access stored for when the animation is finished.
	private Control gotoPage; 

	//Button Functions
	public void SwitchToTeamManager()
	{
		OpenDeskCam.MakeCurrent();
	}
	public void SwitchToBook()
	{
		BookCam.MakeCurrent();
	}
	public void SwitchToMainMenu()
	{
		gotoPage = MainMenuNode;
		PreGameNode.Visible = false;
		
		pageFlipLeft.Visible = true;
		pageFlipLeft.Play();
		//Now wait for PageFlipFinished()-Function
	}
	
	public void QuitGame()
	{
		GetTree().Quit();
	}


	//EventFunctions
	//Called whenever the PageFlip Animation signal is emitted
	public void PageFlipFinished(){

		if(gotoPage == null) return;

		gotoPage.Visible = true;
		pageFlipLeft.Visible = false;
		gotoPage = null;
	}
}
