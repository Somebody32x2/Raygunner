using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPaused = true;
    public static bool isGameOver = false;
    public static bool isSelectingDifficulty = true;
    public static int difficulty = 0;
    public static GameObject difficultyMenu;
    public static GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        difficultyMenu = GameObject.Find("DifficultyScreen");
        pauseMenu = GameObject.Find("PauseScreen");
        pauseMenu.SetActive(!isSelectingDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void setPause(bool state)
    {
        if (state)
        {
            // Release the mouse
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.SetActive(true);
            
        }
        else
        {
            // Lock the mouse
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenu.SetActive(false);
        }
        isPaused = state;
    }

    public void SelectDifficulty(int d)
    {
        difficulty = d;
        setPause(false);
        difficultyMenu.SetActive(false);
        isSelectingDifficulty = false;
    }
}
