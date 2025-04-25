using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormigaBehaviour : MonoBehaviour
{
    public float Move_Speed;

    EntityStats entityStats;

    GameObject Arvore_obj;

    ArvoreStats arvore;

    public GameObject Arvore_Devdd;

    private void Start()
    {
        arvore = gameObject.GetComponent<ArvoreStats>();

        entityStats = gameObject.GetComponent<EntityStats>();

        Arvore_obj = GameObject.FindGameObjectWithTag("Arvore");

    }

    void AtacckFormiga()
    {


        transform.position = Vector3.MoveTowards(transform.position, Arvore_obj.transform.position, Move_Speed * Time.deltaTime);



        float Dist = Vector2.Distance(transform.position, Arvore_obj.transform.position);

        if (Dist < 1.3f)
        {
            arvore.Arvore_HP -= entityStats.Atack_Damage;
            
        }
        else
        {
                //nADA ACONTECE
        }



    }



    private void FixedUpdate()
    {
        AtacckFormiga();
    }

   






}
