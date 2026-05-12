using UnityEngine;

public class MemoryFragment : MonoBehaviour, IInteractable
{
    [TextArea(3,6)]
    public string memoryText = "She asked me at breakfast. I was already thinking about something else.";

    private UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void Interact()
    {
        uiManager.ShowMemory(memoryText);
        Destroy(gameObject, 0.1f);  // fragment disappears after interaction
    }

    public string GetPromptText()
    {
        return "[E]  Examine memory";
    }
}
