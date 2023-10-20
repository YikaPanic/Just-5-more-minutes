using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Button returnButton;

    private void Start()
    {
        if (returnButton)
        {
            returnButton.onClick.AddListener(LoadStartScene);
        }
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
