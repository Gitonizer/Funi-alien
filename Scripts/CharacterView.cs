using Godot;
using System;

/*
	- Handles character ui characteristcs and data
*/


public partial class CharacterView : Node
{
	private Sprite2D _faceBase;
	private Texture  _faceBasetexture;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_faceBase = GetNode<Sprite2D>("Character_Base_Sprite2D");
		
		try{
			_faceBasetexture  = GD.Load<Texture>("res://Textures/Character/character-01-face-base.png");
		}catch(Exception e){
			GD.Print(e);
		}

		if(_faceBase!= null){
			
			GD.Print("Assigning Texture!!");

			_faceBase.Texture = (Texture2D)_faceBasetexture;

		}else{
			GD.Print("_faceBase is NULL!!!");
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
