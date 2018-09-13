using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeScript : MonoBehaviour {

	Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction

	[SerializeField]
	float throwForceInXandY = 1f; // to control throw force in X and Y directions

	[SerializeField]
	float throwForceInZ = 20f; // to control throw force in Z direction

    //public Text xDist;
    public Text debug;

    public SpawnBall spn;



	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
        if (spn == null)
        {
            spn = GameObject.FindGameObjectWithTag("Bin").GetComponent<SpawnBall>();
        }
        if (spn == null)
        {
            Debug.Log("Abb Kyu Null hai");
            spn.SetFan();
        }
        debug = GameObject.FindGameObjectWithTag("ScreenDebug").GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {

        if ((rb.isKinematic == false) && (rb != null))
        {
           // rb.AddForce(spn.fanSpeed * 5 , 0f, 0f);
            rb.AddForce(spn.fanSpeed * 2, 0f, 0f);
        }

        // if you touch the screen
        if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {

			// getting touch position and marking time when you touch the screen
			touchTimeStart = Time.time;
			startPos = Input.GetTouch (0).position;
           /* if (xDist == null)
            {
                xDist = GameObject.FindGameObjectWithTag("xDist").GetComponent<Text>();
            }*/
		}

		// if you release your finger
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) {

			// marking time when you release it
			touchTimeFinish = Time.time;

			// calculate swipe time interval 
			timeInterval = touchTimeFinish - touchTimeStart;

			// getting release finger position
			endPos = Input.GetTouch (0).position;

			// calculating swipe direction in 2D space
			direction = startPos - endPos;
           // xDist.text = "x : " + direction.x.ToString("F2");
            if (direction.y != 0f)
            {
                // add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces
                rb.isKinematic = false;
                //rb.AddForce (- direction.x * throwForceInXandY, - direction.y * throwForceInXandY, throwForceInZ / timeInterval);
                rb.AddForce((-direction.x * throwForceInXandY) /*- (spn.fanSpeed * 10)*/, 260f, 410f);
                debug.text = "First Addforce toh ho raha hai!";
            }
			

            // Destroy ball in 4 seconds
            //Destroy (gameObject, 3f);

		}

        
			
	}

    public void StraightShoot()
    {
        rb.AddForce(0f, 260f, 410f);
    }
}
