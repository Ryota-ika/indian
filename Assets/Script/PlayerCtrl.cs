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
    [SerializeField] public RoadObject currentRoad;
    //次の道のオブジェクト
    [SerializeField] public RoadObject nextRoad;
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
        player.transform.position += new Vector3(0, 0, 1) * Time.deltaTime;
    }

    private void StopPlayer()
    {
        
    }
}
