using Godot;
using System;
using System.Collections.Generic;

public partial class DialogController : Node
{
	[Export]
	private Control _buttonsContainer;
	[Export]
	private JokeButtonController[] _jokeButtonControllers;
	

	  public override void _Ready()
	  {
		
	  }

	private void ButtonPressed(JokeModel jokeModel)
	{
		//TODO: write text on the screen
		GD.Print($"{jokeModel.Text}");
	}

	public void SetJokeButton(List<JokeModel> jokeModels ){
		
		for(int i= 0; i< _jokeButtonControllers.Length; i++)
		{
			_jokeButtonControllers[i].SetJokeButton(jokeModels[i]);
			_jokeButtonControllers[i].onJokeSelection += ButtonPressed;
		}
	}
	
}
