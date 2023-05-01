using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4.0f;
    public float rotationSpeed = 10f;

    private Rigidbody _playerRb;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
		    transform.position += Vector3.right * speed * Time.deltaTime;
	    }
	if (Input.GetKey(KeyCode.LeftArrow))
        {
		    transform.position += Vector3.left* speed * Time.deltaTime;
	    }
	if (Input.GetKey(KeyCode.UpArrow))
        {
		    transform.position += Vector3.forward * speed * Time.deltaTime;
	    }
	if (Input.GetKey(KeyCode.DownArrow))
        {
		    transform.position += Vector3.back* speed * Time.deltaTime;
	    }
    }

    void Movement()
    {
        float xValue = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zValue = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(xValue, 0f, zValue);
    }
}
