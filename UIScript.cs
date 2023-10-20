using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public gameScript GMS;
    public Text timerText; // Reference to the UI Text element.
    private double timer = 0f;
    private bool gameIsRunning = true;
    float gameDuration = 15f;
    public Image gameOver;
    public Button retry;
    public Image winner;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        gameOver.enabled = false;
        retry.gameObject.SetActive(false);
        winner.enabled = false;



    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsRunning)
        {
           // Debug.Log(gameDuration);
            timer += Time.deltaTime;
            //Debug.Log("time ="+timer);
            // Check if the game duration has been reached.
            
            if (timer >= gameDuration)
            {
                gameOver.enabled = true;
                retry.gameObject.SetActive(true);
                gameIsRunning = false;
                Time.timeScale = 0f;
                Debug.Log("Game Over! Time's up!");
                // You can add any other game-ending logic here.
            }


            // Update the timer text on the UI.
            timerText.text = ""+Math.Round(gameDuration-timer);

            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube"); // Assuming cubes are tagged with "Cube."
            if (cubes.Length == 0)
            {
                gameIsRunning = false;
                Time.timeScale = 0f; // Freeze the game because there are no cubes left.

                retry.gameObject.SetActive(true);
                winner.enabled = true;

                Debug.Log("Game Over! No cubes left!");
            }

        }

        }
    public void retryActionButton() {
        Debug.Log("retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
}
