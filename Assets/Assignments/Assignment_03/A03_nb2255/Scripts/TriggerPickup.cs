using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    public class TriggerPickup : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ptr = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                if (Physics.Raycast(ptr, out hit))
                {
                    Debug.Log("hit a something within distance!");
                    PickupMe pickScript = hit.collider.gameObject.GetComponent<PickupMe>();
                    if (pickScript != null)
                    {
                        pickScript.PickupOrDrop();
                    }
                }

            }
        }
    }
}