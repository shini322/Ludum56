using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogService : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogTextMesh;
    [SerializeField] private Button nextButton;
    [SerializeField] private RectTransform container;
    
    private DialogSO currentDialog;
    private int dialogItemIndex;

    private void Start()
    {
        ShowDialog(LevelService.Instance.CurrentBuyer.StartDialog);
    }

    public void NextDialog()
    {
        if (currentDialog == null)
        {
            return;
        }
        
        if (currentDialog.Items.Count < dialogItemIndex + 1)
        {
            return;
        }
        
        dialogTextMesh.text = currentDialog.Items[dialogItemIndex].Text;
        dialogItemIndex += 1;

        if (currentDialog.Items.Count < dialogItemIndex + 1)
        {
            EndDialog();
        }
    }

    public void ShowDialog(DialogSO dialog)
    {
        currentDialog = dialog;
        dialogItemIndex = 0;
        EnableDialog();
        NextDialog();
    }

    private void EndDialog()
    {
        dialogTextMesh.text = "";
        DisableDialog();
    }

    private void EnableDialog()
    {
        container.gameObject.SetActive(true);
        nextButton.onClick.AddListener(NextDialog);
    }
    
    private void DisableDialog()
    {
        nextButton.onClick.RemoveListener(NextDialog);
        container.gameObject.SetActive(false);
    }
}