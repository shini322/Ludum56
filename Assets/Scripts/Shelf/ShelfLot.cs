using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShelfLot : MonoBehaviour, IDropHandler
{
    [SerializeField] private RectTransform imageContainer;
    [SerializeField] private TextMeshProUGUI textContainer;

    public float Charm => charm;
    
    private AnimalSlot animalSlot;
    private AnimalDrag animalDrag;
    private Shelf shelf;
    private Vector2Int shelfPosition;
    private float charm;
    private float additionalCharm = 0.0f;

    public void Init(AnimalSlot animalSlotPrefab, Shelf shelf, Vector2Int shelfPosition)
    {
        animalSlot = Instantiate(animalSlotPrefab, imageContainer);
        this.shelf = shelf;
        this.shelfPosition = shelfPosition;
        SetAnimal(null);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out AnimalDrag animalDrag))
        {
            animalSlot.SetChild(animalDrag.RectTransform);
            animalDrag.MoveAnimalToShelf();
            shelf.AddAnimal(animalDrag, shelfPosition);
            //animalDrag.Animal.ShelfEnter(shelf);
            shelf.AnimalsUpdate();
        }
    }

    public void UpdateCharm(float charm)
    {
        if (!animalDrag.Animal.CanChangeCharm)
        {
            return;
        }

        this.charm = Mathf.Clamp(charm, 0, float.MaxValue);
        UpdateView();
    }

    public void SetAnimal(AnimalDrag animalDrag)
    {
        this.animalDrag = animalDrag;

        if (animalDrag == null)
        {
            DropValues();
        }
        else
        {
            charm = animalDrag.Animal.Charm;
            UpdateView();
        }
    }

    private void UpdateView()
    {
        var finalCharm = Math.Round(charm + additionalCharm);
        if (animalDrag == null)
        {
            textContainer.text = "";
        }
        else
        {
            textContainer.text = finalCharm.ToString();
        }
    }

    public void DropValues()
    {
        additionalCharm = 0f;
        textContainer.text = "";
        animalDrag = null;
    }
}