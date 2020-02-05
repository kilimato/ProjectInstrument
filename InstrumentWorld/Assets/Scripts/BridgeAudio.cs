using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeAudio : MonoBehaviour
{
    public AudioSource rockBridge;

    // Start is called before the first frame update
    void Start()
    {
        rockBridge = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay (Collision collision)
    {
        rockBridge.Play();
    }
}
