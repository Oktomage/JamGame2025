using Game.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Systems
{
    public class Rain_system : MonoBehaviour
    {
        [Header("Configs")]
        [Range(0f, 15f)]
        public float Raining_time;

        private List<GameObject> Water_drops = new List<GameObject>();
        private bool Raining;

        private void Awake()
        {
            //Set
            Events_controller.Rain_dance_event.AddListener(Start_raining);

            Raining = false;
        }

        private void Start_raining()
        {
            //Set
            Raining = true;

            StartCoroutine(Raining_timer());
            StartCoroutine(Water_drop_generator());
        }

        private GameObject create_drop()
        {
            GameObject new_drop = new GameObject("drop");
            new_drop.transform.position = new Vector3(Random.Range(-10f, 10f), 10f, 0);
            new_drop.transform.localScale *= 0.2f;

            //Set
            Water_drops.Add(new_drop);

            //Add
            new_drop.AddComponent<Rigidbody2D>();
            new_drop.GetComponent<Rigidbody2D>().gravityScale = 2;

            new_drop.AddComponent<SpriteRenderer>();
            new_drop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Graphics/Square");
            new_drop.GetComponent<SpriteRenderer>().color = Color.blue;
            new_drop.GetComponent<SpriteRenderer>().sortingOrder = 10;

            return new_drop;
        }

        private IEnumerator Raining_timer()
        {
            yield return new WaitForSeconds(Raining_time);

            //Set
            Raining = false;
        
            foreach(GameObject drop in Water_drops)
            {
                Destroy(drop);
            }
        }

        private IEnumerator Water_drop_generator()
        {
            while (Raining)
            {
                yield return new WaitForSeconds(0.1f);

                create_drop();
            }
        }
    }
}