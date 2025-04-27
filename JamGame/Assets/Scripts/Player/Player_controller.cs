using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Humanoids;
using Game.Audios;
using Game.Events;

namespace Game.Player
{
    [RequireComponent(typeof(Humanoid))]
    public class Player_controller : MonoBehaviour
    {
        internal Humanoid humanoid;

        private bool Can_move;
        private bool Can_attack;
        private bool Can_dance;

        private Animator Anim;

        private void Awake()
        {
            //Get
            humanoid = this.gameObject.GetComponent<Humanoid>();
            Anim = this.gameObject.GetComponent<Animator>();

            //Set
            Can_move = true;
            Can_attack = true;
            Can_dance = true;
        }

        private void Update()
        {
            //Move
            if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && humanoid.Rigidbody != null && Can_move)
            {
                Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
            }

            //Attack
            if(Input.GetMouseButtonDown(0) && Can_attack)
            {
                Melee_wimp_attack(1, 2, 1);
            }

            //Specials
            else if (Input.GetKeyDown(KeyCode.F) && Can_dance)
            {
                StartCoroutine(Rain_dance());
            }
        }

        #region Functions

        private void Move(Vector2 dir)
        {
            //Set
            humanoid.Rigidbody.velocity = dir * humanoid.MoveSpeed;
        }

        private void Melee_wimp_attack(float attack_damage, float attack_distance, float target_ammount)
        {
            Vector2 mouseDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            Vector2 attack_point = new Vector2(transform.position.x, transform.position.y) + (mouseDir * attack_distance);

            Collider2D[] colls = Physics2D.OverlapBoxAll(attack_point, Vector2.one, 0);
            List<Humanoid> Humanoids_in_range = new List<Humanoid>();

            print(attack_point);

            //Filter
            if(colls.Length > 0)
            {
                StartCoroutine(Force_animation("Whip_attacking", 0.3f));
                StartCoroutine(Whip_attack_dealy(0.3f));

                foreach (Collider2D coll in colls)
                {
                    if (coll.gameObject.GetComponent<Humanoid>() && coll.gameObject != this.gameObject)
                    {
                        //Set
                        Humanoids_in_range.Add(coll.gameObject.GetComponent<Humanoid>());
                    }
                }
            }
            else
            {
                return;
            }

            
            if (Humanoids_in_range.Count < target_ammount)
            {
                //Set
                target_ammount = Humanoids_in_range.Count;
            }

            //Do damage
            for (int i = 0; i < target_ammount; i++)
            {
                Humanoids_in_range[i].Take_damage(attack_damage);
            }

            //Audio
            Audio_controller.Play_audio("Basic Attack");
        }

        private IEnumerator Whip_attack_dealy(float time)
        {
            Can_attack = false;

            yield return new WaitForSeconds(time);

            Can_attack = true;
        }

        private IEnumerator Rain_dance()
        {
            //Set
            Can_move = false;
            Can_dance = false;

            Events_controller.Rain_dance_event.Invoke();

            humanoid.Rigidbody.velocity = Vector2.zero;

            yield return new WaitForSeconds(3);

            //Set
            Can_move = true;
            Can_dance = true;
        }

        #endregion

        #region Anim

        private IEnumerator Force_animation(string paramter_name, float time)
        {
            Anim.SetBool(paramter_name, true);

            yield return new WaitForSeconds(time);

            Anim.SetBool(paramter_name, false);
        }

        #endregion
    }
}

