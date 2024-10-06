using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimalInfoView : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI charmTextGui;
    [SerializeField] private RectTransform charmContainer;
    [SerializeField] private TextMeshProUGUI nameTextGui;
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
        charmContainer.gameObject.SetActive(true);
        charmTextGui.text = animalDrag.Animal.Charm.ToString();
        image.sprite = animalDrag.Animal.TooltipSprite;
        effectDescriptionTextGui.text = animalDrag.Animal.EffectDescription;
        nameTextGui.text = animalDrag.Animal.Name;
        ChangeOpacity(1);
    }
    
    private void AnimalUnHovered(AnimalDrag animalDrag)
    {
        Drop();
        Debug.Log(animalDrag.Animal.Type);
    }

    private void Drop()
    {
        effectDescriptionTextGui.text = "";
        nameTextGui.text = "";
        charmTextGui.text = "";
        image.sprite = null;
        ChangeOpacity(0);
        charmContainer.gameObject.SetActive(false);
    }

    private void ChangeOpacity(float opacity)
    {
        var color = image.color;
        color.a = opacity;
        image.color = color;
    }
}