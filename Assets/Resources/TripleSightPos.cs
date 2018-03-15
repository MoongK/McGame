using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleSightPos : MonoBehaviour {

    Transform playerPos;
    Vector3 dir;

	void Awake () {
        playerPos = GameObject.Find("Player").transform;
        dir = (playerPos.position - transform.position);

	}
	
	void Update () {

        transform.position = playerPos.position - dir;
	}
}
