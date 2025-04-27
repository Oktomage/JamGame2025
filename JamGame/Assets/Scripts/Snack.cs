using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snack : MonoBehaviour
{

    public float Move_Speed;
    public float Stun_Duration = 2f; 
    public float Attack_Cooldown = 5f; 

    private float currentCooldown;
    private GameObject player;
    private Player_controller playerController;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<Player_controller>();
        currentCooldown = Attack_Cooldown; 
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Move_Speed * Time.deltaTime);
    }

    private void Update()
    {
        Move();
        AttackLogic();
    }

    void AttackLogic()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        else
        {
            StunPlayer(); 
            currentCooldown = Attack_Cooldown; 
        }
    }

    void StunPlayer()
    {
        if (playerController != null)
        {
            // Ativa o stun
            playerController.Can_move = false;

            // Agenda para voltar ao normal depois de Stun_Duration segundos
            Invoke("RemoveStun", Stun_Duration);
        }
    }

    void RemoveStun()
    {
        if (playerController != null)
        {
            playerController.Can_move = true;
        }
    }



}

