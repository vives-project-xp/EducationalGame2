using System;
using System.Collections.Generic;
using Godot;

public partial class Memory : Node2D
{
	public GridContainer GridContainer { get; set; }
	// Called when the node enters the scene tree for the first time.
	private List<Card> cards = new List<Card> {
		new Card("res://assets/Industrial/bomb.png"),
		new Card("res://assets/Industrial/factory_piece1.png"),
		new Card("res://assets/Industrial/bomb.png"),
		new Card("res://assets/Industrial/bomb.png"),
		new Card("res://assets/Industrial/bomb.png"),
		new Card("res://assets/Industrial/bomb.png"),
		new Card("res://assets/Industrial/bomb.png"),
		new Card("res://assets/Industrial/bomb.png"),
		new Card("res://assets/Industrial/bomb.png"),
		new Card("res://assets/Industrial/bomb.png"),
	};
	public override void _Ready()
	{
        GridContainer = new GRID(size : GetViewportRect().Size);
        Shuffle(cards);
		for (int i = 0; i < cards.Count; i++)
		{
			GridContainer.AddChild(cards[i]);
		}
		AddChild(GridContainer);

	}
	public void Shuffle<T>(IList<T> list)
	{
		Random random = new Random();
		int n = list.Count;
		while (n > 1)
		{
			n--;
			int k = random.Next(n + 1);
            (list[n], list[k]) = (list[k], list[n]);
        }
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


}
