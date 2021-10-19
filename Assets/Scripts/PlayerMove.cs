using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    public float movePower;
    public float limitSpeed;
    public float jumpPower;
    private bool isJump;
    public float addGra;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        //移動入力
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(movePower, 0f, 0f), ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-movePower, 0f, 0f), ForceMode.Force);
        }
        if (Input.GetKeyDown(KeyCode.W) && isJump == false)
        {
            rb.AddForce(new Vector3(0f, jumpPower, 0f), ForceMode.Impulse);
            isJump = true;
        }

        //速度等制御
        if (rb.velocity.x >= limitSpeed)
        {
            rb.velocity = new Vector3(limitSpeed, rb.velocity.y, 0f);
        }
        if (rb.velocity.x <= -limitSpeed)
        {
            rb.velocity = new Vector3(-limitSpeed, rb.velocity.y, 0f);
        }

        if(isJump == false)
        {
            if (Input.GetKeyUp(KeyCode.D))
            {
                rb.velocity = new Vector3(rb.velocity.x / 3f, rb.velocity.y, 0f);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                rb.velocity = new Vector3(rb.velocity.x / 3f, rb.velocity.y, 0f);
            }
        }

        if (isJump == true)
        {
            rb.AddForce(new Vector3(0f, -addGra, 0f), ForceMode.Force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
}
