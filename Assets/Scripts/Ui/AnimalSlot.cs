using UnityEngine;

public class AnimalSlot : MonoBehaviour
{
    [HideInInspector] public RectTransform Rect;

    public void SetChild(RectTransform rect)
    {
        InitRect();
        rect.SetParent(Rect, false);
        rect.anchoredPosition = Vector2.zero;   
    }

    private void InitRect()
    {
        if (Rect == null)
        {
            Rect = GetComponent<RectTransform>();
        }
    }
}