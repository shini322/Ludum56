using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : ScriptableObject
{
    [SerializeField] public Sprite Sprite;
    [SerializeField] public string Name;
    [TextArea(3,10)][SerializeField] public string Description;
    [TextArea(3,10)][SerializeField] public string EffectDescription;
    [SerializeField] public float Charm;
    [SerializeField] public AnimalType Type;
    [SerializeField] public List<AnimalEffectsEnum> Effects;

    public abstract bool ShelfEnter(Shelf shelf, Vector2Int position);
}

public enum AnimalType
{
    Goblin = 1,
    Moth = 2,
    Flower = 3,
    Hare = 4,
    Mushroom = 5,
    Parrot = 6,
    Garlic,
    Golem,
    Ghost,
    Water,
    Frog,
    Hedgehog,
}