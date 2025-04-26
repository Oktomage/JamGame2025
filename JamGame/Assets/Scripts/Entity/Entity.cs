using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Entitys
{
    public class Entity : MonoBehaviour
    {
        public enum Entity_type { Fruit }

        [Header("Configs")]
        public Entity_type type;
        public bool Collectable;

        private void Update()
        {
            if(Collectable)
            {
                Try_follow_player();
            }
        }

        private void Try_follow_player()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if(player)
            {
                float distance_to_player = Vector2.Distance(transform.position, player.transform.position);

                //Try
                if (distance_to_player <= 3f)
                {
                    //Set
                    this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, player.transform.position, 3 * Time.deltaTime);

                    if (distance_to_player <= 0.5f)
                    {
                        Collect();
                    }
                }
            }
        }

        private void Collect()
        {
            Destroy(this.gameObject);
        }
    }
}

