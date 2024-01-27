using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

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
    [Export]
    private DialogController _dialogController;
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


        GD.Print(_jokes[0].Text);

        StartLevel();
    }

	public void StartLevel()
	{
        _currentCharacter = _characters[GD.Randi() % _characters.Length];
		
		_mainCharacter.SetCharacter(_currentCharacter.Name);


        RunRound();
    }

	public void RunRound()
	{
        // get jokes
		List<JokeModel> roundJokes = GetRandomJokes();

        foreach (var joke in roundJokes)
        {            
            GD.Print("----------");
            GD.Print(joke.Text);
        }

        _dialogController.SetJokeButton(roundJokes);

        //generate jokes
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

    private List<JokeModel> GetRandomJokes()
    {
        JokeModel[] likeJokes = _jokes.Where(joke => joke.Type == _currentCharacter.Like).ToArray();
        JokeModel[] dislikeJokes = _jokes.Where(joke => joke.Type == _currentCharacter.Dislike).ToArray();
        JokeModel[] neutralJokes = _jokes.Where(joke => joke.Type == _currentCharacter.Neutral).ToArray();

        GD.Print("JOKE SIZE: " + _jokes.Length);

        if (likeJokes.Length == 0 || dislikeJokes.Length == 0 || neutralJokes.Length == 0)
        {
            GD.Print("NOT ENOUGH JOKES FOR THE ROUND");
            return new List<JokeModel>();
        }

        List<JokeModel> returnJokes = new List<JokeModel>
        {
            likeJokes[GD.Randi() % likeJokes.Length],
            dislikeJokes[GD.Randi() % likeJokes.Length],
            neutralJokes[GD.Randi() % likeJokes.Length]
        };

        return returnJokes;
    }
}
