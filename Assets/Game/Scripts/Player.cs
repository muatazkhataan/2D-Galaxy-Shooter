using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Public or Private identify
    // Data type ( int , floats , bool , strings )
    // Every variable has a NAME
    // Option value assigned

    public GameObject laserPrefab;

        [SerializeField]
        private float speed = 5.0f;

	// Use this for initialization
	void Start () {
        // Current Position = New Position
        transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();

        // If Space key pressed
        // Spawn laser at Player position
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
        }

    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticaltalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticaltalInput * Time.deltaTime);

        // If Player on the y is greater than 0
        // Set Player position to 0

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        // If Player on the x is greater than 9.5
        // Set Player position to -9.5

        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }
}
