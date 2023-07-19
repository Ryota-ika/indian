//7/10
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //���݂̓��̃I�u�W�F�N�g
    public float moveSpeed = 13f;
    private bool turnRight = false;
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
        if (turnRight)
        {
            //targetRotation����player��rotation�ɒl��n���B
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, targetRotation, 90f * Time.deltaTime);
            if (player.transform.rotation == targetRotation)
            {
                turnRight = false;
                player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;
        }

    }

    public void StopPlayer()
    {
        moveSpeed = 0f;
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
            turnRight = true;
            //y���𒆐S�ɉ�]
            targetRotation = player.transform.rotation * Quaternion.Euler(0f, 90f, 0f);    
        }
    }
}
