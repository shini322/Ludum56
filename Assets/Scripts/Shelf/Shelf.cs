using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private ShelfLot shelfLotPrefab;
    [SerializeField] private AnimalSlot animalSlotPrefab;

    private const int height = 3;
    private const int width = 3;
    private ShelfLot[,] shelfLotsMatrix;
    private Dictionary<AnimalDrag, Vector2Int> animalMap = new Dictionary<AnimalDrag, Vector2Int>();

    private void Start()
    {
        shelfLotsMatrix = new ShelfLot[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var shelfLot = Instantiate(shelfLotPrefab, transform);
                shelfLot.Init(animalSlotPrefab, this, new Vector2Int(x, y));
                shelfLotsMatrix[x, y] = shelfLot;
            }
        }
    }

    public bool HasAnimal(AnimalDrag animalDrag)
    {
        return animalMap.ContainsKey(animalDrag);
    }

    public void AddAnimal(AnimalDrag animalDrag, Vector2Int position)
    {
        if (animalMap.TryAdd(animalDrag, position))
        {
            animalDrag.OnMovedToList += MoveListToList;
            shelfLotsMatrix[position.x, position.y].SetAnimalView(animalDrag);
        }
        else
        {
            var oldPosition = animalMap[animalDrag];
            shelfLotsMatrix[oldPosition.x, oldPosition.y].SetAnimalView(null);
            animalMap[animalDrag] = position;
            shelfLotsMatrix[position.x, position.y].SetAnimalView(animalDrag);
        }
    }

    public void MoveListToList(AnimalDrag animalDrag)
    {
        animalDrag.OnMovedToList -= MoveListToList;
        animalMap.Remove(animalDrag);
        animalDrag.Animal.ShelfLeave(this);
    }
    
    
}