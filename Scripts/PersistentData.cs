using Godot;
using System;

public partial class PersistentData : Node
{
	[Export]
	public int Level = 0;

	public void IncrementLevel()
	{
		Level++;
	}
	public void ResetLevel()
	{
		Level = 0;
	}
}
