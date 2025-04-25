using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    [Header("Focus")]
    public Transform Cam_focus;
    public Transform Player;

    [Header("Configs")]
    public float Move_speed;

    [Space]
    public float Safe_distance;
    public float Max_zoomOut;
    private float Default_zoom;

    private void Awake()
    {
        //Set
        Default_zoom = Camera.main.orthographicSize;
    }

    #region Core

    public void Set_cam_focus(Transform fcs)
    {
        //Set
        Cam_focus = fcs;
    }

    #endregion

    private void Update()
    {
        Dynamic_zoom();
    }

    #region Functions

    private void Dynamic_zoom()
    {
        float distance_to_player = Vector2.Distance(Cam_focus.position, Player.position);
        float target_zoom;

        if (distance_to_player > Safe_distance)
        {
            target_zoom = Mathf.Clamp(distance_to_player * 0.25f, 0f, Max_zoomOut);

            //Set
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Default_zoom + target_zoom, Move_speed * Time.deltaTime);
        }
        else
        {
            //Set
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Default_zoom, Move_speed * Time.deltaTime);
        }
    }

    #endregion
}
