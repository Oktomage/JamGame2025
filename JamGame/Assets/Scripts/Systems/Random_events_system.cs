using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.RandomEvents
{
    public class Random_events_system : MonoBehaviour
    {
        [Header("Configs")]
        [Range(0f, 10f)]
        public float Events_interval;

        private void Start()
        {
            StartCoroutine(Events_routine());
        }

        private IEnumerator Events_routine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Events_interval);
            }   
        }
    }
}