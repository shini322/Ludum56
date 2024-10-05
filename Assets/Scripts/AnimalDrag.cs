using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimalDrag : MonoBehaviour, IBeginDragHandler,IEndDragHandler, IDragHandler
{
    public RectTransform RectTransform;
    private Image image;
    private Vector2 startPosition;

    public event Action<Animal> OnMovedToShelf;
    public event Action<Animal> OnMovedToList;
    
    public Animal Animal;
    
    public void SetAnimal(Animal animal)
    {
        Animal = animal;
        image.sprite = Animal.Sprite;
    }

    private void Awake()
    {
        image = GetComponent<Image>();
        RectTransform = image.rectTransform;
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        startPosition = RectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //image.rectTransform.anchoredPosition = startPosition;
        //RectTransform.anchoredPosition = startPosition;
        RectTransform.anchoredPosition = Vector2.zero;
        image.raycastTarget = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransform.anchoredPosition += eventData.delta / image.canvas.scaleFactor;
        image.raycastTarget = false;
    }
    
    public void MoveAnimalToShelf()
    {
        OnMovedToShelf?.Invoke(Animal);
    }

    public void MoveListToList()
    {
        OnMovedToList?.Invoke(Animal);
    }
}