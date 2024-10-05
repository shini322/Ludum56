using UnityEngine;

[CreateAssetMenu(fileName = "Goblin", menuName = "Animals/Goblin Animal")]

public class GoblinAnimal : Animal
{
    public override void ShelfEnter(Shelf shelf, Vector2Int position)
    {
        for (int i = 0; i < shelf.Width; i++)
        {
            if (shelf.PositionToAnimalMap.TryGetValue(position, out AnimalDrag animalDrag))
            {
                if (animalDrag.Animal.Type != AnimalType.Goblin && animalDrag.Animal.Charm > Charm)
                {
                    shelf.ShelfLotsMatrix[position.x, position.y].UpdateCharm(0);
                    return;
                }
            }
        }

        var charm = Charm;
        if (shelf.PositionToAnimalMap.TryGetValue(new Vector2Int(position.x, position.y + 1), out AnimalDrag downAnimalDrag))
        {
            charm += downAnimalDrag.Animal.Charm;
        }
        shelf.ShelfLotsMatrix[position.x, position.y].UpdateCharm(charm);
    }
}