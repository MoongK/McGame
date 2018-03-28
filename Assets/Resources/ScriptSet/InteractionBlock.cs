using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBlock : MonoBehaviour {

    public Object block;
    public int damagePow;
    int blockmask;

    GameObject worldPool;

    private void Start()
    {
        damagePow = 10;
        blockmask = 1 << LayerMask.NameToLayer("Block");

        worldPool = GameObject.Find("WorldPool");
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

            if (hit.collider.CompareTag("Plant"))
            {
                if (Input.GetMouseButton(0))
                {
                    //Destroy(hit.transform.gameObject);
                    worldPool.GetComponent<WorldPooler>().Pooling(hit.transform.gameObject);
                }
                else
                    return;
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
            block = Resources.Load("BlockInstance/DirtBlock");
        if(Input.GetKeyDown(KeyCode.Alpha2))
            block = Resources.Load("BlockInstance/StoneBlock");
        if(Input.GetKeyDown(KeyCode.Alpha3))
            block = Resources.Load("BlockInstance/hardBlock");
        if (Input.GetKeyDown(KeyCode.Alpha4))
            block = Resources.Load("BlockInstance/GrassBlock");
        if (Input.GetKeyDown(KeyCode.Alpha5))
            block = Resources.Load("BlockInstance/FlowerBlock");


        if (Input.GetKeyDown(KeyCode.Alpha0))
            block = null;
    }
}
