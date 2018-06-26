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
        Rigidbody myRb;
        StrobeSelected strobe;
        float dist;

        // Use this for initialization
        void Start()
        {
            myRb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
        }

        // Update is called once per frame
        void Update()
        {
            if (grabbed) {
                //float dist = Vector3.Distance(transform.position, Camera.main.transform.position);
                //Debug.Log("Distance: " + dist);
                Vector3 goTo = Camera.main.transform.forward * dist + Camera.main.transform.position;
                Vector3 delta = (goTo - transform.position);
                Debug.Log("Delta: " + delta);
                GetComponent<Rigidbody>().AddForce( delta*grabStrength );
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
                GetComponent<Rigidbody>().useGravity = true;
            }
            else
            {   // pick it up:
                // make it move with gaze, keeping same distance from camera
                dist = Vector3.Distance(transform.position, Camera.main.transform.position);
                grabbed = true;
                strobe.trigger = true;   // turn on color strobe so we know we have it
                Debug.Log("turning off gravity");
                GetComponent<Rigidbody>().useGravity = false;

            }
        }
    }
}
