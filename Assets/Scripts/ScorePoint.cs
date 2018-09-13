using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePoint : MonoBehaviour {

    public int score;
    public Text scoreText;
    public Text bestText;
    SpawnBall spn;
    int lastBest;

	// Use this for initialization
	void Start () {
        score = 0;
        spn = GameObject.FindGameObjectWithTag("Bin").GetComponent<SpawnBall>();
        if ((PlayerPrefs.GetInt("Best", 0)) != 0)
        {
            PlayerPrefs.SetInt("Best", 0);
            bestText.text = "Best : " + PlayerPrefs.GetInt("Best");
        }

        bestText.text = "Best : " + PlayerPrefs.GetInt("Best");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider ball)
    {
        Debug.Log(ball.gameObject.name);

        if (ball.gameObject.tag == "Ball")
        {
            score++;
            scoreText.text = "Score : " + score.ToString();

            if (score > (PlayerPrefs.GetInt("Best")))
            {
                PlayerPrefs.SetInt("Best", score);
                bestText.text = "Best : " + PlayerPrefs.GetInt("Best");
            }

            Destroy(ball.gameObject);
            spn.Spawn();
        }
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score : " + score.ToString();
    }
}
