﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
public GameObject [] hazards;
public Vector3 spawnValues;
public int hazardCount;
public float spawnWait;
public float startWait;
public float waveWait;

public Text PointsText;
public Text restartText;
public Text gameOverText;
public Text winText;
public Text credits;

private bool gameOver;
private bool restart;
private int Points;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        credits.text = "";
        Points = 0;
        UpdatePoints();
        StartCoroutine(SpawnWaves());
    }
    
    void Update()
    {
        if (restart)
        {
         if (Input.GetKeyDown(KeyCode.Space))
          {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          }
        }

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    IEnumerator SpawnWaves()
{
yield return new WaitForSeconds(startWait);
while (true)
{
for (int i = 0; i < hazardCount; i++)
{
GameObject hazard = hazards[Random.Range (0, hazards.Length)];
Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
Quaternion spawnRotation = Quaternion.identity;
Instantiate(hazard, spawnPosition, spawnRotation);
yield return new WaitForSeconds(spawnWait);
}
yield return new WaitForSeconds(waveWait);

if (gameOver)
{
  restartText.text = "Press 'Space' to Restart";
  restart = true;
   break;
 }
 }
}

public void AddPoints(int newPointsValue)
{
        Points += newPointsValue;
        UpdatePoints();
}
    void UpdatePoints()
    {
        PointsText.text = "Points: " + Points;
        if (Points >= 100)
        {
            winText.text = "You win!";
            credits.text = "Created by Jhon Vergara, Thanks for playing!";
            gameOver = true;
            restart = true;            
        }
    }

    public void GameOver()
{
gameOverText.text = "Game Over!";
gameOver = true;
}
    
}
