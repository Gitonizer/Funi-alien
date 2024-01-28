using Godot;
using System;

/*
	- Handles character ui characteristcs and data
*/


public partial class CharacterView : Node
{
	[ExportGroup ("Sprites 2D")]
	[Export]
	private Sprite2D _faceBase;
	[Export]
	private Sprite2D _hairBase;
	[Export]
	private Sprite2D _expressionBase;
	[Export]
	private ProgressBar _progressBar;

	private int MOOD_VALUE = 10;

	[Export]
	public int CurrentMood;

	private Texture  _faceBasetexture;
	private Texture  _hairtexture;
	private Texture  _neutralExpressiontexture;
	private Texture  _angryExpressiontexture;
	private Texture  _happyExpressiontexture;


	private string _characterName;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CurrentMood = 50;
		_progressBar.Value = 50;
    }

	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void LoadTextures()
	{
		string basePath = $"res://Textures/Character/{_characterName}/";
		
		GD.Print("Getting textures...");
		try{
			_faceBasetexture  = GD.Load<Texture>($"{basePath}faceBase.png");
			_hairtexture  = GD.Load<Texture>($"{basePath}hairbase.png");
			_neutralExpressiontexture  = GD.Load<Texture>($"{basePath}expression_neutral.png");
			_angryExpressiontexture  = GD.Load<Texture>($"{basePath}expression_angry.png");
			_happyExpressiontexture  = GD.Load<Texture>($"{basePath}expression_happy.png");

		
		}catch(Exception e){
			GD.Print($"Error while getting Textures: {e.Message}");
		}

		GD.Print("Setting Sprites...");
		try{
						
			_faceBase.Texture = (Texture2D)_faceBasetexture;
			_hairBase.Texture = (Texture2D) _hairtexture;
			_expressionBase.Texture = (Texture2D) _neutralExpressiontexture;
		}catch(Exception e){
			GD.Print($"Error while setting Sprites: {e.Message}");
		}
		
	}

	/// <summary>
	/// Recives a character name.
	/// </summary>
	/// <param name="characterName"> String parameeter with name</param>
	public void SetCharacter(string characterName){	
		_characterName = characterName;
		LoadTextures();
	}

	/// <summary>
	/// Recives a emotion as sting
	/// Valid values: angry, happy
	/// Defaut expression is Neutral
	/// </summary>
	/// <param name="emotion"></param>
	private void ChangeExpression(string emotion){
		GD.Print("Changin expression to ... " + emotion);
		switch (emotion)
		{
			case Constants.EXPRESSION_ANGRY:
				_expressionBase.Texture = (Texture2D) _angryExpressiontexture;
				
			break;

			case Constants.EXPRESSION_HAPPY:
				_expressionBase.Texture = (Texture2D) _happyExpressiontexture;
			break;
			
			default:
				_expressionBase.Texture = (Texture2D) _neutralExpressiontexture;
			break;
		}
	}

	private void ChangeSlider(string emotion)
	{
        switch (emotion)
        {
            case Constants.EXPRESSION_ANGRY:
                _progressBar.Value -= MOOD_VALUE;
				CurrentMood -= MOOD_VALUE;

                break;

            case Constants.EXPRESSION_HAPPY:
                _progressBar.Value += MOOD_VALUE;
                CurrentMood += MOOD_VALUE;

                break;

            default:
                _expressionBase.Texture = (Texture2D)_neutralExpressiontexture;
                break;
        }
    }

	public void ChangeMood(string emotion){
	
		ChangeExpression(emotion);
		ChangeSlider(emotion);
	}
}
