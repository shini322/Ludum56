using UnityEngine;

[CreateAssetMenu(fileName = "Moth", menuName = "Animals/Moth Animal")]

public class MothAnimal : Animal
{
    [SerializeField] public float charmForChange;
    [SerializeField] public float selfCharmForChange;

    public override bool ShelfEnter(Shelf shelf, Vector2Int position)
    {
        return true;
    }
}