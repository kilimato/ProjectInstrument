using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeAnimation : MonoBehaviour
{
    public Animation anim;
    public Camera mcamera;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            anim.Play();
        }
    }
}
