using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFootsteps : MonoBehaviour
{
    private CharacterController controller;
    private FMOD.Studio.EventInstance foosteps;

    float timer = 0.0f;

    [SerializeField]
    float footstepSpeed = 0.3f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        Vector3 horizontalVelocity = controller.velocity;
        horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);

        // The speed on the x-z plane ignoring any speed
        float horizontalSpeed = horizontalVelocity.magnitude;
        if (horizontalSpeed >= 0.01f)
        {
            if (timer > footstepSpeed)
            {
                PlayFootstep();
                timer = 0.0f;
            }

            timer += Time.deltaTime;
        }
    }

    private void PlayFootstep()
    {
        foosteps = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps");
        foosteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        foosteps.start();
        foosteps.release();
    }
}
