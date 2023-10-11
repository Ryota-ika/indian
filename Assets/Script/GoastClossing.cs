using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoastClossing : MonoBehaviour
{
    enum DISTANCE_STATE
    {
        DISTANTE = 0,
        CLOSED = 1,
        VELY_CLOSED = 2,
        CLOSEST = 3
    }
	[Header("�v���C���[")]
    [SerializeField]
    Transform player;
    [Header("�H��")]
    [SerializeField]
    DeathLineControll goast;
    [Header("���o��\�����n�߂鋗��")]
    [SerializeField]
    float goastApproach;
    [SerializeField]
    Image bloodImage;
    [SerializeField]
    Vector3 minImageSize;
    [SerializeField]
    Vector3 maxImageSize;
    [SerializeField]
    Image leftHand;
    [SerializeField]
    Image rightHand;
    [SerializeField]
    List<Transform> leftHandPositions;
    [SerializeField]
    List<Transform> rightHandPositions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position,goast.transform.position);
		switch (GetDistanceState(distance))
		{
            //�߂Â���ɉ����ėH��̎�̏�Ԃ�ω�
            case DISTANCE_STATE.DISTANTE:
                leftHand.gameObject.transform.position = leftHandPositions[0].position;
                rightHand.gameObject.transform.position = rightHandPositions[0].position;
                break;
            case DISTANCE_STATE.CLOSED:
                leftHand.gameObject.transform.position = leftHandPositions[1].position;
                rightHand.gameObject.transform.position = rightHandPositions[1].position;
                break;
            case DISTANCE_STATE.VELY_CLOSED:
                leftHand.gameObject.transform.position = leftHandPositions[2].position;
                rightHand.gameObject.transform.position = rightHandPositions[2].position;
                break;
            case DISTANCE_STATE.CLOSEST:
                leftHand.gameObject.transform.position = leftHandPositions[3].position;
                rightHand.gameObject.transform.position = rightHandPositions[3].position;
                break;
        }
        float image_Alpha = 1-(distance/goastApproach);
        //Debug.Log(image_Alpha);
        Color right_Color = rightHand.color;
        right_Color.a = image_Alpha;
        rightHand.color = right_Color;
        Color left_Color = rightHand.color;
        left_Color.a = image_Alpha;
        leftHand.color = left_Color;
	}
	DISTANCE_STATE GetDistanceState(float distance)
	{
        DISTANCE_STATE state=DISTANCE_STATE.DISTANTE;
        float interval = goastApproach / 3;
        if (distance < goastApproach && distance >= goastApproach - interval) {
            state = DISTANCE_STATE.CLOSED;
            return state;
        } else if(distance < goastApproach - interval && distance >= goastApproach - interval*2){
            state = DISTANCE_STATE.VELY_CLOSED;
            return state;
        } else if (distance < goastApproach - interval*2 && distance >= goastApproach - interval * 3){
            state = DISTANCE_STATE.CLOSEST;
            return state;
        }
        return state;
    }
}
