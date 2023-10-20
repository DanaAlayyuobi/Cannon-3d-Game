using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        

            // Destroy the cube and the ball upon collision.
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("colide");
        }
    
}
