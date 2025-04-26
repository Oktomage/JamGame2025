using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cabrito : MonoBehaviour
{
    public float dashVelocidade = 20f;
    public float dashDuracao = 0.2f;
    public float tempoEntreDashes = 2f;
    public float distanciaParaDash = 5f;

    private Rigidbody2D rb;
    private Transform jogador;
    private bool podeDash = true;
    private bool estaDashando = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jogador = GameObject.FindGameObjectWithTag("Alvo").transform;
    }

    void Update()
    {
        if (podeDash && !estaDashando && Vector2.Distance(transform.position, jogador.position) < distanciaParaDash)
        {
            StartCoroutine(ExecutarDash());
        }
    }

    System.Collections.IEnumerator ExecutarDash()
    {
        podeDash = false;
        estaDashando = true;

        Vector2 direcaoDash = (jogador.position - transform.position).normalized;
        rb.velocity = direcaoDash * dashVelocidade;

        yield return new WaitForSeconds(dashDuracao);

        rb.velocity = Vector2.zero;
        estaDashando = false;

        yield return new WaitForSeconds(tempoEntreDashes);
        podeDash = true;
    }
}





