using UnityEngine;

[CreateAssetMenu(fileName = "_DialogItem", menuName = "Dialogs/Item")]
public class DialogItemSO : ScriptableObject
{
    [TextArea(3, 10)] [SerializeField] public string Text;
    [SerializeField] public DialogItemType Type;
}

public enum DialogItemType
{
    Buyer,
    Player,
}