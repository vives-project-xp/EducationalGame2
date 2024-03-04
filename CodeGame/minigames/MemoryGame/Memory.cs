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
		GridContainer = new GRID(size: GetViewportRect().Size);
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
		// get the current selected cards
		var selectedCards = cards.FindAll(card => card.selected);
		// if there are two selected cards check if they fit together
		if (selectedCards.Count == 2)
		{
			if (selectedCards[0]._TextureNormal == selectedCards[1]._TextureNormal)
			{
				selectedCards[0].done = true;
				selectedCards[1].done = true;
			}
			else
			{
				// wait for 1 second but delay the process
				GetTree().Paused = true;
				await ToSignal(GetTree().CreateTimer(1.5), "timeout");
				GetTree().Paused = false;
				selectedCards[0].flipped = false;
				selectedCards[1].flipped = false;
			}
			// unselect all cards

			foreach (var card in cards)
			{
				card.selected = false;
			}
		}



	}


}
