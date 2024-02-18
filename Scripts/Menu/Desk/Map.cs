using Godot;
using System;

public partial class Map : Control
{

	//Gets Called when a button is pressed and sends a "pressed()" signal with a string Parameter
	public void ChangeScene(string sceneName)
    {
        switch(sceneName)
        {
            case "MainOverview":
            DeskMenu.SwitchScene(GlobalStuff.MenuItems.MainOverview);
            break;

        }
    }
}
