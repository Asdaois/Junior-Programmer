using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class HandleUI : MonoBehaviour
{
    [Serializable] public class UserChangeDifficultyEvent : UnityEvent<GameManager.Difficulty> { }

    [SerializeField] private UIDocument UIHUD;
    [SerializeField] private UIDocument UITitleScreen;

    [SerializeField] private UserChangeDifficultyEvent userRequestChangeDifficulty;

    private Label _labelScore;
    private VisualElement _visualElementGameOver;

    private void Start()
    {
        var HUDRootElement = UIHUD.rootVisualElement;

        _labelScore = HUDRootElement.Q<Label>("LabelScoreValue");
        _visualElementGameOver = HUDRootElement.Q<VisualElement>("VisualElementGameOver");
        _visualElementGameOver.visible = false;

        var TitleRootElement = UITitleScreen.rootVisualElement;

        TitleRootElement.Q<Button>("ButtonEasy").clicked += () =>
        {
            userRequestChangeDifficulty.Invoke(GameManager.Difficulty.Easy);
        };
        TitleRootElement.Q<Button>("ButtonMedium").clicked += () =>
        {
            userRequestChangeDifficulty.Invoke(GameManager.Difficulty.Medium);
        };
        TitleRootElement.Q<Button>("ButtonHard").clicked += () =>
        {
            userRequestChangeDifficulty.Invoke(GameManager.Difficulty.Hard);
        };
    }

    public void UpdateScore(int aScore)
    {
        _labelScore.text = aScore.ToString();
    }

    public void TitleScreen()
    {
        UITitleScreen.rootVisualElement.visible = true;
        UIHUD.rootVisualElement.visible = false;
    }

    public void InitGame()
    {
        UITitleScreen.rootVisualElement.visible = false;
        UIHUD.rootVisualElement.visible = true;
    }

    public void ShowGameOver()
    {
        _visualElementGameOver.visible = true;
    }
}