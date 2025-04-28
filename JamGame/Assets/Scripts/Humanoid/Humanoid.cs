using Game.Audios;
using Game.Entitys;
using Game.Events;
using Game.HUD;
using Game.Player;
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
        public float Atack_Damage;





        //Components
        public Rigidbody2D Rigidbody { get; internal set; }
        internal Health_bar health_bar;
        public SpriteRenderer Render { get; internal set; }

        private Material Default_material;
        private Material Hit_effect_material;

        private void Awake()
        {
            if (TryGetComponent(out Rigidbody2D rb))
            {
                Rigidbody = rb;
            }

            if(TryGetComponent(out SpriteRenderer spt))
            {
                Render = spt;
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

            //Set
            Default_material = Render?.material;
            Hit_effect_material = Resources.Load<Material>("Materials/Hit_effect_material");
        }

        private void Die()
        {
            //Drop fruit
            GameObject Drop_fruit(Vector2 pos)
            {
                GameObject fruit = Resources.Load("Prefabs/Fruit") as GameObject;

                Instantiate(fruit, pos, Quaternion.identity);

                return fruit;
            }

            GameObject new_fruit = Drop_fruit(transform.position);
            new_fruit.GetComponent<Entity>().Configure(Entity.Entity_type.Fruit, Random.Range(10, 15));

            //Events
            if (this.gameObject.GetComponent<Tree>())
            {
                Events_controller.Tree_died.Invoke();
            }

            Destroy(this.gameObject);
        }

        internal void Take_damage(float dmg)
        {
            //Set
            Health -= dmg;

            StartCoroutine(Hit_effect());

            if(Health <= 0)
            {
                Die();
            }
        }

        private IEnumerator Hit_effect()
        {
            Color default_color = Render.color;

            Render.material = Hit_effect_material;
            Render.color = Color.white;

            yield return new WaitForSeconds(0.1f);

            Render.material = Default_material;
            Render.color = default_color;
        }

        private void Level_up()
        {
            //Set
            Level += 1;

            //Audio
            Audio_controller.Play_audio("Level up_2", 0.3f);

            if(this.gameObject.GetComponent<Player_controller>())
            {
                //Set
                Render.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));

                //Events
                Events_controller.Player_level_up.Invoke();
            }
        }

        internal void Gain_exp(float xp)
        {
            //Set
            Exp += xp;

            if (Exp >= 100)
            {
                Exp -= 100;

                Level_up();
            }

            //Events
            if (this.gameObject.GetComponent<Player_controller>())
            {
                Events_controller.Player_gained_exp.Invoke();
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