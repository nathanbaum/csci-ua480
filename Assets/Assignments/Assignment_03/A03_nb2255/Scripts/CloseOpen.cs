using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    public class CloseOpen : MonoBehaviour
    {

        public GameObject menu;
        bool triggered;
        GameObject parent;

        // Use this for initialization
        void Start()
        {
            triggered = false;
            parent = transform.parent.gameObject;
        }

        void toggle()
        {
            if( triggered )
            {

            }
            else{

            }
        }
    }
}