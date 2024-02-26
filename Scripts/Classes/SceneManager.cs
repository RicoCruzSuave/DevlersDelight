using Godot;
using System;

public partial class SceneManager : Node
{
	public static SceneManager Instance;

	private SceneTree globalRoot;
	private Node gameRoot, currentScene;
	private Callable callable;

    public override void _Ready()
    {
        Instance = new SceneManager
        {
            globalRoot = GetTree(),

        };
		//Setup to switch scenes on idleFrame (when all frame-dependent calculations are done)
		Instance.callable = new Callable(Instance, "DeferredSwitchScene");

		Instance.gameRoot = Instance.globalRoot.Root.GetNode("GameManager");
		Instance.currentScene = Instance.gameRoot.GetNode("Desk"); 
		
		GD.Print("Games Root Scene set to " + Instance.gameRoot.Name+"-Node");
		GD.Print("Current Scene set to " + Instance.currentScene.Name+"-Node");
    }

	public void SwitchScene(PackedScene scene)
	{
		Instance.callable.CallDeferred(scene);
	}
	//Switch scenes on idleFrame (when all frame-dependent calculations are done)
	private void DeferredSwitchScene(PackedScene scene)
	{
		if(currentScene != null)
			currentScene.Free();
		
		Node instantiatedScene = scene.Instantiate();
		Instance.gameRoot.AddChild(instantiatedScene);
		currentScene = instantiatedScene;
	}

	//If we ever want todo something else before quitting.
	//like saving
	public void QuitApplication()
	{
		globalRoot.Quit();
	}

}
