using UnityEngine;
using UnityEngine.UIElements;

public class HandleUI : MonoBehaviour
{
    [SerializeField] private UIDocument document;

    private Label _labelScore;
    private Label _labelGameOver;
    private VisualElement _visualElementGameOver;

    private void Start()
    {
        var rootElement = document.rootVisualElement;

        _labelScore = rootElement.Q<Label>("LabelScoreValue");
        _labelGameOver = rootElement.Q<Label>("LabelGameOver");
        _visualElementGameOver = rootElement.Q<VisualElement>("VisualElementGameOver");
        _visualElementGameOver.visible = false;
    }

    public void UpdateScore(int aScore)
    {
        _labelScore.text = aScore.ToString();
    }

    public void ShowGameOver()
    {
        _visualElementGameOver.visible = true;
    }
}