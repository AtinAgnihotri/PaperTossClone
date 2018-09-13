using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : MonoBehaviour {

    public float y;
    public float z;

	// Use this for initialization
	void Start () {
        y = 26f;
        z = 41f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShootBall()
    {   
        Rigidbody rb = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>();
        if (rb == null)
            Debug.Log("RB nahi mila isse");
        rb.isKinematic = false;
        rb.AddForce(0, y, z);
    }
}
