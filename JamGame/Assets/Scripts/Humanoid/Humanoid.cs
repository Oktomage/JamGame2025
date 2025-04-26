using Game.HUD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Humanoids
{
    public class Humanoid : MonoBehaviour
    {
        //Vars
        [Header("Stats")]
        public float Health;
        public float MaxHealth;
        public float MoveSpeed;
        public float Exp;
        public int Level;

        //Components
        public Rigidbody2D Rigidbody { get; internal set; }
        internal Health_bar health_bar;

        private void Awake()
        {
            if (TryGetComponent(out Rigidbody2D rb))
            {
                Rigidbody = rb;
            }

            //Set
            MaxHealth = 10;
            Health = MaxHealth;
            MoveSpeed = 3;
            Exp = 0;
            Level = 1;
        }

        private void Start()
        {
            if (!health_bar)
            {
                Create_health_bar();
            }
        }

        internal void Take_damage(float dmg)
        {
            //Set
            Health -= dmg;

            if(Health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        private void Level_up()
        {
            //Set
            Level += 1;
        }

        internal void Gain_exp(float xp)
        {
            //Set
            Exp -= xp;

            if(Exp >= 100)
            {
                Exp -= 100;

                Level_up();
            }
        }

        internal void Create_health_bar()
        {
            //Set
            GameObject htlh_bar = Instantiate(Resources.Load("Prefabs/Health_bar"), Vector2.zero, Quaternion.identity) as GameObject;
            health_bar = htlh_bar.GetComponent<Health_bar>();

            health_bar.Configure(this);
        }
    }
}