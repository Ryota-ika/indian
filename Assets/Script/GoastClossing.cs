using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    DISTANCE_STATE state;
	[Header("プレイヤー")]
    [SerializeField]
    Transform player;
    [Header("幽霊")]
    [SerializeField]
    DeathLineControll goast;
    [Header("演出を表示し始める距離")]
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
    [SerializeField]
    List<Sprite> bloodImages;
    [SerializeField]
    Image blood;
    [SerializeField]
    List<AudioClip> voicePatern;
    float beforeDistance;
    bool isFading = false;
    bool voicePlaing = false;
    [SerializeField]
    AudioSource goastAS;
    // Start is called before the first frame update
    void Start()
    {
        goastAS= GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position,goast.transform.position);
        state = GetDistanceState(distance);
        switch (state)
		{
            //近づき具合に応じて幽霊の手の状態を変化
            case DISTANCE_STATE.DISTANTE:
                leftHand.gameObject.transform.position = leftHandPositions[0].position;
                rightHand.gameObject.transform.position = rightHandPositions[0].position;
                blood.gameObject.SetActive(false);
                break;
            case DISTANCE_STATE.CLOSED:
                leftHand.gameObject.transform.position = leftHandPositions[1].position;
                rightHand.gameObject.transform.position = rightHandPositions[1].position;
                blood.sprite = bloodImages[0];
				blood.gameObject.SetActive(true);
				break;
            case DISTANCE_STATE.VELY_CLOSED:
                leftHand.gameObject.transform.position = leftHandPositions[2].position;
                rightHand.gameObject.transform.position = rightHandPositions[2].position;
                blood.sprite = bloodImages[1];
				blood.gameObject.SetActive(true);
				break;
            case DISTANCE_STATE.CLOSEST:
                leftHand.gameObject.transform.position = leftHandPositions[3].position;
                rightHand.gameObject.transform.position = rightHandPositions[3].position;
                blood.sprite= bloodImages[2];
				blood.gameObject.SetActive(true);
				break;
        }
        if (state != DISTANCE_STATE.DISTANTE&&!voicePlaing)
        {
            playVoice();
            voicePlaing = true;
        }else
        {
            voicePlaing=false;
        }
        float image_Alpha = 1 - (distance / goastApproach);
        if (!isFading && distance < beforeDistance)
        {//幽霊から離れ始めた場合のみ透明度を変化させてフェードアウト
            ChengeAlpha(rightHand, image_Alpha);
            ChengeAlpha(leftHand, image_Alpha);
            isFading = true;
        }
        else if(isFading && distance >= beforeDistance){
            ChengeAlpha(rightHand, 1);
            ChengeAlpha(leftHand, 1);
            isFading = false;
        }
        beforeDistance = distance;
    }
    void ChengeAlpha(Image image, float alpha)
    {
        Color imageColor = image.color;
        imageColor.a = alpha;
        image.color = imageColor;
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
    IEnumerator playVoice()//パターンループでボイス再生
    {
        int patern=0;
        while (voicePlaing)
        {
            goastAS.PlayOneShot(voicePatern[patern]);
            patern++;
            patern %= voicePatern.Count;
            yield return new WaitForSeconds(1);
        }
        yield break;
    }
}
