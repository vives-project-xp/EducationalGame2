using System.Collections.Generic;
using Godot;

public partial class PlayerHandler : Node
{

    public static string LastScene { get; set; }

    public static List<string> Languages { get; set; } = new List<string> { "English", "Nederlands" };
    public static string CurrentLanguage { get; set; } = "English";

    public static int Volume { get; set; } = 100;
}
