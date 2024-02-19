using System.Collections.Generic;
using Godot;

public partial class PlayerHandler : Node
{

    public static string LastScene { get; set; }

    public static List<string> Languages { get; set; } = new List<string> { "English", "Nederlands" };
    public static string CurrentLanguage { get; set; } = "Nederlands";

    public static void NextLanguage()
    {
        int index = Languages.IndexOf(CurrentLanguage);
        index++;
        if (index >= Languages.Count)
        {
            index = 0;
        }
        CurrentLanguage = Languages[index];
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
}
