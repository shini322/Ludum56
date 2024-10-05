using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DefaultExecutionOrder(-35)]
public class GameResources : Singleton<GameResources>
{
    [HideInInspector] public HashSet<Animal> Animals = new HashSet<Animal>();
    
    private void Init()
    {
        Animals = Resources.LoadAll<Animal>("Animals").ToHashSet();
    }
    
    private void Start()
    {
        Init();
    }
}