using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBlockMesh : MonoBehaviour {

    GameObject myblock, sight;
    Object getUsingblock;
    GameObject usingblock;

    private void Start()
    {
        myblock = GameObject.FindGameObjectWithTag("handBlock");
        myblock.GetComponent<MeshRenderer>().enabled = false;
    }

    void Update () {
        sight = GameObject.FindGameObjectWithTag("MainCamera");
        getUsingblock = sight.GetComponent<InteractionBlock>().block;

        if (getUsingblock == null)
            myblock.GetComponent<MeshRenderer>().enabled = false;
        else
        {
            myblock.GetComponent<MeshRenderer>().enabled = true;
            usingblock = getUsingblock as GameObject;
            myblock.GetComponent<Renderer>().material.mainTexture = usingblock.GetComponent<Renderer>().sharedMaterial.mainTexture;
        }
    }
}
