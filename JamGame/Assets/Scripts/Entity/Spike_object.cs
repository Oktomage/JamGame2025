using Game.Humanoids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects
{
    public class Spike_object : MonoBehaviour
    {
        [Header("Configs")]
        public float Damage_per_second;

        private bool Can_damage;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(Can_damage)
            {
                if (collision.gameObject.GetComponent<Humanoid>())
                {
                    collision.gameObject.GetComponent<Humanoid>().Take_damage(Damage_per_second / 10f);

                    StartCoroutine(Damage_debounce());
                }
            }
        }

        private void Awake()
        {
            //Set
            Can_damage = true;
        }

        private IEnumerator Damage_debounce()
        {
            Can_damage = false;

            yield return new WaitForSeconds(0.1f);

            Can_damage = true;
        }
    }
}