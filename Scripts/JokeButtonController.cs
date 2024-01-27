using Godot;
using System;

public partial class JokeButtonController : Button
{	
	private JokeModel _jokeModel;
	public Action<JokeModel> onJokeSelection;

	public void SetJokeButton(JokeModel jokeModel){
		_jokeModel = jokeModel;
		this.Text = _jokeModel.Type;	
		this.Pressed += OnPressed;
	}

	public void ReleaseBttn(){
		this.Pressed -= OnPressed;
	}

	private void OnPressed(){
		onJokeSelection?.Invoke(_jokeModel);
	}
}
