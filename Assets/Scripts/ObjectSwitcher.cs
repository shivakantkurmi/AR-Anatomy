using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject[] objects; // Array of GameObjects to toggle
    public TextMeshProUGUI[] texts; // Array of Texts corresponding to each GameObject
    public Button forwardButton; // Button to activate next object
    public Button backwardButton; // Button to activate previous object
    private int currentIndex = -1;

    void Start()
    {
        if (objects.Length > 0)
        {
            SetActiveObject(0); // Start by activating the first object
        }
        
        forwardButton.onClick.AddListener(ActivateNext);
        backwardButton.onClick.AddListener(ActivatePrevious);
    }

    void ActivateNext()
    {
        if (objects.Length == 0) return;
        int nextIndex = (currentIndex + 1) % objects.Length;
        SetActiveObject(nextIndex);
    }

    void ActivatePrevious()
    {
        if (objects.Length == 0) return;
        int prevIndex = (currentIndex - 1 + objects.Length) % objects.Length;
        SetActiveObject(prevIndex);
    }

    void SetActiveObject(int index)
    {
        // Deactivate all GameObjects and texts
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
            if (texts.Length > i) texts[i].gameObject.SetActive(false); // Make sure the text is hidden
        }
        
        // Activate the selected GameObject and corresponding text
        objects[index].SetActive(true);
        if (texts.Length > index) texts[index].gameObject.SetActive(true); // Show corresponding text

        currentIndex = index;
    }
}
