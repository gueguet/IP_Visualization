using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{

    public float playerSpeed;

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;



    // --------------------------------------------------------- //

    void Start()
    {

    }


    void Update()
    {




        rotatePlayer();
        mouvePlayer();


    }



    // ---------------- Player mouvement ----------------- //
    private void mouvePlayer()
    {
        if (Input.GetKey("w"))
        {
            gameObject.transform.position += transform.forward * Time.deltaTime * playerSpeed;
        }

        if (Input.GetKey("a"))
        {
            gameObject.transform.position -= transform.right * Time.deltaTime * playerSpeed;
        }

        if (Input.GetKey("d"))
        {
            gameObject.transform.position += transform.right * Time.deltaTime * playerSpeed;
        }

        if (Input.GetKey("s"))
        {
            gameObject.transform.position -= transform.forward * Time.deltaTime * playerSpeed;
        }
    }


    // ---------------- Player rotation ----------------- //
    private void rotatePlayer()
    {

        yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= speedH * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

}
