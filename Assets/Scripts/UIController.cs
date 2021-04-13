using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private GameObject countDown;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject resumePanel;
    [SerializeField] private GameObject gameoverPanel;
    
    // Start is called before the first frame update
    [SerializeField]
    private void Start()
    {
        scorePanel.SetActive(true);
        countDown.SetActive(true);
        pauseButton.SetActive(true);
        resumePanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    public void GameStateActive()
    {
        if (GameManager.Instance.GameState == GameBaseState.PLAY)
        {
            resumePanel.SetActive(true);
        }
        else
        if (GameManager.Instance.GameState == GameBaseState.PAUSE)
        {
            resumePanel.SetActive(false);
        }
    }

    public void GameOver()
    {
        gameoverPanel.SetActive(true);
    }
}
