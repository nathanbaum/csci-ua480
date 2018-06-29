using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    public class TriggerRotate : ITrigger
    {

        //public float multiplier;
        callback closeMenu;
        setter setToggle;
        bool triggered=false;
        callback removeSelf;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if( triggered )
            {
                transform.rotation = Camera.main.transform.rotation*Camera.main.transform.rotation;
            }
        }

        public override void setCallBacks(callback close, setter set)
        {
            closeMenu = close;
            setToggle = set;
        }

        public override string GetName()
        {
            return "Rotate";
        }

        public override void Toggle()
        {
            if( triggered )
            {
                triggered = false;
                removeSelf();
            }
            else
            {
                triggered = true;
                removeSelf = setToggle(Toggle);
                closeMenu();
            }
        }
    }
}