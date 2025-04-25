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
    
        private void Follow_player()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            float distance_to_player = Vector2.Distance(transform.position, player.transform.position);
        }
    }
}

