using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    
    public float delta = 2.5f;//amount to move left and right from the start point
    public float speed = 2.0f;
    private Vector3 startpos;


    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 v = startpos;
         v.x += delta * Mathf.Sin(Time.time * speed);
         transform.position = v;
    }


}
