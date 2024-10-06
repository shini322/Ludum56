using UnityEngine;

[CreateAssetMenu(fileName = "Goblin", menuName = "Animals/Goblin Animal")]
public class GoblinAnimal : Animal
{
    public override bool ShelfEnter(Shelf shelf, Vector2Int position)
    {
        return true;
    }
}