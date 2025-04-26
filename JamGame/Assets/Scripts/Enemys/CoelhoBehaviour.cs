using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoelhoBehaviour : MonoBehaviour
   
{


    GameObject Coelho;








    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coelho = GameObject.FindGameObjectWithTag("Coelho");

        if(collision.gameObject.tag == "Toca")
        {
            Coelho.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Coelho.SetActive(true);
    }


}


