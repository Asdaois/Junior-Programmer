using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [System.Serializable] public class UserChangeDifficultyEvent : UnityEvent<GameManager.Difficulty> { }

    public UserChangeDifficultyEvent OnGameStart;
    [SerializeField] private UIDocument HUDDocument;
    [SerializeField] private UIDocument MenuDocument;

    private Label labelScore;

    private void Start()
    {
        var HUDRoot = HUDDocument.rootVisualElement;

        labelScore = HUDRoot.Q<Label>("LS");

        var MenuRoot = MenuDocument.rootVisualElement;

        MenuRoot.Q<Button>("BE").clicked += () =>
        {
            Debug.Log("??");
            OnGameStart.Invoke(GameManager.Difficulty.Easy);
        }; ;
        MenuRoot.Q<Button>("BM").clicked += () =>
        {
            OnGameStart.Invoke(GameManager.Difficulty.Medium);
        };
        MenuRoot.Q<Button>("BH").clicked += () =>
        {
            OnGameStart.Invoke(GameManager.Difficulty.Hard);
        };
    }

    public void PresentScore(int aScore)
    {
        labelScore.text = $"SCORE: {aScore}";
    }

    public void ShowMenuScreen()
    {
        HUDDocument.enabled = false;
        MenuDocument.enabled = true;
    }

    public void ShowHUDScreen()
    {
        HUDDocument.enabled = true;
        MenuDocument.enabled = false;
    }
}