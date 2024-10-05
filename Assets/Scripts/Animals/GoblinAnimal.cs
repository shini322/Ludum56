using UnityEngine;

[CreateAssetMenu(fileName = "Goblin", menuName = "Animals/Goblin Animal")]

public class GoblinAnimal : Animal
{
    public override void ShelfEnter(Shelf shelf)
    {
        Debug.Log("Goblin enter");
    }

    public override void ShelfLeave(Shelf shelf)
    {
        Debug.Log("Goblin leave");
    }
}