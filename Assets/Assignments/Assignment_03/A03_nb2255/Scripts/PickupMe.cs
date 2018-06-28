using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    /***
     * PickupMe component allows user to select this object and 
     * move it with their gaze
     ******/
    public class PickupMe : MonoBehaviour
    {
        public bool grabbed = false;  // have i been picked up, or not?
        public float grabStrength = 10f;
        StrobeSelected strobe;
        float dist;
        Rigidbody rb;
        float initialDrag;


        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
            initialDrag = rb.drag;
        }

        // Update is called once per frame
        void Update()
        {
            if (grabbed) {
                // we can think of the grabbing as moving the cube along the surface of a sphere with radius dist
                // define goTo to be the vector that we want the cube to "go to" (i.e. where the camera is pointing)
                Vector3 goTo = Camera.main.transform.forward * dist + Camera.main.transform.position;
                // define delta to be the vector from the cube's current position to goTo
                Vector3 delta = (goTo - transform.position);
                // add a force in the direction of delta, scaled by our grabstrength
                rb.AddForce( delta*grabStrength );
                // add drag to the cube, scaled by how close it is to goTo
                rb.drag = grabStrength / delta.magnitude;
            }
        }

        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while 
         * gaze is on this object.  Toggle grabbed state.
         */
        public void PickupOrDrop()
        {
            if (grabbed)
            {  // now drop it
                grabbed = false;
                strobe.trigger = false;
                rb.useGravity = true;
                rb.drag = initialDrag;
            }
            else
            {   // pick it up:
                // dist is the distance from the camera to the cube
                dist = Vector3.Distance(transform.position, Camera.main.transform.position);
                grabbed = true;
                strobe.trigger = true;   // turn on color strobe so we know we have it
                Debug.Log("turning off gravity");
                rb.useGravity = false;

            }
        }
    }
}
