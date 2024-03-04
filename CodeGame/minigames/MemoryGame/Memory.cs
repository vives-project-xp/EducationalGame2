using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public partial class Memory : Node2D
{	public CenterContainer GridContainer { get; set; }
	// Called when the node enters the scene tree for the first time.
	private Card[] cards = new Card[] {
		new Card("res://assets/Sea/Sea_containerboat.png"),
		new Card("res://assets/Sea/Sea_fishersboat.png"),
		new Card("res://assets/Sea/Sea_speedboat.png"),
		new Card("res://assets/Sea/Sea_cruiseship.png"),
		new Card("res://assets/Sea/Sea_Fish.png"),
		new Card("res://assets/Sea/Sea_containerboat.png"),
		new Card("res://assets/Sea/Sea_fishersboat.png"),
		new Card("res://assets/Sea/Sea_speedboat.png"),
		new Card("res://assets/Sea/Sea_cruiseship.png"),
		new Card("res://assets/Sea/Sea_Fish.png"),
	};
	public override void _Ready()
	{
		Shuffle(cards);
		GridContainer = new CenterElements(new GRID(cards,size: GetViewportRect().Size));
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
		var selectedCards = cards.Where(card => card.selected).ToList();
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
