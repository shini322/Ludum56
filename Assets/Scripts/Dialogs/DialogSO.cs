using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_Dialog", menuName = "Dialogs/Dialog")]
public class DialogSO : ScriptableObject
{
    [SerializeField] public List<DialogItemSO> Items;
}