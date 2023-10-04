//7/25
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    RoadManager roadManager;
    [SerializeField] private GameObject player;
    //åªç›ÇÃìπÇÃÉIÉuÉWÉFÉNÉg
    public float moveSpeed = 13f;
    private bool turnRight = false;
    private bool turnLeft = false;
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


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        //player.transform.position += new Vector3(0, 0, 1)*Time.deltaTime;
        if (turnRight)
        {
            MoveTurnRight();
        }else if(turnLeft){
            MoveTurnLeft();
        }
    }

    public void MovePlayer()
    {
        player.transform.position += player.transform.forward * moveSpeed * Time.deltaTime;

    }


   public void MoveTurnRight()
    {
        //1âÒÇæÇØèàóùÇ∑ÇÈ
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
            //í èÌÇÃâ~â^ìÆ
            timer += Time.deltaTime;
            player.transform.rotation = Quaternion.Lerp(cullentRotation, rightRotation, 
                (timer/curveCompleteTime)*(timer / curveCompleteTime));
        }
        else
        {
            turnRight = false;

        }
    }

    private void MoveTurnLeft()
    {
        //1âÒÇæÇØèàóùÇ∑ÇÈ
        if (timer <= 0)
        {
            //Debug.Log("transform.rotation" + player.transform.rotation.ToString());
            //leftRotation = Quaternion.FromToRotation(player.transform.forward, new Vector3(transform.right.x*(-1.0f), transform.right.y * (-1.0f), transform.right.z * (-1.0f)));
            cullentRotation = transform.rotation;
            leftRotation = Quaternion.AngleAxis(-curveAngle, Vector3.up)*transform.rotation;
            Debug.Log("-transformright"+(-transform.right).ToString());
         
        }
        if (timer <= curveCompleteTime)
        {
            //í èÌÇÃâ~â^ìÆ
            timer += Time.deltaTime;
            player.transform.rotation = Quaternion.Lerp(cullentRotation, leftRotation, timer/curveCompleteTime);
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
            //yé≤ÇíÜêSÇ…âÒì]
            //targetRotation = player.transform.rotation * Quaternion.Euler(0f, 90f, 0f);
            /*player.transform.RotateAround(center,axis,360/period*Time.deltaTime);*/
        }
        if (collision.gameObject.tag == "TurnLeft")
        {
            turnLeft = true;
        }


    }
   
}


