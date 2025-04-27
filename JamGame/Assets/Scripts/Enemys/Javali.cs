using Game.Player;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Javali : MonoBehaviour
{

    public float Move;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Javali")
        {
            float vertical = Input.GetAxisRaw("Vertical");
            float horizontal = Input.GetAxisRaw("Horizontal");

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(vertical * Move, horizontal * Move));

        }
    }
}





