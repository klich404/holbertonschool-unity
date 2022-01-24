using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody ball; //ball = player
    public float speed = 700; //speed of the ball
    private int score = 0; //score = coins
    public int health = 5; //health of the ball
    public Text scoreText; // score text
    public Text healthText; //health text
    public Image WinBG; //Win image
    public Image LoseBG; //Lose image

    //excecution of the movement of the ball once per frame
    //Input.GetKey = receives the Key od the movement(WASD)
    //ball.AddForce(x, y, z) = move the ball accordint to Input.GetKey
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
            ball.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey("s"))
            ball.AddForce(0, 0, -speed * Time.deltaTime);
        if (Input.GetKey("d"))
            ball.AddForce(speed * Time.deltaTime, 0, 0);
        if (Input.GetKey("a"))
            ball.AddForce(-speed * Time.deltaTime, 0, 0);
    }

    //possible interaccions with other objs
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health--;
            SetHealthText();
        }
        if (other.tag == "Goal" && score == 20)
        {
            WinBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
        if (health == 0)
        {
            LoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
            health = 5;
            score = 0;
        }
    }

    // Update the score (count) text
    void SetScoreText()
    {
        scoreText.text = score.ToString();
    }

    // Update the healt (count) text
    void SetHealthText()
    {
        healthText.text = health.ToString();
    }

    // Reload the maze scene after 3 seconds of being called
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Maze", LoadSceneMode.Single);
        score = 0;
        health = 5;
    }
}
