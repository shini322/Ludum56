using UnityEngine;
using UnityEngine.UI;

public class AnimalSlot : MonoBehaviour
{
    [SerializeField] private RectTransform Container;
    [SerializeField] private Sprite emptySprite;
    [SerializeField] private Sprite fullSprite;
    [SerializeField] private Image image;

    private bool isEmpty = true;

    private void Awake()
    {
        UpdateSprite();
    }

    public void SetChild(RectTransform rect)
    {
        rect.SetParent(Container, false);
        rect.anchoredPosition = Vector2.zero;   
    }

    public void ChangeEmptyState(bool value)
    {
        isEmpty = value;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        image.sprite = isEmpty ? emptySprite : fullSprite;
    }
}