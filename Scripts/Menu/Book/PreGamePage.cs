using Godot;
using System;

public partial class PreGamePage : Control
{
	[Export] private LineEdit playerName, partyName;
	[Export] private Label infoLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//autoload_Player = GetNode<Player>("/root/Player");
	}

	public void onClickStart()
	{
		//Set Playername and Party name
		if(playerName.Text == "" /*|| partyName.Text == ""*/){
			infoLabel.Text = "In order to begin, please complete all fields.";
			return;
		}

		//Set Playername and create Player
		PlayerData.CreatePlayer(playerName.Text);
	}
}
