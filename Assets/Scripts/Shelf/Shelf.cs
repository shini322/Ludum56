using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private ShelfLot shelfLotPrefab;
    [SerializeField] private AnimalSlot animalSlotPrefab;

    public readonly int Height = 3;
    public readonly int Width = 3;
    public ShelfLot[,] ShelfLotsMatrix;
    private Dictionary<AnimalDrag, Vector2Int> animalToPositionMap = new Dictionary<AnimalDrag, Vector2Int>();
    public Dictionary<Vector2Int, AnimalDrag> PositionToAnimalMap = new Dictionary<Vector2Int, AnimalDrag>();
    private List<AnimalEffectsEnum> sortedEffects = new List<AnimalEffectsEnum>();
    private Dictionary<AnimalEffectsEnum, AnimalDrag> sortedEffectsAnimalMap = new Dictionary<AnimalEffectsEnum, AnimalDrag>();
    
    private void Start()
    {
        ShelfLotsMatrix = new ShelfLot[Width, Height];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                var shelfLot = Instantiate(shelfLotPrefab, transform);
                shelfLot.Init(animalSlotPrefab, this, new Vector2Int(x, y));
                ShelfLotsMatrix[x, y] = shelfLot;
            }
        }
    }

    public bool HasAnimal(AnimalDrag animalDrag)
    {
        return animalToPositionMap.ContainsKey(animalDrag);
    }

    public void AddAnimal(AnimalDrag animalDrag, Vector2Int position)
    {
        if (animalToPositionMap.TryAdd(animalDrag, position))
        {
            PositionToAnimalMap.Add(position, animalDrag);
            animalDrag.OnMovedToList += MoveListToList;
            ShelfLotsMatrix[position.x, position.y].SetAnimal(animalDrag);
            foreach (AnimalEffectsEnum effect in animalDrag.Animal.Effects)
            {
                sortedEffects.Add(effect);
                sortedEffectsAnimalMap.Add(effect, animalDrag);
            }
            SortEffects();
        }
        else
        {
            var oldPosition = animalToPositionMap[animalDrag];
            ShelfLotsMatrix[oldPosition.x, oldPosition.y].SetAnimal(null);
            animalToPositionMap[animalDrag] = position;
            PositionToAnimalMap.Remove(oldPosition);
            PositionToAnimalMap[position] = animalDrag;
            ShelfLotsMatrix[position.x, position.y].SetAnimal(animalDrag);
        }
    }

    public void MoveListToList(AnimalDrag animalDrag)
    {
        animalDrag.OnMovedToList -= MoveListToList;
        var position = animalToPositionMap[animalDrag];
        animalToPositionMap.Remove(animalDrag);
        PositionToAnimalMap.Remove(position);
        foreach (AnimalEffectsEnum effect in animalDrag.Animal.Effects)
        {
            sortedEffects.Remove(effect);
            sortedEffectsAnimalMap.Remove(effect);
        }
        AnimalsUpdate();
    }

    private void SortEffects()
    {
        sortedEffects = sortedEffects.OrderBy(n => AnimalEffects.EffectsPriority[n]).ToList();
        Debug.Log(sortedEffects.Count);
    }

    public void AnimalsUpdate()
    {
        for (int x = 0; x < ShelfLotsMatrix.GetLength(0); x++)
        {
            for (int y = 0; y < ShelfLotsMatrix.GetLength(1); y++)
            {
                var position = new Vector2Int(x, y);
        
                if (PositionToAnimalMap.TryGetValue(position, out AnimalDrag animalDrag))
                {
                    ShelfLotsMatrix[position.x, position.y].SetAnimal(animalDrag);
                }
                else
                {
                    ShelfLotsMatrix[position.x, position.y].SetAnimal(null);
                }
            }
        }
        
        foreach (AnimalEffectsEnum effect in sortedEffects)
        {
            var animal = sortedEffectsAnimalMap[effect];

            AnimalEffects.UseEffect(this, animalToPositionMap[animal], effect, animal.Animal);
        }
    }
}