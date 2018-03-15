using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBlock : MonoBehaviour {

    public Object block;
    public int damagePow;
    int blockmask;

    private void Start()
    {
        damagePow = 10;
        blockmask = 1 << LayerMask.NameToLayer("Block");
    }

    void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 4f))
        {
            if (hit.collider.CompareTag("Block"))
            {
                if (Input.GetMouseButton(0))
                    hit.transform.gameObject.GetComponent<BlockState>().Cracking();
                else
                    hit.transform.gameObject.GetComponent<BlockState>().Regeneration();
            }
        }

        if (Physics.Raycast(ray, out hit, 4f, blockmask))
        {
            if (Input.GetMouseButtonDown(1)) {
                if (block != null)
                    Instantiate(block, hit.transform.position + hit.normal, Quaternion.identity);
            }  
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
            block = Resources.Load("DirtBlock");
        if(Input.GetKeyDown(KeyCode.Alpha2))
            block = Resources.Load("StoneBlock");

        if (Input.GetKeyDown(KeyCode.Alpha0))
            block = null;

    }
}
