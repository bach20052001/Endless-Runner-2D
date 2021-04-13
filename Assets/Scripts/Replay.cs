using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
    public void ReplayGame()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
