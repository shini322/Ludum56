using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimalInfoView : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI charmTextGui;

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
        Debug.Log(animalDrag.Animal.Type);
    }
    
    private void AnimalUnHovered(AnimalDrag animalDrag)
    {
        Drop();
        Debug.Log(animalDrag.Animal.Type);
    }

    private void Drop()
    {
        charmTextGui.text = "";
        image.sprite = null;
    }
}