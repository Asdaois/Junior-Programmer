using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public UnityEvent<GameManager.Difficulty> OnGameStart;
    [SerializeField] private UIDocument HUDDocument;

    private Label labelScore;

    private void Start()
    {
        var HUDRoot = HUDDocument.rootVisualElement;

        labelScore = HUDRoot.Q<Label>("LS");
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void PresentScore(int aScore)
    {
        labelScore.text = $"SCORE: {aScore}";
    }
}