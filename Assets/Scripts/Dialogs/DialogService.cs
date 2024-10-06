using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogService : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogTextMesh;
    [SerializeField] private Button nextButton;
    [SerializeField] private RectTransform container;
    [SerializeField] private AudioClip doorClip;
    [SerializeField] private AudioClip stepsClip;
    
    private DialogSO currentDialog;
    private int dialogItemIndex;

    private void Start()
    {
        dialogTextMesh.text = "";
        StartCoroutine(PlayerSounds());
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
        AudioService.Instance.ChangeMusicVolume(.5f);
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

    private IEnumerator PlayerSounds()
    {
        yield return new WaitForSeconds(.2f);
        AudioService.Instance.PlayerMusic();
        AudioService.Instance.ChangeMusicVolume(.2f);
        AudioService.Instance.PlayOneShot(doorClip);
        yield return new WaitForSeconds(doorClip.length);
        AudioService.Instance.PlayOneShot(stepsClip);
        yield return new WaitForSeconds(stepsClip.length);
        ShowDialog(LevelService.Instance.CurrentBuyer.StartDialog);
    }
}