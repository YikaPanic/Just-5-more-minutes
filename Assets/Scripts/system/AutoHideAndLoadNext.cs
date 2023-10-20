using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHideAndLoadNext : MonoBehaviour
{
    public float delayTime = 2.0f; // 等待时间
    public GameObject currentObject; // 当前对象
    public GameObject nextObject; // 下一个对象

    private bool isWaiting = false;

    private void Start()
    {
        // 初始化，将下一个对象禁用
        if (nextObject != null)
        {
            nextObject.SetActive(false);
        }
    }

    private void Update()
    {
        // 如果不在等待状态，开始等待
        if (!isWaiting)
        {
            StartCoroutine(WaitAndHide());
        }
    }

    private IEnumerator WaitAndHide()
    {
        isWaiting = true;

        // 等待一定时间
        yield return new WaitForSeconds(delayTime);

        // 隐藏当前对象
        if (currentObject != null)
        {
            currentObject.SetActive(false);
        }

        // 显示下一个对象
        if (nextObject != null)
        {
            nextObject.SetActive(true);
        }

        isWaiting = false;
    }
}

