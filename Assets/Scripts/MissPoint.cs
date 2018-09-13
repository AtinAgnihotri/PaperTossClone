using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissPoint : MonoBehaviour {

    SpawnBall spn;
    ScorePoint scr;

	// Use this for initialization
	void Start () {
        spn = GameObject.FindGameObjectWithTag("Bin").GetComponent<SpawnBall>();
        scr = GameObject.FindGameObjectWithTag("Hit").GetComponent<ScorePoint>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider ball)
    {
        if (ball.gameObject.tag == "Ball")
        {
            scr.ResetScore();
            Destroy(ball.gameObject);
            spn.Spawn();
        }
    }
}
