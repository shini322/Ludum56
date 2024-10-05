using UnityEngine;

public abstract class Animal : ScriptableObject
{
    [SerializeField] public Sprite Sprite;
    [SerializeField] public string Name;
    [TextArea(3,10)][SerializeField] public string Description;
    [TextArea(3,10)][SerializeField] public string EffectDescription;
    [SerializeField] public float Charm;
    [SerializeField] public AnimalType Type;

    public abstract void ShelfEnter(Shelf shelf, Vector2Int position);
}

public enum AnimalType
{
    Goblin = 1,
    Jopa = 2,
}