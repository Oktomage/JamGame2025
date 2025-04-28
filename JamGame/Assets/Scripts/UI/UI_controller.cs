using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Game.Events;
using Game.Humanoids;

namespace Game.UI
{
    public class UI_controller : MonoBehaviour
    {
        

        [Header("Elements")]
        public TextMeshProUGUI TLevel;
        public TextMeshProUGUI TExp;

        private GameObject Player;

      

        private void Awake()
        {
            Events_controller.Player_gained_exp.AddListener(Update_Hud);
            Events_controller.Player_level_up.AddListener(Update_Hud);
        }

        private void Start()
        {
            

            //Get
            GameObject plr = GameObject.FindGameObjectWithTag("Player");
            Player = plr;
        }

        private void Update_Hud()
        {
            //Set
            TLevel.text = "Level - " + Player.GetComponent<Humanoid>().Level;
            TExp.text = "Exp " + Player.GetComponent<Humanoid>().Exp + " / 100";
        }
    }
}