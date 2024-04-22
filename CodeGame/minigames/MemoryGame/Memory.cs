using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public partial class Memory : Node2D
{	public CenterContainer GridContainer { get; set; }
	// Called when the node enters the scene tree for the first time.
	private Card[] cards = new Card[] {
		new("res://assets/Sea/Sea_containerboat.png"),
		new("res://assets/Sea/Sea_fishersboat.png"),
		new("res://assets/Sea/Sea_speedboat.png"),
		new("res://assets/Sea/Sea_cruiseship.png"),
		new("res://assets/Sea/Sea_Fish.png"),
		new("res://assets/Sea/Sea_containerboat.png"),
		new("res://assets/Sea/Sea_fishersboat.png"),
		new("res://assets/Sea/Sea_speedboat.png"),
		new("res://assets/Sea/Sea_cruiseship.png"),
		new("res://assets/Sea/Sea_Fish.png"),
	};
	public override void _Ready()
	{
		MoreGamesBtn._Visible = false;
		Shuffle(cards);
		GridContainer = new CenterElements(new GRID(cards, 100,100));
		AddChild(GridContainer);

	}
	public static void Shuffle<T>(IList<T> list)
	{
		Random random = new();
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
		// get the current selected cards
		var selectedCards = cards.Where(card => card.selected).ToList();
		// if there are two selected cards check if they fit together
		if (selectedCards.Count == 2)
		{
			if (selectedCards[0].frontcard == selectedCards[1].frontcard)
			{
				selectedCards[0].done = true;
				selectedCards[1].done = true;
			}
			else
			{
				// wait for 1 second but delay the process
				PlayerHandler.PauseScene(this, 1);
				selectedCards[0].flipped = false;
				selectedCards[1].flipped = false;
			}
			// unselect all cards

			foreach (var card in cards)
			{
				card.selected = false;
			}
		}

		// check if all cards are done 
		if (cards.All(card => card.done)) 
		{
			PlayerHandler.ChangeScene(this, "res://World/World.tscn");
		}



	}


}
