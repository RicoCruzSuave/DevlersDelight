using Godot;
using System;



public partial class MainOverview : Control
{
    [Export] PackedScene SettlementScene;

    [Export] private Label lbl_playername, lbl_money, lbl_exp, lbl_teamcount;

    //Gets called on "visibility_changed()" signal from root Node "MainOverview"
    public void OnMenuVisible()
    {
        if(!this.Visible) return;
        //TODO: Remove this to somewhere else. THIS IS JUST FOR QUICK TESTING
        if(PlayerData.curPlayer == null) PlayerData.CreatePlayer("Player");

        lbl_playername.Text = PlayerData.curPlayer.PlayerName;
        lbl_money.Text = "Money total: " + PlayerData.curPlayer.GetTotalMoney().ToString();
        lbl_exp.Text = "Experience total:" + PlayerData.curPlayer.Experience.ToString();
        lbl_teamcount.Text = "Team cap.: " + PlayerData.curPlayer.GetTeamMemberCount().ToString() + "/4"; //TODO: 4 should be a global somewhere. change it later

    }

    //Gets Called when a button is pressed and sends a "pressed()" signal with a string Parameter
    public void ChangeScene(string sceneName)
    {
        switch(sceneName)
        {
            case "SettlementScreen":
                SceneManager.Instance.SwitchScene(SettlementScene);
            break;
            case "Quit":
                SceneManager.Instance.QuitApplication();
            break;

        }
    }

}
