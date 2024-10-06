using UnityEngine;
using UnityEngine.UI;

public class EndLevelService : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private DialogService dialogService;

    private void OnDisable()
    {
        button.onClick.RemoveListener(End);
    }

    private void OnEnable()
    {
        button.onClick.AddListener(End);
    }

    private void End()
    {
        LevelService.Instance.NextBuyer();
        dialogService.ShowDialog(LevelService.Instance.CurrentBuyer.StartDialog);
    }
}