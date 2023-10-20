using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectsOnKeyPress : MonoBehaviour
{
    public enum KeyPressType
    {
        AnyKey,
        SpecificKey
    }

    public KeyPressType keyPressType = KeyPressType.AnyKey;
    public KeyCode specificKey = KeyCode.Space;
    public GameObject objectToShow;
    public GameObject objectToHide;
    
    public bool autoExecute = false; // 新增的自动执行选项

    private void Start()
    {
        if (autoExecute)
        {
            ToggleObjects();
        }
    }

    private void Update()
    {
        if (!autoExecute) // 如果不是自动执行模式，才响应按键
        {
            if (keyPressType == KeyPressType.AnyKey)
            {
                if (Input.anyKeyDown)
                {
                    ToggleObjects();
                }
            }
            else if (keyPressType == KeyPressType.SpecificKey)
            {
                if (Input.GetKeyDown(specificKey))
                {
                    ToggleObjects();
                }
            }
        }
    }

    private void ToggleObjects()
    {
        if (objectToShow != null)
        {
            objectToShow.SetActive(true);
        }

        if (objectToHide != null)
        {
            objectToHide.SetActive(false);
        }
    }
}


