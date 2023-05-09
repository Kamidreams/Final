using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     public Transform[] PatrolPoints;
    public float movespeed = 10;
    public float StartWaitTime;

    private int _currentPointIndex;
    private float _waitTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = PatrolPoints[0].position;
        _waitTime = StartWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = Vector3.MoveTowards(transform.position, PatrolPoints[_currentPointIndex].position, movespeed * Time.deltaTime);
        if (transform.position == PatrolPoints[_currentPointIndex].position)
        {
            if (_waitTime <= 0)
            {
                if (_currentPointIndex + 1 < PatrolPoints.Length)
                {
                    _currentPointIndex++;
                }
                else
                {
                    _currentPointIndex = 0;
                }
                _waitTime = StartWaitTime;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
        else
        {
            transform.rotation = PatrolPoints[_currentPointIndex].rotation;
        }
    }
}
