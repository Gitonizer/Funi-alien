using Godot;
using System;
using System.Collections.Generic;

public partial class DialogController : Node
{
	[Export]
	private Control _buttonsContainer;
	[Export]
	private Control _dialogContainer;
	[Export]
	private RichTextLabel _dialogText;
	[Export]
	private Button _nextButton;
	[Export]
	private JokeButtonController[] _jokeButtonControllers;
	
	public Action onNext;

	public override void _Ready()
	{
		_dialogContainer.Visible = false;
		_buttonsContainer.Visible = true;		
		_nextButton.Pressed += NextButtonPressed;
	}

	private void JokeButtonPressed(JokeModel jokeModel)
	{
		GD.Print("JokeButtonPressed");
		_dialogText.Text = jokeModel.Text;
		SwitchPanels();
	}

	private void NextButtonPressed(){
		
		ReleaseButton();
		onNext?.Invoke();
		SwitchPanels();
	}

	private void ReleaseButton()
	{
		for(int i= 0; i< _jokeButtonControllers.Length; i++)
		{
			GD.Print("Release");
			_jokeButtonControllers[i].ReleaseBttn();
			_jokeButtonControllers[i].onJokeSelection -= JokeButtonPressed;
		}
	}

	public void SetJokeButton(List<JokeModel> jokeModels, Action<JokeModel> evaluate){
		
		for(int i= 0; i< _jokeButtonControllers.Length; i++)
		{
			GD.Print("SetJokeButton...");

			_jokeButtonControllers[i].SetJokeButton(jokeModels[i]);
			
			_jokeButtonControllers[i].onJokeSelection += JokeButtonPressed;
			_jokeButtonControllers[i].onJokeSelection += evaluate;

        }
	}	

	private void SwitchPanels()
	{
		_dialogContainer.Visible = !_dialogContainer.Visible; 
		_buttonsContainer.Visible = !_buttonsContainer.Visible;	
	}
}
