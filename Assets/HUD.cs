using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance;
    public void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public Image InteractablePrompt;

    public bool IsHighlightingInteractable = false;

    // Update is called once per frame
    void Update()
    {
        InteractablePrompt.enabled = IsHighlightingInteractable;
    }
    void LateUpdate()
    {
        IsHighlightingInteractable=false;
    }
}
