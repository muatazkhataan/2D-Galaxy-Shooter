using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float speed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Move up at 10 speed
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // If position of the y of my laser is greater than or equal to 6
        // Destroy the laser

        if (transform.position.y >= 6)
        {
            Destroy(this.gameObject);
        }


    }
}
