using Godot;

public partial class PlayerData : Node
{
	public static Player curPlayer;

	public static void CreatePlayer(string playerName)
	{
        curPlayer = LoadPlayerFile();
        if(curPlayer != null) return;

        curPlayer = new Player
        {
            PlayerName = playerName
        };
    }

    //returns null if non found
    public static Player LoadPlayerFile()
    {
        return Helpers.LoadPlayerFileFromDirectory(0); //Take the first save found (for now)
    }

}
