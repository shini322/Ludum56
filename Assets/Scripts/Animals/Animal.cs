using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_Animal", menuName = "Animals")]
public class Animal : ScriptableObject
{
    [SerializeField] public Sprite Sprite;
    [SerializeField] public Sprite TooltipSprite;
    [SerializeField] public string Name;
    [TextArea(3,10)][SerializeField] public string Description;
    [TextArea(3,10)][SerializeField] public string EffectDescription;
    [SerializeField] public float Charm;
    [SerializeField] public AnimalType Type;
    [SerializeField] public List<AnimalEffectsEnum> Effects;
    [SerializeField] public bool CanChangeCharm = true;
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