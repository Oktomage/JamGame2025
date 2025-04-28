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

        [Header("Events_chance")]
        [Range(0f, 1f)]
        public float Sand_tornado_chance;

        private void Start()
        {
            StartCoroutine(Events_routine());
        }

        private void Spawn_sand_tornado(Vector2 pos)
        {
            GameObject newTornado = Instantiate(Resources.Load("Prefabs/Sand_tornado"), pos, Quaternion.identity) as GameObject;
        }

        private IEnumerator Events_routine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Events_interval);

                float c = Random.Range(0, 1f);

                if(c < Sand_tornado_chance)
                {
                    Spawn_sand_tornado(new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f)));
                }
            }   
        }
    }
}