using UnityEngine;
using System.Collections;

public class ctrls : MonoBehaviour
{

    public GameObject go_barrel;
    private Vector3 last_mp;

    // Use this for initialization
    void Start()
    {
        //go_barrel.transform.position = go_barrel_link.transform.position;
        last_mp = Input.mousePosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (last_mp != Input.mousePosition)
        {
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mp = new Vector3(mp.x, mp.y, go_barrel.transform.position.z) - go_barrel.transform.position;
            go_barrel.transform.up = mp;
            last_mp = Input.mousePosition;
        }
    }
}