using System;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private ShelfLot shelfLotPrefab;
    [SerializeField] private AnimalSlot animalSlotPrefab;

    private const int height = 3;
    private const int width = 3;

    private void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Instantiate(shelfLotPrefab, transform).Init(animalSlotPrefab);
            }
        }
    }
}