using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryMenu : MonoBehaviour {

    Button RetryButton, ExitButton;

    public static bool isGameOver = false; // GameMgr.isGameOver <-- 에 바로 엑세스 가능

    private void Awake()
    {
        RetryButton = GameObject.Find("ReButton").GetComponent<Button>();
        ExitButton = GameObject.Find("ExitButton").GetComponent<Button>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            Replaying();
    }

    public void Exiting()
    {
        Application.Quit();
    }

    public void Replaying()
    {
        SceneManager.LoadScene("McPlayer");
    }
}
