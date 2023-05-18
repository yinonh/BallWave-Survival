using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpwanManager : MonoBehaviour
{
    //public GameObject player;
    public bool start;
    public GameObject enemy;
    public GameObject powerUp;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI [] gameOverText;
    public TextMeshProUGUI titleText;
    public Button startButton;
    public Button restart;
    //public GameObject light;
    private int wave;
    // Start is called before the first frame update
    void Start()
    {
        //light.transform.Translate(0, 3, 0);
        //light.transform.Rotate(50, -30, 0);
        scoreText.text = "Wave: " + wave;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (FindObjectsOfType<EnemyMove>().Length == 0 && FindObjectsOfType<PlayerController>().Length != 0)
            {
                wave++;
                scoreText.text = "Wave: " + wave;
                //GameObject obj = powerUp[Random.Range(0, powerUp.Length)];
                Instantiate(powerUp, new Vector3(Random.Range(-8.0f, 8.0f), 0.4f, Random.Range(-8.0f, 8.0f)), powerUp.transform.rotation);
                for (int i = 0; i < wave; i++)
                    Instantiate(enemy, new Vector3(Random.Range(-8.0f, 8.0f), 0, Random.Range(-8.0f, 8.0f)), enemy.transform.rotation);
            }
            else if (FindObjectsOfType<PlayerController>().Length == 0)
            {
                scoreText.gameObject.SetActive(false);
                gameOverText[0].gameObject.SetActive(true);
                gameOverText[1].text = "You servived " + wave + " waves";
                gameOverText[1].gameObject.SetActive(true);
                restart.gameObject.SetActive(true);
            }
        }     
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        start = true;
        scoreText.gameObject.SetActive(true);
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
    }
}
