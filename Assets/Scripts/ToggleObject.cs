using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required for deselecting the button

public class ToggleObject : MonoBehaviour
{
    public GameObject targetObject;
    public Button toggleButton;

    public Color activeColor = Color.green;
    public Color inactiveColor = Color.red;

    void Start()
    {
        toggleButton.onClick.AddListener(ToggleActiveState);
        UpdateButtonColor();
    }

    void ToggleActiveState()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(!targetObject.activeSelf);
            UpdateButtonColor();
            
            // 🔹 Deselect the button to apply the new color immediately
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    void UpdateButtonColor()
    {
        if (toggleButton != null)
        {
            ColorBlock colors = toggleButton.colors;
            Color newColor = targetObject.activeSelf ? activeColor : inactiveColor;
            
            colors.normalColor = newColor;
            colors.highlightedColor = newColor * 1.2f;
            colors.pressedColor = newColor * 0.8f;
            colors.selectedColor = newColor;

            toggleButton.colors = colors;
            
            // 🔹 Force the button to refresh its state
            toggleButton.interactable = false;
            toggleButton.interactable = true;
        }
    }
}
