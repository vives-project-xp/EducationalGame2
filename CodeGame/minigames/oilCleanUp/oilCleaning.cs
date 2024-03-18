using Godot;
using System;

public partial class oilCleaning : Node2D
{
	private bool toClose= false;
	private Sponge sponge { get; set; } = new();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AddChild(new BGDyn("res://assets/Sea/background_sea.png"));
		for (int i = 0; i < 10; i++)
		{
			Oil oil2 = new();
			foreach(var oils in GetTree().GetNodesInGroup("Oils"))
			{
				if(oils is Oil oil)
				{
					if(toClose==false)
					{
						toClose = oil2.GetRect().Intersects(oil.GetRect());
					}
					else if (toClose==true){
						
					}
				}
			}
			if(toClose==false)
				{
					AddChild(oil2);
				}
		}
		AddChild(new Sponge());
		
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

}
