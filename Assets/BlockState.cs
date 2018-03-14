using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : MonoBehaviour {

    public Texture[] Cracks;
    public ParticleSystem Ef;
    int Statecounter;
    //float hardness;
    //bool isCracked = false;

	//void Start ()
 //   {
 //       Statecounter = 0;
 //       if (gameObject.name == "StoneBlock")
 //           hardness = 1f;
 //       else if (gameObject.name == "DirtBlock")
 //           hardness = 0.5f;
	//}

    //public void CrCracking()
    //{
    //    if(Input.GetMouseButton(0))
    //    if (!isCracked)
    //    {
    //        StartCoroutine(CrCrack());
    //    }
    //}

    //IEnumerator CrCrack()
    //{
    //    isCracked = true;
    //    while (isCracked)
    //    {
    //        yield return new WaitForSeconds(hardness);
    //        Statecounter++;
    //        transform.GetComponent<Renderer>().material.SetTexture("_DetailMask", Cracks[Statecounter]);
    //    }
    //}















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
            Destroy(gameObject);
            Destroy(ef.gameObject, 10f);
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


}
