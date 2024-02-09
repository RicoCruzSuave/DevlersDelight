using Godot;
using System;

public partial class MainOverview : Control
{

    [Export] private Label lbl_playername, lbl_money, lbl_exp;

    //Gets called on "visibility_changed()" signal from root Node "MainOverview"
    public void OnMenuVisible()
    {
        if(!this.Visible) return;
        //TODO: Remove this to somewhere else. THIS IS JUST FOR QUICK TESTING
        if(PlayerData.curPlayer == null) PlayerData.CreatePlayer("Player");
        GD.Print("MainOverview Loaded");

        lbl_playername.Text = PlayerData.curPlayer.PlayerName;
        lbl_money.Text = "Money total: " + PlayerData.curPlayer.Money.ToString();
        lbl_exp.Text = "Experience total:" + PlayerData.curPlayer.Experience.ToString();

    }

}
