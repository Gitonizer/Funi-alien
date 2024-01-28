using Godot;
using System;
using System.IO;
using System.Text.Json;

public partial class FileHelper
{
    static string path;

	public FileHelper()
	{
		if (OS.HasFeature("editor"))
			path = ProjectSettings.GlobalizePath("res://Resources/");
		else
			path = OS.GetExecutablePath().GetBaseDir().PathJoin("Resources/");

		GD.Print(path);
    }

	public T LoadTextFromFile<T>(string fileName)
	{
		string data;
		string filePath;

		T returnData = default(T);

        filePath = Path.Join(path, fileName);

        GD.Print(filePath);

        if (!File.Exists(filePath))
		{
			GD.Print("no file found");
			return returnData;
		}
		
		try
        {
            data = File.ReadAllText(filePath);
            returnData = JsonSerializer.Deserialize<T>(data);
        }
		catch (JsonException e)
		{
			GD.Print(e);
		}

        return returnData;
	}
}
