using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : MonoBehaviour {

    public Texture[] Cracks;
    public ParticleSystem Ef;
    int Statecounter;
    public bool isLinkedButton = false;

    GameObject worldPool;
    GameObject myChild;

    private void Start()
    {
        worldPool = GameObject.Find("WorldPool");
        myChild = transform.GetChild(0).gameObject;
        myChild.SetActive(false);
    }

    public void Cracking()
    {
        Invoke("cracker", 0f);
        CancelInvoke("generator");
    }

    void cracker()
    {
        Statecounter++;

        if (Statecounter == Cracks.Length)
        {
            var ef = Instantiate(Ef, transform.position, Quaternion.identity); // making effect 
            ef.GetComponent<Renderer>().material.mainTexture = gameObject.GetComponent<Renderer>().material.mainTexture; // effect renderer

            myChild.SetActive(true);
            myChild.transform.GetChild(0).GetComponent<BlockItem>().DropItem();
            worldPool.GetComponent<WorldPooler>().Pooling(gameObject); // Go to WorldPool
            Destroy(ef.gameObject, 2f); // destroy effect
        }
        else
            transform.GetComponent<Renderer>().material.SetTexture("_DetailMask", Cracks[Statecounter]);
    }

    public void Regeneration()
    {
        Invoke("generator", 0.3f);
    }

    void generator()
    {
        Statecounter = 0;
        transform.GetComponent<Renderer>().material.SetTexture("_DetailMask", Cracks[Statecounter]);
    }

    private void OnMouseExit()
    {
        Invoke("generator", 0.3f);
    }
}