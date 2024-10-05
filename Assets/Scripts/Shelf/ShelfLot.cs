using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShelfLot : MonoBehaviour, IDropHandler
{
    [SerializeField] private RectTransform imageContainer;
    [SerializeField] private TextMeshProUGUI textContainer;
    
    private AnimalSlot animalSlot;
    private Shelf shelf;
    private Vector2Int shelfPosition;
    private float additionalCharm = 0.0f;

    public void Init(AnimalSlot animalSlotPrefab, Shelf shelf, Vector2Int shelfPosition)
    {
        animalSlot = Instantiate(animalSlotPrefab, imageContainer);
        this.shelf = shelf;
        this.shelfPosition = shelfPosition;
        SetAnimalView(null);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out AnimalDrag animalDrag))
        {
            animalSlot.SetChild(animalDrag.RectTransform);
            animalDrag.MoveAnimalToShelf();
            if (shelf.HasAnimal(animalDrag))
            {
                animalDrag.Animal.ShelfLeave(shelf);
            }
            shelf.AddAnimal(animalDrag, shelfPosition);
            animalDrag.Animal.ShelfEnter(shelf);
        }
    }

    public void SetAnimalView(AnimalDrag animalDrag)
    {
        if (animalDrag == null)
        {
            textContainer.text = "";
        }
        else
        {
            textContainer.text = Math.Round(animalDrag.Animal.Charm + additionalCharm).ToString();
        }
    }
}