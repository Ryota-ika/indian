//7/10
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //現在の道のオブジェクト
    public float move_speed = 13f;
    private bool turn_right = false;
    public Quaternion targetRotation;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        /*if (player.tag == "Road_1A")
        {
        }
            player.transform.position += new Vector3(0, 0, 1)*Time.deltaTime;*/

        MovePlayer();
        /*if (nextRoad != null)
        {
            if (currentRoad.roadDirection == nextRoad.roadDirection)
            {
                MovePlayer();
            }
            else
            {
                StopPlayer();
            }
        }*/
    }

    public void MovePlayer()
    {
        if (turn_right)
        {
            //targetRotationからplayerのrotationに値を渡す。
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, targetRotation, 90f * Time.deltaTime);
            if (player.transform.rotation == targetRotation)
            {
                turn_right = false;
                player.transform.position += player.transform.forward * move_speed * Time.deltaTime;
            }
        }
        else
        {
            player.transform.position += player.transform.forward * move_speed * Time.deltaTime;
        }

    }

    public void StopPlayer()
    {
        move_speed = 0f;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            StopPlayer();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag !="Wall")
        {
            MovePlayer();

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "TurnRight")
        {
            turn_right = true;
            //y軸を中心に回転
            targetRotation = player.transform.rotation * Quaternion.Euler(0f, 90f, 0f);    
        }
    }
}
