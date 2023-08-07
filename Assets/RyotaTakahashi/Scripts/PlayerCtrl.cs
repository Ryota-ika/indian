//7/25
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
    private bool turnLeft = false;
    public Quaternion targetRotation;
    [SerializeField] private Vector3 center = Vector3.zero;
    [SerializeField] private Vector3 axis = Vector3.up;
    [SerializeField] private float speed = 1f;
    private Quaternion rightRotation;
    private Quaternion leftRotation;
    private float timer = 0;
    private float leftRotationTime = 8f;
    private float rightRotationTime = 16f;
    private float curveAngle = 90f;
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
        if (turnRight)
        {
            MoveTurnRight();
        }else if(turnLeft){
            MoveTurnLeft();
        }
        else
        {
            MovePlayer();
        }
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

        /*//player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;
        if (turnRight)
        {
            //1回だけ処理する
            if (timer <= 0) { 
            rotation = Quaternion.FromToRotation(transform.forward, transform.right);
            }
            if (timer <= 1f)
            {
                //通常の円運動
                *//*float rotaionAngle = speed * Time.deltaTime;*/
        /*player.transform.RotateAround(player.transform.position, axis, rotaionAngle);*//*

        player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;
        player.transform.rotation = Quaternion.Lerp(transform.rotation, rotation,timer);
        timer = timer /rotationTime + Time.deltaTime;
        Debug.Log(timer);
    }
    else
    {
        turnRight=false;
    }
}
else
{
    player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;

}*/
        player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;

    }

    /*private void MoveTurnRight()
    {
        //1回だけ処理する
        if (timer <= 0)
        {
            rightRotation = Quaternion.FromToRotation(transform.forward, transform.right);
            Debug.Log("右旋回");
            Debug.Log("rightRotation" + rightRotation.ToString());
            Debug.Log("transform.forward" + transform.forward.ToString());
        }
        if (timer <= 1f)
        {
            //通常の円運動
            *//*float rotaionAngle = speed * Time.deltaTime;*/
            /*player.transform.RotateAround(player.transform.position, axis, rotaionAngle);*//*

            player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;
            player.transform.rotation = Quaternion.Lerp(transform.rotation, rightRotation, timer);
            timer = timer / rightRotationTime + Time.deltaTime;
            Debug.Log("transform.rotation"+player.transform.rotation.ToString());
        }
        else
        {
            turnRight = false;
        }
    }*/

    private void MoveTurnRight()
    {
        //1回だけ処理する
        if (timer <= 0)
        {
            //Debug.Log("transform.rotation" + player.transform.rotation.ToString());
            //leftRotation = Quaternion.FromToRotation(player.transform.forward, new Vector3(transform.right.x*(-1.0f), transform.right.y * (-1.0f), transform.right.z * (-1.0f)));
            rightRotation = Quaternion.AngleAxis(curveAngle, Vector3.up) * transform.rotation;
            Debug.Log("-transformright" + (-transform.right).ToString());

        }
        if (timer <= 8f)
        {
            //通常の円運動
            timer += Time.deltaTime / rightRotationTime;
            player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;
            player.transform.rotation = Quaternion.Lerp(transform.rotation, rightRotation, timer);
        }
        else
        {
            turnRight = false;

        }
    }

    private void MoveTurnLeft()
    {
        //1回だけ処理する
        if (timer <= 0)
        {
            //Debug.Log("transform.rotation" + player.transform.rotation.ToString());
            //leftRotation = Quaternion.FromToRotation(player.transform.forward, new Vector3(transform.right.x*(-1.0f), transform.right.y * (-1.0f), transform.right.z * (-1.0f)));
            leftRotation = Quaternion.AngleAxis(-curveAngle, Vector3.up)*transform.rotation;
            Debug.Log("-transformright"+(-transform.right).ToString());
         
        }
        if (timer <= 8f)
        {
            //通常の円運動
            timer += Time.deltaTime / leftRotationTime;
            player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;
            player.transform.rotation = Quaternion.Lerp(transform.rotation, leftRotation, timer);
        }
        else
        {
            turnLeft = false;

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
        if (collision.gameObject.tag != "Wall")
        {
            MovePlayer();

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TurnRight")
        {
            turnRight = true;
            //y軸を中心に回転
            //targetRotation = player.transform.rotation * Quaternion.Euler(0f, 90f, 0f);
            /*player.transform.RotateAround(center,axis,360/period*Time.deltaTime);*/
        }
        if (collision.gameObject.tag == "TurnLeft")
        {
            turnLeft = true;
        }
    }
}
