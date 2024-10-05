using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimalsList : MonoBehaviour, IDropHandler
{
    [SerializeField] private AnimalDrag animalDragPrefab;
    [SerializeField] private AnimalSlot animalSlotPrefab;
    [SerializeField] private AnimalInfoView animalInfoView;

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
            
            animalInfoView.AddAnimal(animalDrag);
            
            var animalSlot = Instantiate(animalSlotPrefab, transform);
            animalSlot.SetChild(animalDrag.RectTransform);
            animalSlots.Add(animalSlot);
            animalSlotIndexMap.Add(animal.Type, animalDrags.Count);
            animalDrags.Add(animalDrag);
            animals.Add(animal.Type);
        }
    }

    private void MoveAnimalToShelf(AnimalDrag animalDrag)
    {
        if (animals.Contains(animalDrag.Animal.Type))
        {
            animalDrag.OnMovedToShelf -= MoveAnimalToShelf;
            animals.Remove(animalDrag.Animal.Type);
        }
        
        Debug.Log(animals.Count);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out AnimalDrag animalDrag) && animals.Add(animalDrag.Animal.Type))
        {
            animalSlots[animalSlotIndexMap[animalDrag.Animal.Type]].SetChild(animalDrag.RectTransform);
            //animalDrag.isShelf = false;
            animalDrag.OnMovedToShelf += MoveAnimalToShelf;
            animalDrag.MoveListToList();
        }
    }
}