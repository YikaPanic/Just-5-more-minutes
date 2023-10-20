using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutoTextDisplay : MonoBehaviour
{
    public Text textDisplay;
    public string[] paragraphs;
    public float textSpeed = 0.05f;
    public enum NextAction { LoadScene, HideTextAndLoadNext };
    public GameObject nextObjectToShow; // 下一个要显示的对象

    private int currentParagraphIndex = 0;
    private bool isDisplayingText = false;
    private bool showAllText = false;

    private void Start()
    {
        textDisplay.text = "";
        StartCoroutine(DisplayText(paragraphs[currentParagraphIndex]));
    }

    private void Update()
    {
        // 检测是否按下任意键
        if (Input.anyKeyDown)
        {
            if (!isDisplayingText)
            {
                // 如果不在显示文本，切换到下一个段落
                currentParagraphIndex++;

                if (currentParagraphIndex < paragraphs.Length)
                {
                    textDisplay.text = "";
                    StartCoroutine(DisplayText(paragraphs[currentParagraphIndex]));
                }
                else
                {
                    // 所有文字已显示完毕，根据选择执行下一步操作

                    if (nextObjectToShow != null)
                    {
                        nextObjectToShow.SetActive(true); // 显示下一个对象
                    }
                    this.gameObject.SetActive(false); // 隐藏文本对象
                }
            }
            else if (!showAllText)
            {
                // 如果正在显示文本，但未显示完毕，则显示所有文本
                StopAllCoroutines();
                textDisplay.text = paragraphs[currentParagraphIndex];
                showAllText = true;
            }
            else
            {
                // 如果已经完全显示文本，切换到下一个段落
                currentParagraphIndex++;
                showAllText = false;

                if (currentParagraphIndex < paragraphs.Length)
                {
                    textDisplay.text = "";
                    StartCoroutine(DisplayText(paragraphs[currentParagraphIndex]));
                }
                else
                {
                    // 所有文字已显示完毕，根据选择执行下一步操作

                    if (nextObjectToShow != null)
                    {
                        nextObjectToShow.SetActive(true); // 显示下一个对象
                    }
                    this.gameObject.SetActive(false); // 隐藏文本对象
                }
            }
        }
    }

    IEnumerator DisplayText(string paragraph)
    {
        isDisplayingText = true;

        for (int i = 0; i < paragraph.Length; i++)
        {
            if (!showAllText)
            {
                textDisplay.text += paragraph[i];
                yield return new WaitForSeconds(textSpeed);
            }
            else
            {
                textDisplay.text = paragraph; // 直接显示所有文本
                break;
            }
        }

        isDisplayingText = false;
    }
}
