using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject[] menuOptions; 
    public GameObject selectionBox; 
    private int currentSelection = 0;

    private void Start()
    {
        UpdateSelectionBox();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && currentSelection > 0)
        {
            currentSelection--;
            UpdateSelectionBox();
        }
        else if (Input.GetKeyDown(KeyCode.S) && currentSelection < menuOptions.Length - 1)
        {
            currentSelection++;
            UpdateSelectionBox();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            SelectOption();
        }
    }

    private void UpdateSelectionBox()
    {
        selectionBox.transform.position = menuOptions[currentSelection].transform.position;
    }

    private void SelectOption()
    {
        switch (currentSelection)
        {
            case 0: // Start
                SceneManager.LoadScene("GameScene");
                break;
            case 1: // Setting
                SceneManager.LoadScene("SettingsScene");
                break;
            case 2: // Quit
                Application.Quit();
                break;
        }
    }
}
