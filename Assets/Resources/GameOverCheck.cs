using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCheck : MonoBehaviour {

    Transform player, floor;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        floor = GameObject.Find("Floor").transform;
    }

    void Update () {
        if (player.position.y < floor.position.y - 30f)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("RetryScene");
        }
	}
}
