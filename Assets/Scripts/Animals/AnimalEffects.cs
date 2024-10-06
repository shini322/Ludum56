using System.Collections.Generic;
using UnityEngine;

public class AnimalEffects
{
    public static Dictionary<AnimalEffectsEnum, int> EffectsPriority = new Dictionary<AnimalEffectsEnum, int>()
    {
        { AnimalEffectsEnum.Tiran, 11 },
        { AnimalEffectsEnum.Obida, 21 },
        { AnimalEffectsEnum.Luchezar, 22 },
        { AnimalEffectsEnum.Tron, 12 }
    };
    
    public static bool UseEffect(Shelf shelf, Vector2Int position, AnimalEffectsEnum effect, Animal animal)
    {
        switch (effect)
        {
            case AnimalEffectsEnum.Tiran:
                return Tiran(shelf, position);
            case AnimalEffectsEnum.Obida:
                return Obida(shelf, position, animal);
            case AnimalEffectsEnum.Luchezar:
                return Luchezar(shelf, position);
            case AnimalEffectsEnum.Tron:
                return Tron(shelf, position);
        }

        return true;
    }

    private static bool Obida(Shelf shelf, Vector2Int position, Animal animal)
    {
        for (int y = 0; y < shelf.Height; y++)
        {
            var newPosition = new Vector2Int(position.x, y);
            var lot = shelf.ShelfLotsMatrix[newPosition.x, newPosition.y];
            if (shelf.PositionToAnimalMap.TryGetValue(newPosition, out AnimalDrag animalDrag))
            {
                if (animalDrag.Animal.Type != AnimalType.Goblin && lot.Charm > animal.Charm)
                {
                    shelf.ShelfLotsMatrix[position.x, position.y].UpdateCharm(0);
                    return true;
                }
            }
        }
        
        return false;
    }
    
    private static bool Tiran(Shelf shelf, Vector2Int position)
    {
        var lot = shelf.ShelfLotsMatrix[position.x, position.y];
        var charm = lot.Charm;
        if (shelf.PositionToAnimalMap.TryGetValue(new Vector2Int(position.x + 1, position.y), out AnimalDrag downAnimalDrag))
        {
            charm += downAnimalDrag.Animal.Charm;
        }
        shelf.ShelfLotsMatrix[position.x, position.y].UpdateCharm(charm);
        return charm > lot.Charm;
    }
    
    private static bool Luchezar(Shelf shelf, Vector2Int position)
    {
        Vector2Int[] neighbors = new Vector2Int[]
        {
            new Vector2Int(position.x + 1, position.y),
            new Vector2Int(position.x - 1, position.y),
            new Vector2Int(position.x, position.y + 1),
            new Vector2Int(position.x, position.y - 1),
        };

        var lot = shelf.ShelfLotsMatrix[position.x, position.y];

        for (int i = 0; i < neighbors.Length; i++)
        {
            var neighborPosition = neighbors[i];

            if (shelf.PositionToAnimalMap.TryGetValue(neighbors[i], out AnimalDrag animalDrag))
            {
                var charmForChange = 3f;
                var slot = shelf.ShelfLotsMatrix[neighborPosition.x, neighborPosition.y];

                if (slot.Charm > animalDrag.Animal.Charm)
                {
                    charmForChange *= -1f;
                }

                slot.UpdateCharm(slot.Charm + charmForChange);
            }
        }

        return true;
    }
    
    private static bool Tron(Shelf shelf, Vector2Int position)
    {
        var lot = shelf.ShelfLotsMatrix[position.x, position.y];
        if (position.x == (shelf.Width - 1) / 2 && position.y == (shelf.Height - 1) / 2)
        {
            return false;
        } 

        shelf.ShelfLotsMatrix[position.x, position.y].UpdateCharm(lot.Charm + 10f);
        return true;
    }
}

public enum AnimalEffectsEnum
{
    Tiran,
    Obida,
    Luchezar,
    Tron,
    Korni,
    Shumnii,
    Karamba,
}