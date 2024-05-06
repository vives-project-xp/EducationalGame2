using System;
using System.Collections.Generic;
using Godot;

public partial class PlayerHandler : Node
{

	public static async void PauseScene(Node node, double seconds)
	{
		node.GetTree().Paused = true;
		await node.ToSignal(node.GetTree().CreateTimer(seconds), "timeout");
		node.GetTree().Paused = false;
		return;
	}
	public enum screenPosition
	{
		start,
		center
	}
	public static StackingDificulty stackingSetDificulty;
	public static bool StackingLearning = false;
	public static bool FactoryLeaning = false;
	public static bool PlasticLeaning = false;
	public static bool OverFishingLearning = false;
	public static bool OilLeaning = false;
	public static int prevStackingPoint;
	public static int stackingHighScore;

	public static int levelCompleted;
	public enum StackingDificulty
	{
		easy,
		medium,
		hard,
		impossible,
		Endless
	}




	public bool stackingFirstClear;

	// viewport size
	public static int ViewportWidth { get; set; }
	public static int ViewportHeight { get; set; }
	public static string LastScene { get; set; } = "res://MainMenu/MainMenu.tscn";
	public enum RectSizes
	{
		Fullscreen, Halfscreen, QuarterScreen
	}
	private static Random random = new();

	public static List<string> Languages { get; set; } = new List<string> { "English", "Nederlands" };
	public static string CurrentLanguage { get; set; } = "Nederlands";

	/// <summary>
	/// Switches to the next language in the list of available languages.
	/// </summary>
	public static void NextLanguage()
	{
		CurrentLanguage = NextStringList(Languages, CurrentLanguage);
	}
	/// <summary>
	/// Returns the next string in the list, or the first string if the current string is the last in the list.
	/// ussage example: string current = "English"; string next = NextStringList(Languages, current);
	/// </summary>
	public static string NextStringList(List<string> list, string current)
	{
		int index = list.IndexOf(current);
		index++;
		index = index >= list.Count ? 0 : index;
		return list[index];
	}

	public static void SetVolume(int volume)
	{
		// map the volume to the range of -60 to 
		AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), (int)Map(volume, 0, 100, -50, 0));
	}
	private static double Map(double x, double in_min, double in_max, double out_min, double out_max) => (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;

	public static string GetRandomElement(List<string> list)
	{
		int index = random.Next(list.Count);
		return list[index];
	}
	public static void ChangeScene(Node node, string scenePath)
	{
		LastScene = node.GetTree().CurrentScene.SceneFilePath;
		node.GetTree().ChangeSceneToFile(scenePath);
	}

	public static void SetBackground(TextureRect background, string path)
	{
		background.Texture = GD.Load<Texture2D>(path);
		background.ExpandMode = TextureRect.ExpandModeEnum.IgnoreSize;
	}
	public static void SetBackgroundSize(TextureRect Rect, RectSizes Size)
	{
		switch (Size)
		{
			case RectSizes.Fullscreen:
				Rect.Size = Rect.GetViewportRect().Size;
				break;
			case RectSizes.Halfscreen:
				Rect.Size = new Vector2(ViewportWidth / 2, ViewportHeight / 2);
				break;
			case RectSizes.QuarterScreen:
				Rect.Size = new Vector2(ViewportWidth / 4, ViewportHeight / 4);
				break;
		}
	}
	public static int GetVolume() => (int)Map(AudioServer.GetBusVolumeDb(AudioServer.GetBusIndex("Master")), -50, 0, 0, 100);


	public override void _Ready()
	{
		
		musicPlayer.Stream = musicStream;
		AddChild(musicPlayer);
		Random random = new(); musicPlayer.Play(random.Next(0, 1500));
	}
	public static bool IsLearning;
	public AudioStream musicStream = GD.Load<AudioStream>("res://Music/calmmusic.mp3");
	public AudioStreamPlayer musicPlayer = new() {
		Autoplay = true,
		VolumeDb = -20,
	};
	public override void _Process(double delta)
	{
		musicPlayer.StreamPaused = IsLearning;
	}
}

