using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    public class move : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if ( Input.GetMouseButton(0) )
            {
                Debug.Log("mouse button down!");
                Rigidbody rb = GetComponent<Rigidbody>();
                Vector3 direction = Camera.main.transform.rotation * Vector3.forward;
                rb.AddForce(direction);
            }
        }
    }
}