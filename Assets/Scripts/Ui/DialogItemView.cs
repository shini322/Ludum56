using TMPro;
using UnityEngine;

public class DialogItemView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogTextMesh;
    [SerializeField] private TextMeshProUGUI dialogCharacterTextMesh;

    public void SetText(string text, string characterName)
    {
        dialogTextMesh.text = text;
        dialogCharacterTextMesh.text = characterName;
    }
}