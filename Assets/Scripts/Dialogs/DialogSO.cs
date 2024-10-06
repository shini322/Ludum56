using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_Dialog", menuName = "Dialogs/Dialog")]
public class DialogSO : ScriptableObject
{
    [SerializeField] public List<DialogItem> Items;
    
    [Serializable]
    public class DialogItem
    {
        [TextArea(3, 10)]
        public string Text;

        public CharacterType Type;
    }
}

public enum CharacterType
{
    Elf,
    Wolf,
    Player,
}