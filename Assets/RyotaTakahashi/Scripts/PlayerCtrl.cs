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
    public float moveSpeed = 13f;
    private bool turnRight = false;
    public Quaternion targetRotation;
    [SerializeField] private Vector3 center = Vector3.zero;
    [SerializeField] private Vector3 axis = Vector3.up;
    [SerializeField] private float speed = 1f;

    private float timer = 0;
    private bool circleMovementInProgress=false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");

       /* Vector3 directionToCenter = center - player.transform.position;
        _targetRotatioin = Mathf.Atan2(directionToCenter.z, directionToCenter.x) * Mathf.Rad2Deg - 90;*/
    }

    // Update is called once per frame
    void Update()
    {
        //player.transform.position += new Vector3(0, 0, 1)*Time.deltaTime;
        MovePlayer();
    }

    /*if (turnRight)
            {
                //targetRotationからplayerのrotationに値を渡す。
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
            }*/
    public void MovePlayer()
    {

        //player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;
        if (turnRight)
        {
            Quaternion rotation = Quaternion.FromToRotation(transform.up, transform.right);
            if (timer <= 3f)
            {
            //通常の円運動
            float rotaionAngle = speed * Time.deltaTime;
            player.transform.RotateAround(player.transform.position, axis, rotaionAngle);
            /*player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;*/
            timer = timer + 1;
                player.transform.rotation = Quaternion.Lerp(transform.rotation, rotation,timer+1);
            }
            else
            {
                turnRight=false;
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
            //y軸を中心に回転
            //targetRotation = player.transform.rotation * Quaternion.Euler(0f, 90f, 0f);
            /*player.transform.RotateAround(center,axis,360/period*Time.deltaTime);*/
        }
    }
}
