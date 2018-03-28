using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour {

    bool isInventory = false;

	void Start () {
        GameObject.Find("MyUI").transform.Find("Inventory").gameObject.SetActive(false);

    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.I))
            Inventory();
    }


    void Inventory()
    {
        GameObject.Find("MyUI").transform.Find("Inventory").gameObject.SetActive(!isInventory);
        isInventory = !isInventory;
        if(isInventory)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = enabled;
            gameObject.GetComponent<Crosshair>().enabled = false;
            GameObject.Find("FirstPersonCam").GetComponent<InteractionBlock>().enabled = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gameObject.GetComponent<Crosshair>().enabled = true;
            GameObject.Find("FirstPersonCam").GetComponent<InteractionBlock>().enabled = true;
        }
    }
}
