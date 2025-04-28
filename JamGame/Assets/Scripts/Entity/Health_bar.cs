using Game.Humanoids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.HUD
{
    public class Health_bar : MonoBehaviour
    {
        [Header("Configs")]
        public GameObject Bar;

        public SpriteRenderer Bar_render;
        public SpriteRenderer Background_render;
        public Humanoid humanoid;

        private void Update()
        {
            if (humanoid)
            {
                Move();
                Update_bar();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        internal void Configure(Humanoid hmd)
        {
            //Set
            humanoid = hmd;
        }

        private void Move()
        {
            transform.position = new Vector3(humanoid.transform.position.x, humanoid.transform.position.y + 1, 1);
        }

        private void Update_bar()
        {
            float scale = humanoid.Health / humanoid.MaxHealth;
        
            if(scale != 1)
            {
                //Set
                Bar_render.enabled = true;
                Background_render.enabled = true;

                Bar.transform.localScale = new Vector3(scale, Bar.transform.localScale.y, Bar.transform.localScale.z);
            }
            else
            {
                //Set
                Bar_render.enabled = false;
                Background_render.enabled = false;
            }
        }
    }
}

