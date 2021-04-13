using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private PlayerController player;
    private UIController UI;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public GameBaseState GameState;

    public void TransitionState(GameBaseState newGameState)
    {
        switch (newGameState)
        {
            case GameBaseState.PREGAME:
                PreGame();
                break;
            case GameBaseState.PLAY:
                Play();
                break;
            case GameBaseState.PAUSE:
                Pause();
                break;
            case GameBaseState.GAMEOVER:
                GameOver();
                break;
        }

        GameState = newGameState;
    }

    public void OnStateButtonClick()
    {
        if (GameState == GameBaseState.PLAY)
        {
            TransitionState(GameBaseState.PAUSE);
        }
        else
            if (GameState == GameBaseState.PAUSE)
        {
            TransitionState(GameBaseState.PLAY);
        }
    }

    private void GameOver()
    {
        UI.GameOver();
    }

    private void Play()
    {
        UI.GameStateActive();
        Time.timeScale = 1;
    }

    private void Pause()
    {
        UI.GameStateActive();
        Time.timeScale = 0;
    }

    private void PreGame()
    {
        StartCoroutine(PregameHandler());
    }

    private IEnumerator PregameHandler()
    {
        yield return new WaitForSeconds(3);
        player.gameObject.SetActive(true);
        TransitionState(GameBaseState.PLAY);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        UI = FindObjectOfType<UIController>();

        TransitionState(GameBaseState.PREGAME);

        if (instance == null)
        {
            instance = this;
        }
        if (this != instance)
        {
            Destroy(gameObject);
        }

        player.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameState == GameBaseState.PLAY)
            {
                TransitionState(GameBaseState.PAUSE);
            }
            else 
            if (GameState == GameBaseState.PAUSE)
            {
                TransitionState(GameBaseState.PLAY);
            }
        }
    }
}
