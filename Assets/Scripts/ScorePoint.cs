using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScorePoint : MonoBehaviour {

    public int score;
    public Text scoreText;
    public Text bestText;
    SpawnBall spn;
    //int lastBest;

	// Use this for initialization
	void Start () {
        score = 0;
        spn = GameObject.FindGameObjectWithTag("Bin").GetComponent<SpawnBall>();
        if ((PlayerPrefs.GetInt("Best", 0)) == 0)
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
                //SaveScore(score);
                PlayerPrefs.SetInt("Best", score);
                bestText.text = "Best : " + PlayerPrefs.GetInt("Best");
                SendToAndroid(score, PlayerPrefs.GetInt("Best"));
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

    public void SaveScore(int s)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);

        PlayerData pd = new PlayerData();
        pd.bestScore = s;

        bf.Serialize(file, pd);
        file.Close();
    }

    public void LoadScore()
    {

    }

    public void SendToAndroid(int s, int b)
    {
        AndroidJavaClass send = new AndroidJavaClass("PlayerScoreData");
        AndroidJavaObject sendObject = new AndroidJavaObject("PlayerScoreData");
        sendObject.Set<int>("playerScore", s);
        sendObject.Set<int>("playerBestScore", b);
    }
}

[Serializable]
class PlayerData
{
    public int bestScore;
}
