using Game.Humanoids;
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

        [Space]
        public float Exp_value;

        private void Awake()
        {
            //Set
            Collectable = true;
        }

        private void Update()
        {
            if(Collectable)
            {
                Try_follow_player();
            }
        }

        public void Configure(Entity_type tp, float xp_vl)
        {
            //Set
            type = tp;
            Exp_value = xp_vl;
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
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            switch (type)
            {
                case Entity_type.Fruit:
                    //Set
                    player.GetComponent<Humanoid>().Gain_exp(Exp_value);
                    break;
            }

            Destroy(this.gameObject);
        }
    }
}

