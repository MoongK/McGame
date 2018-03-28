using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBlockMesh : MonoBehaviour {

    GameObject myblock, player;
    Object getUsingblock;
    GameObject usingblock;

    private void Start()
    {
        myblock = GameObject.FindGameObjectWithTag("handBlock");
        myblock.GetComponent<MeshRenderer>().enabled = false;
        myblock.transform.Find("Inblock").GetComponent<MeshRenderer>().enabled = false;
        myblock.transform.Find("Inblock").Find("Inblock2").GetComponent<MeshRenderer>().enabled = false;
    }

    void Update () {
        player = GameObject.FindGameObjectWithTag("MainCamera");
        getUsingblock = player.GetComponent<InteractionBlock>().block;

        if (getUsingblock == null)
        {
            myblock.GetComponent<MeshRenderer>().enabled = false;
            myblock.transform.Find("Inblock").GetComponent<MeshRenderer>().enabled = false;
            myblock.transform.Find("Inblock").Find("Inblock2").GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            myblock.GetComponent<MeshRenderer>().enabled = true;
            usingblock = getUsingblock as GameObject;

            if (usingblock.GetComponent<Renderer>() == null)
            {
                myblock.GetComponent<Renderer>().enabled = false;
                myblock.transform.Find("Inblock").GetComponent<MeshRenderer>().enabled = true;
                myblock.transform.Find("Inblock").Find("Inblock2").GetComponent<MeshRenderer>().enabled = true;

                myblock.transform.Find("Inblock").GetComponent<Renderer>().material.mainTexture
                    = usingblock.transform.GetChild(0).GetComponent<Renderer>().sharedMaterial.mainTexture;

                myblock.transform.Find("Inblock").Find("Inblock2").GetComponent<Renderer>().material.mainTexture
                    = usingblock.transform.GetChild(1).GetComponent<Renderer>().sharedMaterial.mainTexture;
            }
            else
                myblock.GetComponent<Renderer>().material.mainTexture = usingblock.GetComponent<Renderer>().sharedMaterial.mainTexture;
        }
    }
}
