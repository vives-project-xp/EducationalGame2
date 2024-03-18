using Godot;
using System;

public partial class oilCleaning : Node2D
{
	private bool toClose= false;
	private Sponge sponge { get; set; } = new();
	float posX;
	float posY;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AddChild(new BGDyn("res://assets/Sea/background_sea.png"));
		for (int i = 0; i < 10; i++)
		{
			Oil oil2 = new();
			/*do{
				AddChild(oil2);
				foreach(var oils in GetTree().GetNodesInGroup("Oils"))
				{
					if(oils is Oil oil)
					{
						if(toClose==false)
						{
							//check for colosion with other oil
							toClose = oil2.GetRect().Intersects(oil.GetRect());
							
						}
					}
					GD.Print(toClose);
				}	
				if(toClose==true)
				{
					RemoveChild(oil2);
				}

			} while(toClose==true);*/
			AddChild(new Oil());
		}
		AddChild(new Sponge());
		
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

}
