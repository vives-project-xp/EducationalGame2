using Godot;
public partial class languageButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Theme = GD.Load<Theme>("res://button_theme.tres");
		Text = PlayerHandler.CurrentLanguage;
		CustomMinimumSize = new Vector2(GetViewportRect().Size.X / 4, GetViewportRect().Size.Y / 8);

	}
    public override void _Pressed()
    {
		// change the language button text to the next language in the list
		int index = PlayerHandler.Languages.IndexOf(PlayerHandler.CurrentLanguage);
		index++;
		index %= PlayerHandler.Languages.Count;
		PlayerHandler.CurrentLanguage = PlayerHandler.Languages[index];
		Text = PlayerHandler.CurrentLanguage;
    }
}
