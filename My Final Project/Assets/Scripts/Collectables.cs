using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private int _value = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("I've was hit by the player!");

            if(this.gameObject.CompareTag("Nom Nom"))
            {
                LevelManager.Instance.UpdateLevelFoodCount(_value);
            }

            Destroy(this.gameObject);
        }
    }
}
