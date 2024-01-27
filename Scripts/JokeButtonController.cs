using Godot;
using System;

public partial class JokeButtonController : Button
{	
	private JokeModel _jokeModel;
	public Action<JokeModel> onJokeSelection;

	public override void _Ready()
	{
		
	}

	public void SetJokeButton(JokeModel jokeModel){
		GD.Print("Set button!");
		_jokeModel = jokeModel;
		GD.Print(this.Text);
		this.Text = _jokeModel.Type;

		this.Pressed += OnPressed;
	}


	private void OnPressed(){
		onJokeSelection?.Invoke(_jokeModel);
	}
}
