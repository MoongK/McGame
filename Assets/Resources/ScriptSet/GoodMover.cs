using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodMover : MonoBehaviour
{
    Vector3 MoveDirection;
    Rigidbody rg;
    GameObject mainCam;

    bool isGround;
    public float speed = 5f;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        isGround = true;
        mainCam = GameObject.Find("FirstPersonSight");
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        MoveDirection = new Vector3(h, 0f, v).normalized;
        MoveDirection = transform.TransformDirection(MoveDirection);

        if (Input.GetKey(KeyCode.LeftShift))
            speed = 10f;
        else
            speed = 5f;

        //transform.position = Vector3.MoveTowards(transform.position, transform.position + MoveDirection, speed * Time.deltaTime);
        rg.MovePosition(rg.position + MoveDirection * speed * Time.deltaTime);

        if (isGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rg.AddForce(Vector3.up * 300f);
                if (rg.velocity.y > 300f)
                    rg.velocity = new Vector3(rg.velocity.x, 300f, rg.velocity.z);
            }
        }

        Ray GroundChecker = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        Debug.DrawRay(GroundChecker.origin, GroundChecker.direction * 1f, Color.blue);

        int Raymask = 1 << LayerMask.NameToLayer("Block") | 1 << LayerMask.NameToLayer("Floor");

        if ((rg.velocity.y == 0f) || ((Physics.Raycast(GroundChecker, out hit, 1f, Raymask))))
            isGround = true;
        else
            isGround = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 4f, Color.red);

        if (-0.1f < rg.velocity.y && rg.velocity.y < 0f)
            rg.velocity = new Vector3(rg.velocity.x, 0f, rg.velocity.z);

    }
}
