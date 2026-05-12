using UnityEngine;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public float interactRange = 2.5f;
    public TextMeshProUGUI promptText;   // drag a UI Text here in Inspector
    public KeyCode interactKey = KeyCode.E;

    private IInteractable currentTarget;

    void Update()
    {
        // Cast a sphere around Elias to find nearby interactables
        Collider[] hits = Physics.OverlapSphere(
            transform.position, interactRange);

        currentTarget = null;

        foreach (Collider hit in hits)
        {
            IInteractable interactable = hit.GetComponent<IInteractable>();
            if (interactable != null)
            {
                currentTarget = interactable;
                break;
            }
        }

        // Show or hide the prompt
        if (promptText != null)
            promptText.gameObject.SetActive(currentTarget != null);

        if (currentTarget != null)
        {
            if (promptText != null)
                promptText.text = currentTarget.GetPromptText();

            if (Input.GetKeyDown(interactKey))
                currentTarget.Interact();
        }
    }
}
