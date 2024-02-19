# EducationalGame2

## Hoe voeg je een minigame toe

-   voeg de folder met je _.tscn en je _.cs files in de CodeGame folder
-   pas de juiste .cs file aan in de Sea, Argiculture, Industrial, Forest als volgt.

```cs
public void <naam_van_de_functie>()
{
    PlayerHandler.LastScene = "<scene_voor_de_speler_word_verplaatst>";
    GetTree().ChangeSceneToFile("<Path_van_de_volgende_scene>");
}
```
