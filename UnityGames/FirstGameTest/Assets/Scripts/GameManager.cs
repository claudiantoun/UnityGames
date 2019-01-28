using UnityEngine;
// u need this to load scenes in Restart().
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1f; 
    bool hasFallen = false;
    public GameObject completeLevelUI;

    public void EndGame()
    {
        if (hasFallen == false)
        {
            hasFallen = true;
            // The function Invoke creates a delay before calling the function
            // written between "".
            Invoke("Restart", restartDelay);
        }

    }

    public void LevelComplete()
    {
        completeLevelUI.SetActive(true);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
	
}
