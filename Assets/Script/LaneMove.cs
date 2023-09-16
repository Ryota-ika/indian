using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneMove : MonoBehaviour//����S���@�c��@�v���C���[�����E�̎Ԑ����ړ�����X�N���v�g
{
    public enum LANE_STATE { 
        RIGHT,
        LEFT
    }
    LANE_STATE nowLane=LANE_STATE.LEFT;
    [Header("�E���[��")]
    [SerializeField]
    Transform rightLanePos;
    [Header("�����[��")]
    [SerializeField]
    Transform leftLanePos;
    [Header("���[���ړ������܂ł̎���")]
    [SerializeField]
    float laneMoveTime;
    bool laneChangeNow=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!laneChangeNow)
		{
            if (nowLane == LANE_STATE.RIGHT) 
            {
                StartCoroutine(ChangeLane(leftLanePos.position,laneMoveTime));
                nowLane = LANE_STATE.LEFT;
            }
            else if (nowLane == LANE_STATE.LEFT)
            {
                StartCoroutine(ChangeLane(rightLanePos.position, laneMoveTime));
                nowLane = LANE_STATE.RIGHT;
			}
		}
    }

    IEnumerator ChangeLane(Vector3 targetPos,float moveTime) {
        laneChangeNow = true;
        Vector3 pos = transform.position;
        float t = 0;
        while (t<=1)
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
