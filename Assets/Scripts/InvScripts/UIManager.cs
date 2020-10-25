using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryMenu;
    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        inventoryControl();
    }

    void inventoryControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If game is paused press Esc again to resume the game
            if (GameManager.instance.isPaused)
            {
                Resume();
            }

            //If game is not paused --> pause it
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        inventoryMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f; // Real time is 1.0f
        GameManager.instance.isPaused = false;
    }

    void Pause()
    {
        inventoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f; // Stop the time
        GameManager.instance.isPaused = true;
    }
}
