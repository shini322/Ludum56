using UnityEngine;
using UnityEngine.UI;

public class AnimalSlot : MonoBehaviour
{
    [SerializeField] private RectTransform Container;
    [SerializeField] private Image emptyImage;
    [SerializeField] private Image fullImage;
    [SerializeField] private Image chooseImage;

    private bool isEmpty = true;
    private Vector2 startPosition;

    private void Awake()
    {
        startPosition = Container.rect.position;
        chooseImage.gameObject.SetActive(false);
        UpdateSprite();
    }

    public void SetChild(RectTransform rect)
    {
        rect.SetParent(Container, false);
        rect.anchoredPosition = Vector2.zero;   
    }

    public void SetChooseImageState(bool value)
    {
        chooseImage.gameObject.SetActive(value);
    }

    public void ChangeEmptyState(bool value)
    {
        isEmpty = value;
        UpdateSprite();
    }

    public void Shake()
    {
        // Container.anchoredPosition = new Vector2(startPosition.x + Mathf.Sin(Time.time * 1f) * 1f,
        //     startPosition.y + (Mathf.Sin(Time.time * 1f) * 1f));
    }

    private void UpdateSprite()
    {
        emptyImage.gameObject.SetActive(isEmpty);
        fullImage.gameObject.SetActive(!isEmpty);
    }
}