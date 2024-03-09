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
    private Label labelTime;

    private void Start()
    {
        var HUDRoot = HUDDocument.rootVisualElement;

        labelScore = HUDRoot.Q<Label>("LS");
        labelTime = HUDRoot.Q<Label>("LT");

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

    public void PresentTime(int aTime)
    {
        labelTime.text = $"TIME: {aTime}";
    }

    public void ShowMenuScreen()
    {
        HUDDocument.rootVisualElement.visible = false;
        MenuDocument.rootVisualElement.visible = true;
    }

    public void ShowHUDScreen()
    {
        HUDDocument.rootVisualElement.visible = true;
        MenuDocument.rootVisualElement.visible = false;
    }
}