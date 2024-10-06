using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>(); 
    }

    private void OnEnable()
    {
        button.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(Exit);
    }

    private void Exit()
    {
        Application.Quit();
    }
}