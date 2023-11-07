//7/25
using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    RoadManager roadManager;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject goast;
    [SerializeField] private GameObject obstacleCar;
    //現在の道のオブジェクト
    public float moveSpeed = 13f;
    private bool turnRight = false;
    private bool turnLeft = false;
    private bool obstacleHit = false;
    private Quaternion cullentRotation;
    public Quaternion targetRotation;
    [SerializeField] private Vector3 center = Vector3.zero;
    [SerializeField] private Vector3 axis = Vector3.up;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float curveCompleteTime;
    private Quaternion rightRotation;
    private Quaternion leftRotation;
    private float timer = 0;
    private float leftRotationTime = 8f;
    private float rightRotationTime = 16f;
    private float curveAngle = 90f;
    private float targetDistance = 5f;
    private float obstacleHitTime = 2.0f;//減速する時間
    private float originalSpeed;

    [SerializeField] private DeathLineControll deathLineControll;


    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
        goast.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        //player.transform.position += new Vector3(0, 0, 1)*Time.deltaTime;
        if (turnRight)
        {
            MoveTurnRight();
        }
        else if (turnLeft)
        {
            MoveTurnLeft();
        }
        ObstaclePlayer();
    }

    private void ObstaclePlayer()
    {
        if (!obstacleHit)
        {
            float distance = Vector3.Distance(transform.position, obstacleCar.transform.position);
            if (distance < targetDistance)
            {
                //障害物に当たったら速度を減速
                originalSpeed = moveSpeed;
                moveSpeed = 7f;
                obstacleHit = true;
                StartCoroutine(ResetSpeedAfterDelay(obstacleHitTime));
            }
        }
    }

    //減速時間が経過したら速度を元に戻すコルーチン
    private IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        moveSpeed = originalSpeed;//元の速度に戻す
        obstacleHit = false;
    }

    public void MovePlayer()
    {
        player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;

    }
    /*public void HalfMovePlayer()
    {
        player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;
    }*/


    public void MoveTurnRight()
    {
        //1回だけ処理する
        if (timer <= 0)
        {
            //Debug.Log("transform.rotation" + player.transform.rotation.ToString());
            //leftRotation = Quaternion.FromToRotation(player.transform.forward, new Vector3(transform.right.x*(-1.0f), transform.right.y * (-1.0f), transform.right.z * (-1.0f)));
            cullentRotation = transform.rotation;
            rightRotation = Quaternion.AngleAxis(curveAngle, Vector3.up) * transform.rotation;
            Debug.Log("-transformright" + (-transform.right).ToString());

        }
        if (timer <= curveCompleteTime)
        {
            //通常の円運動
            timer += Time.deltaTime;
            player.transform.rotation = Quaternion.Lerp(cullentRotation, rightRotation,
                (timer / curveCompleteTime) * (timer / curveCompleteTime));
        }
        else
        {
            turnRight = false;
            timer = 0;
        }
    }

    private void MoveTurnLeft()
    {
        //1回だけ処理する
        if (timer <= 0)
        {
            //Debug.Log("transform.rotation" + player.transform.rotation.ToString());
            //leftRotation = Quaternion.FromToRotation(player.transform.forward, new Vector3(transform.right.x*(-1.0f), transform.right.y * (-1.0f), transform.right.z * (-1.0f)));
            cullentRotation = transform.rotation;
            leftRotation = Quaternion.AngleAxis(-curveAngle, Vector3.up) * transform.rotation;
            Debug.Log("-transformright" + (-transform.right).ToString());

        }
        if (timer <= curveCompleteTime)
        {
            //通常の円運動
            timer += Time.deltaTime;
            player.transform.rotation = Quaternion.Lerp(cullentRotation, leftRotation, timer / curveCompleteTime);
        }
        else
        {
            turnLeft = false;
            timer = 0;
        }
    }

    public void StopPlayer()
    {
        moveSpeed = 0f;
    }

    //public void HalfPlayer()
    //{
    //    moveSpeed
    //}

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "start")
        {
            button.SetActive(true);
            goast.SetActive(true);
          //  Debug.Log("スタート");
            StartCoroutine(deathLineControll.StartCount());
            StartCoroutine(deathLineControll.GetPlayerPos());
        }
    }
}


