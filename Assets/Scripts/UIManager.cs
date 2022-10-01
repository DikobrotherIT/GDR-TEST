using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _coinText;
    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private GameObject _loseScreen;

    public void AddCoin(int coins)
    {
        _coinText.text = coins.ToString();
    }

    public void ShowVictoryScreen()
    {
        FadeInPanel(_victoryScreen);
    }

    public void ShowLoseScreen()
    {
        FadeInPanel(_loseScreen);
    }

    private void FadeInPanel(GameObject panel)
    {
        panel.SetActive(true);
        panel.GetComponent<CanvasGroup>().DOFade(1, 1);
    }

    private void FadeOutPanel(GameObject panel)
    {
        panel.GetComponent<CanvasGroup>().DOFade(0, 1).OnComplete(() =>
        {
            panel.SetActive(false);
        });
    }
}
