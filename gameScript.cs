using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Playables;

public class gameScript : MonoBehaviour

{
    public GameObject cube;
    public GameObject clynder;
    GameObject newVersionBall;
    public GameObject ball;
    public Transform PointInstatiateBall;
    public Transform pointCube;

    float shootPower = 0f;
    bool isChargingShot = false;
    float destroyDelay = 14f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shooting();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            clynder.transform.rotation = new Quaternion(clynder.transform.rotation.x, clynder.transform.rotation.y, clynder.transform.rotation.z - 0.05f, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            clynder.transform.rotation = new Quaternion(clynder.transform.rotation.x, clynder.transform.rotation.y, clynder.transform.rotation.z + 0.05f, 1);
            Debug.Log("clynder down");

        }
        if (pointCube.position.y < 23.4)
        {
            pointCube.position = new Vector3(pointCube.position.x, pointCube.transform.position.y + 5 * Time.deltaTime, pointCube.transform.position.z);
            //Debug.Log("up");


        }
        if (pointCube.position.y >= 23.4)
        {
            // Debug.Log("down");
           pointCube.position = new Vector3(pointCube.position.x, -39f , pointCube.position.z);

        }
    }
    public void shooting() {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("KeyBoard ON space");
            isChargingShot = true;
            shootPower += Time.deltaTime * 10f; // Increase shoot power gradually.
        }
        if (Input.GetKeyUp(KeyCode.Space) && isChargingShot)
        {
           
            // Reset variables for the next shot.
            newVersionBall = Instantiate(ball, PointInstatiateBall.position, PointInstatiateBall.rotation);
            Rigidbody rb = newVersionBall.GetComponent<Rigidbody>();

            // Calculate the velocity vector along the X-axis.
            Vector3 velocity = Vector3.left; // Assuming you want to shoot along the global X-axis.

            // Apply the velocity and adjust for shootPower.
            rb.velocity = velocity * 1000*shootPower * Time.deltaTime;
            Debug.Log("speed="+shootPower);
            isChargingShot = false;
            shootPower = 0f;
        }
    Destroy(newVersionBall, destroyDelay);


    }
   
}
