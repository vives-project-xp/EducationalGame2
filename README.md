# EducationalGame2

## Hoe voeg je een minigame toe.

-   voeg de folder met je _.tscn en je _.cs files in de CodeGame folder
-   pas de juiste .cs file aan in de Sea, Argiculture, Industrial, Forest als volgt.

```cs
public void <naam_van_de_functie>()
{
    PlayerHandler.LastScene = "<scene_voor_de_speler_word_verplaatst>";
    GetTree().ChangeSceneToFile("<Path_van_de_volgende_scene>");
}
```

## Hoe op telossen van .tscn bij problemen van het in te laden.

1. open .tscn file in vscode
2. verwijder alle headers zoals
```e
>>>>>>>>HEAD
of
=========== <random getal>
of
===========
```