using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int jumpcount = 0;
    int speed = 10;
    float zlimit = 0.8f;
    float xlimit = 5.8f;
    float planezlimit = 6.24f;
    int jumpforce = 10;
    bool touch = false;
    float gravityModifier = 2.5f;

    Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        jumping();
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        //if (touch == false)
        
            if (transform.position.z > zlimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zlimit);
            }
            else if (transform.position.z < -zlimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -zlimit);
            }


            if (transform.position.x < -xlimit)
            {
                transform.position = new Vector3(-xlimit, transform.position.y, transform.position.z);
            }
        
        


    }

    private void OnCollisionEnter(Collision collision)
    {
        jumpcount = 0;
        if (collision.gameObject.CompareTag("m"))
        {
            playerRB.transform.parent = collision.gameObject.transform;
        }

        
    }

    private void jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpcount < 1)
        {
            playerRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            jumpcount++;
        }

    }

    

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("m"))
        {
            playerRB.transform.parent = null;
        }
    }
}
