using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelService : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private DialogService dialogService;
    [SerializeField] private Shelf shelf;

    private void Awake()
    {
        button.interactable = false;
    }

    private void OnDisable()
    {
        shelf.WasUpdated -= UpdateButton;
        button.onClick.RemoveListener(End);
    }

    private void OnEnable()
    {
        shelf.WasUpdated += UpdateButton;
        button.onClick.AddListener(End);
    }

    private void End()
    {
        LevelService.Instance.NextBuyer();
        dialogService.ShowDialog(LevelService.Instance.CurrentBuyer.StartDialog);
        SceneManager.LoadScene("GameScene");
    }

    private void UpdateButton()
    {
        float maxCharm = 0;
        float targetAnimalCharm = 0;
        int count = 0;
        foreach (var (animalDrag, position) in shelf.animalToPositionMap)
        {
            count += 1;
            maxCharm = Mathf.Max(maxCharm, shelf.ShelfLotsMatrix[position.x, position.y].Charm);

            if (animalDrag.Animal.Type == LevelService.Instance.CurrentBuyer.AnimalWantToBuy)
            {
                targetAnimalCharm = shelf.ShelfLotsMatrix[position.x, position.y].Charm;
            }
        }
        button.interactable = !(count < 9 || targetAnimalCharm < maxCharm);
        Debug.Log(button.interactable);
    }
}