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
    private List<JokeModel> _jokes;

	private CharacterModel _currentCharacter;
	private JokeModel _currentJoke;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        _fileHelper = new FileHelper();

        LoadFiles();

        _dialogController.onNext += RunRound;

        StartLevel();
    }

    private void LoadFiles()
    {
        _characters = _fileHelper.LoadTextFromFile<CharacterModel[]>("characters.json");
        _jokes = _fileHelper.LoadTextFromFile<List<JokeModel>>("jokes.json");
    }

	public void StartLevel()
	{
        _currentCharacter = _characters[GD.Randi() % _characters.Length];
		
		_mainCharacter.SetCharacter(_currentCharacter.Name);

        RunRound();
    }

	public void RunRound()
	{
        GD.Print("RunRound..");
        // get jokes
		List<JokeModel> roundJokes = GetRandomJokes();

        _dialogController.SetJokeButton(roundJokes, EvaluateAnswer);

        //generate jokes
    }

	public void EvaluateAnswer(JokeModel joke)
    {
        // Run dialog
        //emote character
        if(_currentCharacter.Like.Equals(joke.Type)){
            _mainCharacter.ChangeMood(Constants.EXPRESSION_HAPPY);
            //add satisfaction
        }else if (_currentCharacter.Dislike.Equals(joke.Type)){
            _mainCharacter.ChangeMood(Constants.EXPRESSION_ANGRY);
            //remove satisfaction
        }else{
            _mainCharacter.ChangeMood(Constants.EXPRESSION_NEUTRAL);
        }

		// evaluate if game ending
        if (_mainCharacter.CurrentMood < 0 || _mainCharacter.CurrentMood > 100)
        {
            GD.Print("GAME OVER");
        }
        
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

        if (likeJokes.Length == 0 || dislikeJokes.Length == 0 || neutralJokes.Length == 0)
        {
            LoadFiles();

            likeJokes = _jokes.Where(joke => joke.Type == _currentCharacter.Like).ToArray();
            dislikeJokes = _jokes.Where(joke => joke.Type == _currentCharacter.Dislike).ToArray();
            neutralJokes = _jokes.Where(joke => joke.Type == _currentCharacter.Neutral).ToArray();
        }

        List<JokeModel> returnJokes = new List<JokeModel>
        {
            likeJokes[GD.Randi() % likeJokes.Length],
            dislikeJokes[GD.Randi() % dislikeJokes.Length],
            neutralJokes[GD.Randi() % neutralJokes.Length]
        };

        foreach (var joke in returnJokes)
        {
            _jokes.Remove(joke);
        }

        returnJokes.Shuffle();

        return returnJokes;
    }
}
