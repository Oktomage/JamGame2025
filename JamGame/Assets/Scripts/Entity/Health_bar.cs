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
            Bar.transform.localScale = new Vector3(humanoid.Health / humanoid.MaxHealth, Bar.transform.localScale.y, Bar.transform.localScale.z);
        }
    }
}

