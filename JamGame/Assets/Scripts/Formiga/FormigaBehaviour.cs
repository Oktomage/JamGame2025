using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FormigaBehaviour : MonoBehaviour

{
    public GameObject atackWarning;
    public GameObject Arvore;
    public float Cooldown_;
    public float Cooldown_value;

    private EntityStats entity;
    private ArvoreStatsHP arvoreStats;

    private void Start()
    {
        entity = GetComponent<EntityStats>();
        arvoreStats = Arvore.GetComponent<ArvoreStatsHP>();
    }

    private void Update()
    {
        Cooldown();
    }

    void Cooldown()
    {
        float Dist = Vector2.Distance(transform.position, Arvore.transform.position);

        if (Cooldown_ > 0)
        {
            Cooldown_ -= Time.deltaTime;
        }
        else if (Dist <= 1.3f)
        {
            arvoreStats.Hp_Arvore -= entity.Atack_Damage;
            Cooldown_ = Cooldown_value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arvore"))
        {
            Arvore = collision.gameObject;
            arvoreStats = Arvore.GetComponent<ArvoreStatsHP>();
            atackWarning.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arvore"))
        {
            atackWarning.SetActive(false);
        }
    }
}















