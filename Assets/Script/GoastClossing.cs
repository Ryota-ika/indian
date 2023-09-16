using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoastClossing : MonoBehaviour
{
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
    UnityEngine.UI.Image bloodImage;
    [SerializeField]
    Vector3 minImageSize;
    [SerializeField]
    Vector3 maxImageSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position,goast.transform.position);
        if (distance < goastApproach&&goast.GetIsStart())
        {
            Debug.Log("幽霊が近づいてきた　残り約" + distance.ToString() + "m");
            float size = distance / goastApproach;
            //近づき具合の割合を出して画像の表示領域を調整
            bloodImage.rectTransform.localScale = new Vector3(
                Mathf.Lerp(minImageSize.x, maxImageSize.x, size),
                Mathf.Lerp(minImageSize.y, maxImageSize.y, size),
                1);
        }
        else {
            bloodImage.rectTransform.localScale = maxImageSize;
        }
    }
}
