using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnKeyPress : MonoBehaviour
{
    public enum KeyPressType
    {
        AnyKey,
        SpecificKey
    }

    public KeyPressType keyPressType = KeyPressType.AnyKey; // 选择按下特定键或任意键
    public KeyCode specificKey = KeyCode.Space; // 用于选择特定键的键值
    public string targetSceneName = "YourSceneName"; // 设置目标场景名称

    private void Update()
    {
        if (keyPressType == KeyPressType.AnyKey)
        {
            // 检测是否按下任意键或点击鼠标任意键
            if (Input.anyKeyDown)
            {
                // 使用 SceneManager 加载目标场景
                SceneManager.LoadScene(targetSceneName);
            }
        }
        else if (keyPressType == KeyPressType.SpecificKey)
        {
            // 检测是否按下特定键
            if (Input.GetKeyDown(specificKey))
            {
                // 使用 SceneManager 加载目标场景
                SceneManager.LoadScene(targetSceneName);
            }
        }
    }
}
