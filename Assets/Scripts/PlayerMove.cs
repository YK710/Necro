using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 nowPos;
    public float movePower;
    public float jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        nowPos = transform.position;

        if(Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(nowPos + new Vector3(movePower, 0f, 0f));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(nowPos - new Vector3(movePower, 0f, 0f));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector3(0f, jumpPower, 0f), ForceMode.Impulse);
        }
    }
}
