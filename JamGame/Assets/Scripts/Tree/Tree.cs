using Game.Entitys;
using Game.HUD;
using Game.Humanoids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MainTree
{
    [RequireComponent (typeof (Humanoid))]
    public class Tree : MonoBehaviour
    {
        [Header("Configs")]
        [Range(0f, 0.1f)]
        public float Growth_factor;
        [Range(0f, 20f)]
        public float Fruit_drop_interval;

        private Humanoid humanoid;

        private void Awake()
        {
            //Set
            humanoid = this.gameObject.GetComponent<Humanoid>();
        }

        private void Start()
        {
            StartCoroutine(Drop_fruit_routine());
        }

        private void Update()
        {
            //Set
            transform.localScale = transform.localScale + (transform.localScale * Growth_factor * Time.deltaTime);
        }

        #region Functions

        private GameObject Drop_fruit(Vector2 pos)
        {
            GameObject fruit = Resources.Load("Prefabs/Fruit") as GameObject;

            Instantiate(fruit, pos, Quaternion.identity);
        
            return fruit;
        }

        private IEnumerator Drop_fruit_routine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Fruit_drop_interval);

                GameObject new_fruit = Drop_fruit(new Vector2(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f)));
                new_fruit.GetComponent<Entity>().Configure(Entity.Entity_type.Fruit, Random.Range(10, 15));
            }
        }

        #endregion
    }
}

