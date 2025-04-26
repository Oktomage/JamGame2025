using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FormigaBehaviour : MonoBehaviour

{
    public GameObject atackWarning;
    EntityStats entity;




    private void Start()
    {
        entity = gameObject.GetComponent<EntityStats>();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        while (entity.Hp_ > 0 )
        {
            if (collision.CompareTag("Arvore"))
            {
                ArvoreStatsHP arvore = collision.GetComponent<ArvoreStatsHP>();

                if (arvore != null)
                {
                    arvore.Hp_Arvore -= entity.Atack_Damage;

                    if (atackWarning != null)
                        atackWarning.SetActive(true);
                }
            }
        }

     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Arvore") && atackWarning != null)
        {
            atackWarning.SetActive(false);
        }
    }
}



