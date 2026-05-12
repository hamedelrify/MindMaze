using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject memoryPanel;
    public TextMeshProUGUI memoryText;

    void Awake()
    {
        Instance = this;
        memoryPanel.SetActive(false);
    }

    public void ShowMemory(string text)
    {
        memoryText.text = text;
        memoryPanel.SetActive(true);
        StartCoroutine(HideAfterDelay(5f));
    }

    IEnumerator HideAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        memoryPanel.SetActive(false);
    }
}
