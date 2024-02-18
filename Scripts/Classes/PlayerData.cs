using Godot;

public partial class PlayerData : Node
{
	public static Player curPlayer;

	public static void CreatePlayer(string playerName)
	{
        curPlayer = LoadPlayerFile();
        if(curPlayer != null) return;

        //Create new Player and set starting parameters
        curPlayer = new Player
        {
            PlayerName = playerName
        };
        curPlayer.AddMoney(GlobalStuff.STARTER_MONEY);
        curPlayer.AddPopulation(GlobalStuff.STARTER_POPULATION_SIZE);
    }

    //returns null if non found
    public static Player LoadPlayerFile()
    {
        return Helpers.LoadPlayerFileFromDirectory(0, GlobalStuff.ROOT_SAVES_PATH); //Take the first save found (for now)
    }

}
