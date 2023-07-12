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
    [SerializeField] public RoadObject currentRoad;
    //���̓��̃I�u�W�F�N�g
    [SerializeField] public RoadObject nextRoad;
    float move_speed = 3f;
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
        if (nextRoad != null)
        {
            if (currentRoad.roadDirection == nextRoad.roadDirection)
            {
                MovePlayer();
            }
            else
            {
                StopPlayer();
            }
        }
    }

    private void MovePlayer()
    {

        player.transform.position += new Vector3(0, 0, move_speed) * Time.deltaTime;

    }

    private void StopPlayer()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            move_speed = 0f;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag !="Wall")
        {
            MovePlayer();

        }
    }
}
