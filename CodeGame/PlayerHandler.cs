using System;
using System.Collections.Generic;
using Godot;

public partial class PlayerHandler : Node
{

    public static string LastScene { get; set; }

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
        // map the volume to the range of -60 to 0
        AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), (int)Map(volume, 0, 100, -50, 0));
    }
    private static double Map(double x, double in_min, double in_max, double out_min, double out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    public static string GetRandomElement(List<string> list)
    {
        int index = random.Next(list.Count);
        return list[index];
    }
}
