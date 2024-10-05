using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "Animals")]
public class Animal : ScriptableObject
{
    [SerializeField] public Sprite Sprite;
    [SerializeField] public float Charm;
    [SerializeField] public AnimalType Type;
}

public enum AnimalType
{
    Goblin,
    Jopa
}