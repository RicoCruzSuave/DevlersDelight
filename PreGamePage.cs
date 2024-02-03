using Godot;
using System;

public partial class PreGamePage : Control
{
	[Export] private LineEdit playerName, partyName;
	[Export] private Label infoLabel;

	[Export] private Player player;

	private ButtonManager bm;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bm = GetTree().Root.GetNode<ButtonManager>("StartMenu/ButtonManager");
	}

	public void onClickStart()
	{
		//Set Playername and Party name
		if(playerName.Text == "" /*|| partyName.Text == ""*/){
			infoLabel.Text = "In order to begin, please complete all fields.";
			return;
		}

		//Set Playername and stuff
		player.PlayerName = playerName.Text;
		bm.SwitchToMainMenu();
	}
}
