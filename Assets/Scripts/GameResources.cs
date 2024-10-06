using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DefaultExecutionOrder(-35)]
public class GameResources : Singleton<GameResources>
{
    [HideInInspector] public HashSet<Animal> Animals = new HashSet<Animal>();
    [SerializeField] public List<BuyerSO> Buyers = new List<BuyerSO>();
    
    private void Init()
    {
        Animals = Resources.LoadAll<Animal>("Animals").ToHashSet();
    }
    
    private void Start()
    {
        Init();
    }
}