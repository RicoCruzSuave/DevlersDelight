using Godot;
using System;

public partial class TeamManagement : Control
{

    [Export] private Control Overview, RecruitingPRIMARY, RecruitingSECONDARY;
	//Gets Called when a button is pressed and sends a "pressed()" signal with a string Parameter
	public void ChangeScene(string sceneName)
    {
        switch(sceneName)
        {
            case "MainOverview":
                DeskMenu.SwitchScene(GlobalStuff.MenuItems.MainOverview);
            break;
            case "TeamManagement":
                Overview.Visible = true;
                RecruitingPRIMARY.Visible = false;
                RecruitingSECONDARY.Visible = false;
            break;
            case "Recruiting":
                Overview.Visible = false;
                RecruitingPRIMARY.Visible = true;
                RecruitingSECONDARY.Visible = true;
            break;

        }
    }
}
