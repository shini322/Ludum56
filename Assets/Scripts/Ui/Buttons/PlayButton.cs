using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>(); 
    }

    private void OnEnable()
    {
        button.onClick.AddListener(Play);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(Play);
    }

    private void Play()
    {
        SceneManager.LoadScene("GameScene");
    }
}