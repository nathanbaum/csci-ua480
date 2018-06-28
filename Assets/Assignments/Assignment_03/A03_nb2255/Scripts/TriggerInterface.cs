using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nb2255
{
    public interface ITrigger
    {
        void setParent(GameObject p);
        void toggle();
    }
}