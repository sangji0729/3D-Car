using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float move;
    public float moveSpeed;
    public float horizontalInput;
    public float turnSpeed;
    public Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forward = Input.GetButton("forward");
        bool backward = Input.GetButton("backward");
        bool right = Input.GetButton("right");
        bool left = Input.GetButton("left");
        
        horizontalInput = Input.GetAxis("Horizontal");
        move = Input.GetAxis("Vertical");
        
        if(forward == true)
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            rigid.AddForce(transform.forward * moveSpeed, ForceMode.Impulse);
            if(Input.GetKey(KeyCode.LeftShift))
            {
                rigid.AddForce(transform.forward * (moveSpeed * 1.5f), ForceMode.Impulse);
            }
            if(right == true)
            {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
                //rigid.AddForce(300, 0, 0, ForceMode.Impulse);
            }
            if(left == true)
            {
                transform.Rotate(Vector3.down, turnSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigid.AddForce(new Vector3(0, 0, 0), ForceMode.Impulse);
            }
        }
        if(backward == true)
        {
            //transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
            rigid.AddForce(-transform.forward * moveSpeed, ForceMode.Impulse);
            //if car goes back, right and left key will reverse
            if (right == true)
            {
                transform.Rotate(Vector3.down, turnSpeed * Time.deltaTime);
            }
            if (left == true)
            {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }
        }
       
    }
}
