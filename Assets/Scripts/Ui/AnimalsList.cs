using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimalsList : MonoBehaviour, IDropHandler
{
    [SerializeField] private AnimalDrag animalDragPrefab;
    [SerializeField] private AnimalSlot animalSlotPrefab;

    private List<AnimalDrag> animalDrags = new List<AnimalDrag>();
    private List<AnimalSlot> animalSlots = new List<AnimalSlot>();
    private Dictionary<AnimalType, int> animalSlotIndexMap = new Dictionary<AnimalType, int>();
    private HashSet<AnimalType> animals = new HashSet<AnimalType>();

    public void Start()
    {
        foreach (Animal animal in GameResources.Instance.Animals.ToList())
        {
            var animalDrag = Instantiate(animalDragPrefab);
            animalDrag.SetAnimal(animal);
            animalDrag.OnMovedToShelf += MoveAnimalToShelf;
            
            var animalSlot = Instantiate(animalSlotPrefab, transform);
            animalSlot.SetChild(animalDrag.RectTransform);
            animalSlots.Add(animalSlot);
            animalSlotIndexMap.Add(animal.Type, animalDrags.Count);
            animalDrags.Add(animalDrag);
            animals.Add(animal.Type);
        }
    }

    private void MoveAnimalToShelf(Animal animal)
    {
        if (animals.Contains(animal.Type))
        {
            animalDrags[animalSlotIndexMap[animal.Type]].OnMovedToShelf -= MoveAnimalToShelf;
            animals.Remove(animal.Type);
        }
        
        Debug.Log(animals.Count);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out AnimalDrag animalDrag) && animals.Add(animalDrag.Animal.Type))
        {
            animalSlots[animalSlotIndexMap[animalDrag.Animal.Type]].SetChild(animalDrag.RectTransform);
            animalDrag.OnMovedToShelf += MoveAnimalToShelf;
        }
    }
}