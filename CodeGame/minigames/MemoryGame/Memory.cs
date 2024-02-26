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
	public override async void _Process(double delta)
	{
		// check if there are more than 2 cards flipped
		// if so, check if they are the same
		// if they are the same, keep them flipped for a sec 
		// if they are not the same, flip them back
		// if there are no cards flipped, do nothing
		if (cards.FindAll(card => card.flipped).Count == 2)
		{
			await ToSignal(GetTree().CreateTimer(1), "timeout");
			var flippedCards = cards.FindAll(card => card.flipped);
			if (flippedCards[0]._TextureNormal != flippedCards[1]._TextureNormal)
			{
				flippedCards[0].TextureNormal = ResourceLoader.Load<Texture2D>("res://assets/Sea/Sea_backcard.png");
				flippedCards[1].TextureNormal = ResourceLoader.Load<Texture2D>("res://assets/Sea/Sea_backcard.png");
				flippedCards[0].flipped = false;
				flippedCards[1].flipped = false;
			}
			
		}
	}


}
