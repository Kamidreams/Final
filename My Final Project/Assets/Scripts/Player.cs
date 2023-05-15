using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        float horizontalInput = Input.GetAxis("Horizontal");

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

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Platform")
        {
            Debug.Log ("On platform");
            transform.parent = other.transform;
        }

        if(other.gameObject.CompareTag("Spikes"))    
        {
            LevelManager.Instance.GameOver();
        }

        if(other.gameObject.CompareTag("Rats"))    
        {
            LevelManager.Instance.GameOver();
        }

        if(other.gameObject.CompareTag("Nom Nom"))
            {
                if(LevelManager.Instance._foodCollected >=10)
                {
                   LevelManager.Instance.Winner();
                }
            }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }
}
