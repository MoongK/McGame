using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryUpdate : MonoBehaviour {

    Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
	}
	
	void Update () {
        //anim.SetBool("isGameOver", RetryMenu.isGameOver);
	}
}
