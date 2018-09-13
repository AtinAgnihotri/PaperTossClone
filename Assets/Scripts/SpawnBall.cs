using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBall : MonoBehaviour {

	[SerializeField]
	GameObject ball;
    GameObject fan;
    public Text windText;
    public Text yValue;
    public float fanSpeed;
    float y;

    void Start()
    {
        fan = GameObject.FindGameObjectWithTag("Fan");
        if (fan == null)
        { Debug.Log("loda"); }
        y = 2;
        // windText = GameObject.GetComponent<Text>();
        if (windText == null)
        {
            windText = GameObject.FindGameObjectWithTag("WindText").GetComponent<Text>();
        }
    }

	public void Spawn()
	{
		Instantiate (ball, new Vector3(0f, 1f, -8f), Quaternion.identity);
        SetFan();
	}

    public void SetFan()
    {
        fanSpeed = UnityEngine.Random.Range(0f, 5f);
        
        if (Math.Round(y) % 2 == 0)
        {

            /*if (windText == null)
            {
                Debug.Log("Nul kyu hai");
            }*/
            windText.text = "Wind : Left, " + fanSpeed.ToString("F2");
           // Debug.Log("Yaha Pahuch Gaye");
            fan.transform.position = new Vector3(-1.111f, 0.07f, -5.47f);
            fan.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else
        {
            windText.text = "Wind : Right, " + fanSpeed.ToString("F2");
            fan.transform.position = new Vector3(1.27f, 0.07f, -5.47f);
            fan.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }

        yValue.text = "yVal : " + Math.Round(y).ToString("F2");
        y = UnityEngine.Random.Range(0f, 10f);
    }
}
