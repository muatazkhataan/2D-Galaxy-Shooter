using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool _canTripleShot;

    // Public or Private identify
    // Data type ( int , floats , bool , strings )
    // Every variable has a NAME
    // Option value assigned

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShotPrefab;

    // Fire rate is 0.25f
    // Can fire -- has the amount of time firing passed?
    // Time .time

    [SerializeField]
    private float _fireRate = 0.25f;

    [SerializeField]
    private float _canFire = 0.0f;

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private float _mouseSpeed = 15.0f;


    // Use this for initialization
    void Start()
    {
        // Current Position = New Position
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        // If Space key pressed
        // Spawn laser at Player position
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1"))
        {
            if (Time.time > _canFire)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        // if triple shot
        // shoot 3 laser
        // else
        // shoot 1

        if (Time.time > _canFire)
        {
            if (_canTripleShot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position , Quaternion.identity);
            }
            else
            {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            }
            _canFire = Time.time + _fireRate;
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticaltalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * _speed * verticaltalInput * Time.deltaTime);

        float mouseHorizontalInput = Input.GetAxis("Mouse X");
        float mouseVerticaltalInput = Input.GetAxis("Mouse Y");

        transform.Translate(Vector3.right * _mouseSpeed * mouseHorizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * _mouseSpeed * mouseVerticaltalInput * Time.deltaTime);



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
