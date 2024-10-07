using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DefaultExecutionOrder(-35)]
public class GameResources : Singleton<GameResources>
{
    [HideInInspector] public HashSet<Animal> Animals = new HashSet<Animal>();
    [SerializeField] public List<BuyerSO> Buyers = new List<BuyerSO>();
    [SerializeField] public List<AnimalEffectPriority> Priorities = new List<AnimalEffectPriority>()
    {
        new AnimalEffectPriority(){ Name = "Тиран", Effect = AnimalEffectsEnum.Tiran, Priority = 11 },
        new AnimalEffectPriority(){ Name = "Обидчивый", Effect = AnimalEffectsEnum.Obida, Priority = 21 },
        new AnimalEffectPriority(){ Name = "Лучезарность",Effect = AnimalEffectsEnum.Luchezar, Priority = 22 },
        new AnimalEffectPriority(){ Name = "Жадные корни",Effect = AnimalEffectsEnum.Korni, Priority = 23 },
        new AnimalEffectPriority(){ Name = "Шумный",Effect = AnimalEffectsEnum.Shumnii, Priority = 24 },
        new AnimalEffectPriority(){ Name = "Косоглазый",Effect = AnimalEffectsEnum.Kosoi, Priority = 25 },
        new AnimalEffectPriority(){ Name = "Брать все что не прибито!",Effect = AnimalEffectsEnum.BratVse, Priority = 0 },
        new AnimalEffectPriority(){ Name = "Карамба",Effect = AnimalEffectsEnum.Karamba, Priority = 26 },
        new AnimalEffectPriority(){ Name = "Пристальный взгляд",Effect = AnimalEffectsEnum.Vzglyad, Priority = 27 },
        new AnimalEffectPriority(){ Name = "Чесночный запах",Effect = AnimalEffectsEnum.Zapah, Priority = 28 },
        new AnimalEffectPriority(){ Name = "Неизменный (пассика, нет смысла в приоритете)",Effect = AnimalEffectsEnum.Neizmeni, Priority = 32 },
        new AnimalEffectPriority(){ Name = "Траур",Effect = AnimalEffectsEnum.Traur, Priority = 12 },
        new AnimalEffectPriority(){ Name = "Сестренность (не сделана)",Effect = AnimalEffectsEnum.Sister, Priority = 31 },
        new AnimalEffectPriority(){ Name = "Глубоководный",Effect = AnimalEffectsEnum.Water, Priority = 13 },
        new AnimalEffectPriority(){ Name = "Угрюмый",Effect = AnimalEffectsEnum.Ugrumii, Priority = 29 },
        new AnimalEffectPriority(){ Name = "Туманность",Effect = AnimalEffectsEnum.Fog, Priority = 30 },
    };

    public Dictionary<AnimalEffectsEnum, int> EffectsPriority = new ();

    public readonly Dictionary<CharacterType, string> DialogCharacterName = new()
    {
        { CharacterType.Elf, "The Elf" },
        { CharacterType.Player, "Trader" },
        { CharacterType.Wolf, "Werewolf" },
        { CharacterType.Vampire, "The vampire" },
        { CharacterType.HollowKnight, "The Hollow Knight" }
    };
    
    private void Init()
    {
        Animals = Resources.LoadAll<Animal>("Animals").ToHashSet();

        foreach (AnimalEffectPriority effectPriority in Priorities)
        {
            EffectsPriority.Add(effectPriority.Effect, effectPriority.Priority);
        }
    }
    
    private void Start()
    {
        Init();
    }

    [Serializable]
    public struct AnimalEffectPriority
    {
        public string Name;
        public AnimalEffectsEnum Effect;
        public int Priority;
    }
}