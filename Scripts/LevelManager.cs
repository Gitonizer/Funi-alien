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
	[Export]
	private CharacterView _mainCharacter;
	private FileHelper _fileHelper;

	private CharacterModel[] _characters;
    private JokeModel[] _jokes;

	private CharacterModel _currentCharacter;
	private JokeModel _currentJoke;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        _fileHelper = new FileHelper();

		_characters = _fileHelper.LoadTextFromFile<CharacterModel[]>("characters.json");
        _jokes = _fileHelper.LoadTextFromFile<JokeModel[]>("jokes.json");

        _currentCharacter = _characters[GD.Randi() % _characters.Length];
		
		_mainCharacter.SetCharacter(_currentCharacter.Name);


		RunRound();
    }

	public void RunRound()
	{
		// Generate joke buttons
	}

	public void EvaluateAnswer()
    {
        // Run dialog
		// Change mood bar
		// evaluate if game ending
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
    }
}
