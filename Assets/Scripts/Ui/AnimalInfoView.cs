using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimalInfoView : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI charmTextGui;
    [SerializeField] private TextMeshProUGUI nameTextGui;
    [SerializeField] private TextMeshProUGUI descriptionTextGui;
    [SerializeField] private TextMeshProUGUI effectDescriptionTextGui;

    private List<AnimalDrag> animalDrags = new List<AnimalDrag>();

    private void Awake()
    {
        Drop();
    }

    public void AddAnimal(AnimalDrag animalDrag)
    {
        animalDrag.OnHovered += AnimalHovered;
        animalDrag.OnUnHovered += AnimalUnHovered;
        animalDrags.Add(animalDrag);
    }

    private void OnDisable()
    {
        foreach (var animalDrag in animalDrags)
        {
            animalDrag.OnHovered -= AnimalHovered;
            animalDrag.OnUnHovered -= AnimalUnHovered;
        }
    }

    private void AnimalHovered(AnimalDrag animalDrag)
    {
        charmTextGui.text = animalDrag.Animal.Charm.ToString();
        image.sprite = animalDrag.Animal.Sprite;
        descriptionTextGui.text = animalDrag.Animal.Description;
        effectDescriptionTextGui.text = animalDrag.Animal.EffectDescription;
        nameTextGui.text = animalDrag.Animal.Name;
    }
    
    private void AnimalUnHovered(AnimalDrag animalDrag)
    {
        Drop();
        Debug.Log(animalDrag.Animal.Type);
    }

    private void Drop()
    {
        descriptionTextGui.text = "";
        effectDescriptionTextGui.text = "";
        nameTextGui.text = "";
        charmTextGui.text = "";
        image.sprite = null;
    }
}