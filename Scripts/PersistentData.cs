using Godot;
using System;
using System.Collections.Generic;

public partial class PersistentData : Node
{
	[Export]
	public int Level = 0;

	public List<string> usedCharacters;

    public void IncrementLevel()
	{
		Level++;
	}
	public void ResetLevel()
	{
		Level = 0;
	}

	public void BlackListCharacter(string character)
	{
		if (usedCharacters == null) usedCharacters = new List<string>();

		usedCharacters.Add(character);
	}
}
