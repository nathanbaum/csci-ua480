using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    public class TriggerTranslate : ITrigger
    {

        public bool grabbed = false;  // have i been picked up, or not?
        public float grabStrength = 10f;
        Quaternion initialRotation;
        Vector3 initialForward;
        float dist;
        Rigidbody rb;
        float initialDrag;
        callback closeMenu;
        setter setToggle;
        callback removeSelf;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            initialDrag = rb.drag;
        }

        // Update is called once per frame
        void Update()
        {
            if (grabbed)
            {
                // we can think of the grabbing as moving the cube along the line shooting out the camera
                float difference = Mathf.DeltaAngle(initialRotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.y)/10;
                // define goTo to be the vector that we want the cube to "go to" (i.e. where the camera is pointing)
                Vector3 goTo = initialForward * (dist + difference) + Camera.main.transform.position;
                // define delta to be the vector from the cube's current position to goTo
                Vector3 delta = (goTo - transform.position);
                // add a force in the direction of delta, scaled by our grabstrength
                rb.AddForce(delta * grabStrength);
                // add drag to the cube, scaled by how close it is to goTo
                rb.drag = grabStrength / delta.magnitude;
            }
        }

        public override string GetName()
        {
            return "Translate";
        }

        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while 
         * gaze is on this object.  Toggle grabbed state.
         */
        public override void Toggle()
        {
            if (grabbed)
            {  // now drop it
                removeSelf();
                grabbed = false;
                rb.useGravity = true;
                rb.drag = initialDrag;
            }
            else
            {   // pick it up:
                // dist is the distance from the camera to the cube
                removeSelf = setToggle(Toggle);
                closeMenu();
                dist = Vector3.Distance(transform.position, Camera.main.transform.position);
                initialRotation = Camera.main.transform.rotation;
                initialForward = Camera.main.transform.forward;
                grabbed = true;
                Debug.Log("turning off gravity");
                rb.useGravity = false;

            }
        }

        public override void setCallBacks(callback cb, setter set)
        {
            closeMenu = cb;
            setToggle = set;
        }
    }
}