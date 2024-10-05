using UnityEngine;

public abstract class Animal : ScriptableObject
{
    [SerializeField] public Sprite Sprite;
    [SerializeField] public float Charm;
    [SerializeField] public AnimalType Type;

    public abstract void ShelfEnter(Shelf shelf);
    public abstract void ShelfLeave(Shelf shelf);
}

public enum AnimalType
{
    Goblin = 1,
    Jopa = 2,
}