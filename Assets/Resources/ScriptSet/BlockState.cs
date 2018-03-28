using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : MonoBehaviour {

    public Texture[] Cracks;
    public ParticleSystem Ef;
    int Statecounter;

    GameObject worldPool;

    private void Start()
    {
        worldPool = GameObject.Find("WorldPool");
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
            var ef = Instantiate(Ef, transform.position, Quaternion.identity);
            ef.GetComponent<Renderer>().material.mainTexture = gameObject.GetComponent<Renderer>().material.mainTexture;

            worldPool.GetComponent<WorldPooler>().Pooling(gameObject);
            Destroy(ef.gameObject, 2f);
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