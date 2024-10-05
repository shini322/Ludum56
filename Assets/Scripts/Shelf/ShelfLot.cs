using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShelfLot : MonoBehaviour, IDropHandler
{
    private RectTransform rectTransform;
    private AnimalSlot animalSlot;

    public void Init(AnimalSlot animalSlotPrefab)
    {
        rectTransform = GetComponent<RectTransform>();
        animalSlot = Instantiate(animalSlotPrefab, rectTransform);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.TryGetComponent(out AnimalDrag animalDrag))
        {
            animalSlot.SetChild(animalDrag.RectTransform);
            animalDrag.MoveAnimalToShelf();
        }
    }
}