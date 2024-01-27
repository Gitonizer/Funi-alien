using Godot;
using System;

/*
	TODO:
		- Loads Json data
		- Build the level nodes 
		- Managers Level UI
*/

public partial class LevelManager : Node
{
	FileHelper _fileHelper;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        _fileHelper = new FileHelper();

		GD.Print(_fileHelper.LoadTextFromFile<Character_Model[]>("characters.json")[0].Name);


	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
