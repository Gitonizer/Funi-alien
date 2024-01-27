using Godot;
using System;
using System.IO;
using System.Text.Json;

public partial class FileHelper
{
    static string path;

	public FileHelper()
	{
        path = ProjectSettings.GlobalizePath("res://Resources/");
    }

	public T LoadTextFromFile<T>(string fileName)
	{
		string data = null;
		string filePath = null;

		T returnData = default(T);

        filePath = Path.Join(path, fileName);

		if (!File.Exists(filePath))
		{
			GD.Print("no file found");
			return returnData;
		}
		
		try
        {
            data = File.ReadAllText(filePath);
			GD.Print(data);
            returnData = JsonSerializer.Deserialize<T>(data);
        }
		catch (JsonException e)
		{
			GD.Print(e);
		}

        return returnData;
	}
}
