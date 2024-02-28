using UnityEngine;
using UnityEngine.UIElements;

public class HandleScoreUI : MonoBehaviour
{
    [SerializeField] private UIDocument document;

    private Label _label;

    private void Start()
    {
        var rootElement = document.rootVisualElement;

        _label = rootElement.Q<Label>("LabelScoreValue");
    }

    public void UpdateScore(int aScore)
    {
        _label.text = aScore.ToString();
    }
}