using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneMove : MonoBehaviour
{
    public enum LANE_STATE { 
        RIGHT,
        LEFT
    }
    LANE_STATE nowLane=LANE_STATE.LEFT;
    [Header("右レーン")]
    [SerializeField]
    Transform rightLanePos;
    [Header("左レーン")]
    [SerializeField]
    Transform leftLanePos;
    [Header("レーン移動完了までの時間")]
    [SerializeField]
    float laneMoveTime;
    bool laneChangeNow=false;

    private Vector3 initialTouchPosition;
    private Vector3 lastTouchPosition;
    private bool isSwiping = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //タッチ入力
        
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        initialTouchPosition = touch.position;
                        isSwiping = true;
                        break;
                    case TouchPhase.Moved:
                        lastTouchPosition = touch.position;
                        break;
                    case TouchPhase.Ended:
                        if (isSwiping==true)
                        {
                            float swipeDistance = (lastTouchPosition.x - initialTouchPosition.x) / Screen.width;
                            if (swipeDistance > 0.1f && nowLane == LANE_STATE.LEFT && !laneChangeNow)
                            {
                                
                                StartCoroutine(ChangeLane(rightLanePos.position, laneMoveTime));
                                nowLane = LANE_STATE.RIGHT;
                            }
                            else if (swipeDistance < -0.1f && nowLane == LANE_STATE.RIGHT && !laneChangeNow)
                            {
                         
                                StartCoroutine(ChangeLane(leftLanePos.position, laneMoveTime));
                                nowLane = LANE_STATE.LEFT;
                            }
                            isSwiping = false;
                        }
                        break;
                }
            }
    }

    IEnumerator ChangeLane(Vector3 targetPos,float moveTime) {
        laneChangeNow = true;
        Vector3 pos = transform.position;
        float t = 0;
        while (t <= 1)
        {
            Vector3 MovePos = Vector3.Lerp(pos, targetPos, 1 - Mathf.Pow(1 - t, 5));
            transform.position += MovePos-transform.position;
            Debug.Log(Vector3.Lerp(pos, targetPos, 1 - Mathf.Pow(1 - t, 5)));
            t += Time.deltaTime/moveTime;
            yield return null;
        }
        laneChangeNow = false;
    }
}
