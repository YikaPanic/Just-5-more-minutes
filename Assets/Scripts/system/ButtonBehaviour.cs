using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject selectImage;
    public Vector3 selectImageOffset;
    public string sceneToLoad;

    protected virtual void Start()
    {
        selectImage.SetActive(false);
    }

    protected virtual void OnMouseEnter()
    {
        selectImage.SetActive(true); 

        
        Vector3 newPosition = transform.position + selectImageOffset;
        newPosition.x -= 1.0f; 
        selectImage.transform.position = newPosition;
    }

    protected virtual void OnMouseExit()
    {
        selectImage.SetActive(false);
    }

    protected virtual void OnMouseDown()
    {
        SwitchScene();
    }

    protected virtual void SwitchScene()
    {
        if (sceneToLoad == "quit")
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
        else
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

