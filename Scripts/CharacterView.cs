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

	private Texture  _faceBasetexture;
	private Texture  _hairtexture;
	private Texture  _expressiontexture;

	private string _characterName;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		

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
			_expressiontexture  = GD.Load<Texture>($"{basePath}expression.png");
		
		}catch(Exception e){
			GD.Print($"Error while getting Textures: {e.Message}");
		}

		GD.Print("Setting Textures...");
		if(_faceBase!= null){
						
			_faceBase.Texture = (Texture2D)_faceBasetexture;
			_hairBase.Texture = (Texture2D) _hairtexture;
			_expressionBase.Texture = (Texture2D) _expressiontexture;
		}else{
			GD.Print("_faceBase is NULL!!!");
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
}
