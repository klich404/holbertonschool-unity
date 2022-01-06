using System.Collections;
using System.Collections.Generic;
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
    public Text WinLoseT; //win or lose text
    public Image WinLoseBG; //win or lose background color

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
            //Debug.Log ("Score: " + score);
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health--;
            //Debug.Log ("Health " + health);
            SetHealthText();
        }
        if (other.tag == "Goal")
        {
            //Debug.Log ("You Win!");
            WinLoseT.text = "You Win!";
            WinLoseBG.color = Color.green;
            WinLoseT.color = Color.black;
            WinLoseBG.gameObject.SetActive(true);
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
            //Debug.Log ("Game Over!");
            WinLoseT.text = "Game Over!";
            WinLoseBG.color = Color.red;
            WinLoseT.color = Color.white;
            WinLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
            health = 5;
            score = 0;
        }
    }

    // Update the score (count) text
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Update the healt (count) text
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
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
