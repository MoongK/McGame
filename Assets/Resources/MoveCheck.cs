﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCheck : MonoBehaviour {

    Animator anim;
    bool jumping = false;

    void Start () {
        anim = gameObject.GetComponent<Animator>();
	}
	
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if ((h != 0f || v != 0f) && !jumping)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);

        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);

        anim.SetFloat("isRunning", transform.parent.parent.GetComponent<GoodMover>().speed);

	}
}