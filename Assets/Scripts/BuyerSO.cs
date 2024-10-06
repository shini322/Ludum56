using UnityEngine;

[CreateAssetMenu(fileName = "_Buyer", menuName = "Buyer")]

public class BuyerSO : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public AnimalType AnimalWantToBuy;
    [SerializeField] public DialogSO StartDialog;
}