using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Helpers : Node
{
	private const string ROOT_RESOURCE_PATH = "res://Resources/";


	
	//Load Entities from given Resource Folder Name (List and single)
	public static List<EntityCard> LoadEntitiesFromDirectory(string resFolder = "")
	{
		List<Resource> entitylist = LoadResourcesFromDirectory(resFolder);
		return entitylist.ConvertAll(x => (EntityCard)x);
	}
	//Single Variant
	public static EntityCard LoadEntityFromDirectory(string entityName, string resFolder = "")
	{
		List<EntityCard> availableEntities = LoadEntitiesFromDirectory(resFolder);
		EntityCard entity = availableEntities.FirstOrDefault(item => item.Name == entityName);

		return entity; //Returns null if no entity was found
	}

	//Same as above for Player Resources (aka Save Files)
	public static List<Player> LoadPlayerFilesFromDirectory(string resFolder = "")
	{
		List<Resource> PlayerFileList = LoadResourcesFromDirectory(resFolder);
		return PlayerFileList.ConvertAll(x => (Player)x);
	}
	//Single Variant with index
	public static Player LoadPlayerFileFromDirectory(int idx, string resFolder = "")
	{
		List<Player> PlayerFileList = LoadPlayerFilesFromDirectory(resFolder);
		Player savefile = PlayerFileList.ElementAtOrDefault(idx);

		return savefile; //Returns null if no entity was found
	}



	//Load Resources from given Foldername using ROOT_RESOURCE_PATH as Resource-Root.
	//If no Foldername is given take Root-Path
	public static List<Resource> LoadResourcesFromDirectory(string resFolder = "")
	{
		List<Resource> availableResources = new List<Resource>();
		using var dir = DirAccess.Open(ROOT_RESOURCE_PATH + resFolder);
		if (dir != null)
		{
			foreach(string fileName in dir.GetFiles())
			{
				//GD.Print($"Found file: {fileName}");
				string fullResourcePath = ROOT_RESOURCE_PATH + resFolder + "/" + fileName;
				availableResources.Add(GD.Load<Resource>(fullResourcePath));
			}
		}
		else
		{
			GD.PrintErr("An error occurred when trying to access the path.");
			return null;
		}

		return availableResources;
	}
}
