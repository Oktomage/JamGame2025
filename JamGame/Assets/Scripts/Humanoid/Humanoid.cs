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

        //Components
        public Rigidbody2D Rigidbody { get; internal set; }


        private void Awake()
        {
            if (TryGetComponent(out Rigidbody2D rb))
            {
                Rigidbody = rb;
            }
        }

        internal void Take_damage(float dmg)
        {
            //Set
            Health -= dmg;
        }
    }
}