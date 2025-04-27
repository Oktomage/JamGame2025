using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Events
{
    public class Events_controller : MonoBehaviour
    {
        public static UnityEvent Rain_dance_event = new UnityEvent();
        public static UnityEvent Player_level_up = new UnityEvent();
        public static UnityEvent Tree_died = new UnityEvent();
    }
}
