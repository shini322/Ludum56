using System.Collections.Generic;
using UnityEngine;

public class AnimalEffects
{
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
            case AnimalEffectsEnum.Korni:
                return Korni(shelf, position);
            case AnimalEffectsEnum.Shumnii:
                return Shumnii(shelf, position);
            case AnimalEffectsEnum.Kosoi:
                return Kosoi(shelf, position);
            case AnimalEffectsEnum.Karamba:
                return Karamba(shelf, position);
            case AnimalEffectsEnum.Vzglyad:
                return Vzglyad(shelf, position);
            case AnimalEffectsEnum.Zapah:
                return Zapah(shelf, position);
            case AnimalEffectsEnum.Traur:
                return Traur(shelf, position);
            case AnimalEffectsEnum.Water:
                return Water(shelf, position);
            case AnimalEffectsEnum.Ugrumii:
                return Ugrumii(shelf, position);
            case AnimalEffectsEnum.Fog:
                return Fog(shelf, position);
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
            new Vector2Int(position.x + 1, position.y + 1),
            new Vector2Int(position.x + 1, position.y - 1),
            new Vector2Int(position.x - 1, position.y + 1),
            new Vector2Int(position.x - 1, position.y - 1),
            new Vector2Int(position.x + 1, position.y),
            new Vector2Int(position.x - 1, position.y),
            new Vector2Int(position.x, position.y - 1),
            new Vector2Int(position.x, position.y + 1),
        };

        var animalDrag = shelf.PositionToAnimalMap[position];
        var charmForChange = 3f;
        var currentSlot = shelf.ShelfLotsMatrix[position.x, position.y];
        if (currentSlot.Charm > animalDrag.Animal.Charm)
        {
            charmForChange *= -1f;
        }

        for (int i = 0; i < neighbors.Length; i++)
        {
            if (shelf.PositionToAnimalMap.TryGetValue(neighbors[i], out AnimalDrag neighbourAnimalDrag))
            {
                var neighborPosition = neighbors[i];
                var slot = shelf.ShelfLotsMatrix[neighborPosition.x, neighborPosition.y];
                slot.UpdateCharm(slot.Charm + charmForChange);
            }
        }

        return true;
    }
    
    private static bool Korni(Shelf shelf, Vector2Int position)
    {
        float additionalCharm = 0f;
        for (int y = 0; y < shelf.Height; y++)
        {
            var slot = shelf.ShelfLotsMatrix[position.x, y];
            additionalCharm += slot.Charm;
            slot.UpdateCharm(0);
        }

        var currentSlot = shelf.ShelfLotsMatrix[position.x, position.y];
        currentSlot.UpdateCharm(currentSlot.Charm + additionalCharm);
        return true;
    }
    
    private static bool Shumnii(Shelf shelf, Vector2Int position)
    {
        var downSlot = new Vector2Int(position.x + 1, position.y);
        var upSlot = new Vector2Int(position.x - 1, position.y);

        if (shelf.PositionToAnimalMap.TryGetValue(downSlot, out AnimalDrag animalDrag))
        {
            var slot = shelf.ShelfLotsMatrix[downSlot.x, downSlot.y];
            slot.UpdateCharm(slot.Charm - 2f);
        }
        
        if (shelf.PositionToAnimalMap.TryGetValue(upSlot, out AnimalDrag animalDrag1))
        {
            var slot = shelf.ShelfLotsMatrix[upSlot.x, upSlot.y];
            slot.UpdateCharm(slot.Charm - 2f);
        }
        
        return true;
    }
    
    private static bool Kosoi(Shelf shelf, Vector2Int position)
    {
        if (shelf.PositionToAnimalMap.TryGetValue(new Vector2Int(position.x, position.y + 1), out AnimalDrag animalDrag))
        {
            var slot = shelf.ShelfLotsMatrix[position.x, position.y + 1];
            slot.UpdateCharm(slot.Charm + 1f);
        }
        
        if (shelf.PositionToAnimalMap.TryGetValue(new Vector2Int(position.x, position.y - 1), out AnimalDrag animalDrag1))
        {
            var slot = shelf.ShelfLotsMatrix[position.x, position.y - 1];
            slot.UpdateCharm(slot.Charm + 1f);
        }
        return true;
    }
    
    private static bool Karamba(Shelf shelf, Vector2Int position)
    {
        Vector2Int[] neighbors = new Vector2Int[]
        {
            new Vector2Int(position.x + 1, position.y + 1),
            new Vector2Int(position.x + 1, position.y - 1),
            new Vector2Int(position.x - 1, position.y + 1),
            new Vector2Int(position.x - 1, position.y - 1),
        };
        
        for (int i = 0; i < neighbors.Length; i++)
        {
            var neighborPosition = neighbors[i];

            if (shelf.PositionToAnimalMap.TryGetValue(neighbors[i], out AnimalDrag animalDrag))
            {
                var slot = shelf.ShelfLotsMatrix[neighborPosition.x, neighborPosition.y];
                slot.UpdateCharm(slot.Charm - 3f);
            }
        }
        return true;
    }

    private static bool Vzglyad(Shelf shelf, Vector2Int position)
    {
        var downSlot = new Vector2Int(position.x + 1, position.y);
        if (shelf.PositionToAnimalMap.TryGetValue(downSlot, out AnimalDrag animalDrag))
        {
            var slot = shelf.ShelfLotsMatrix[downSlot.x, downSlot.y];
            slot.UpdateCharm(slot.Charm + 1f);
        }

        return true;
    }
    
    private static bool Zapah(Shelf shelf, Vector2Int position)
    {
        var upSlot = new Vector2Int(position.x - 1, position.y);
        if (shelf.PositionToAnimalMap.TryGetValue(upSlot, out AnimalDrag animalDrag))
        {
            var slot = shelf.ShelfLotsMatrix[upSlot.x, upSlot.y];
            slot.UpdateCharm(slot.Charm - 2f);
        }

        return true;
    }
    
    private static bool Traur(Shelf shelf, Vector2Int position)
    {
        float minCharm = float.MaxValue;
        
        var lot = shelf.ShelfLotsMatrix[position.x, position.y];

        for (int x = 0; x < shelf.ShelfLotsMatrix.GetLength(0); x++)
        {
            for (int y = 0; y < shelf.ShelfLotsMatrix.GetLength(1); y++)
            {
                var shelfposition = new Vector2Int(x, y);
        
                if (shelf.PositionToAnimalMap.TryGetValue(shelfposition, out AnimalDrag animalDrag) && animalDrag.Animal.Type != AnimalType.Ghost)
                {
                    minCharm = Mathf.Min(minCharm, shelf.ShelfLotsMatrix[shelfposition.x, shelfposition.y].Charm);
                }
            }
        }

        if (minCharm > lot.Charm)
        {
            lot.UpdateCharm(lot.Charm + 10f);
        }
        
        return true;
    }
    
    private static bool Water(Shelf shelf, Vector2Int position)
    {
        var lot = shelf.ShelfLotsMatrix[position.x, position.y];
        lot.UpdateCharm(lot.Charm + position.x + 1);
        
        return true;
    }
    
    private static bool Ugrumii(Shelf shelf, Vector2Int position)
    {
        for (int y = 0; y < shelf.Height; y++)
        {
            var slot = shelf.ShelfLotsMatrix[position.x, y];
            if (shelf.PositionToAnimalMap.TryGetValue(new Vector2Int(position.x, y), out AnimalDrag animalDrag) && animalDrag.Animal.Type != AnimalType.Frog)
            {
                slot.UpdateCharm(slot.Charm + 2f);
            }
        }
        
        return true;
    }
    
    private static bool Fog(Shelf shelf, Vector2Int position)
    {
        Vector2Int[] neighbors = new Vector2Int[]
        {
            new Vector2Int(position.x + 1, position.y + 1),
            new Vector2Int(position.x + 1, position.y - 1),
            new Vector2Int(position.x - 1, position.y + 1),
            new Vector2Int(position.x - 1, position.y - 1),
            new Vector2Int(position.x + 1, position.y),
            new Vector2Int(position.x - 1, position.y),
            new Vector2Int(position.x, position.y - 1),
            new Vector2Int(position.x, position.y + 1),
        };

        float maxCharm = 0;
        
        for (int i = 0; i < neighbors.Length; i++)
        {
            var neighborPosition = neighbors[i];

            if (shelf.PositionToAnimalMap.TryGetValue(neighbors[i], out AnimalDrag animalDrag))
            {
                var slot = shelf.ShelfLotsMatrix[neighborPosition.x, neighborPosition.y];
                maxCharm = Mathf.Max(maxCharm, slot.Charm);
            }
        }
        var currentSlot = shelf.ShelfLotsMatrix[position.x, position.y];
        currentSlot.UpdateCharm(maxCharm);

        return true;
        
        return true;
    }
}

public enum AnimalEffectsEnum
{
    Tiran,
    Obida,
    Luchezar,
    Korni,
    Shumnii,
    Kosoi,
    BratVse,
    Karamba,
    Vzglyad,
    Zapah,
    Neizmeni,
    Traur,
    Sister,
    Water,
    Ugrumii,
    Fog
}