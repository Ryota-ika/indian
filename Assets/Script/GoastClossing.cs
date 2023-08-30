using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoastClossing : MonoBehaviour
{
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
            Debug.Log("�H�삪�߂Â��Ă����@�c���" + distance.ToString() + "m");
            float size = distance / goastApproach;
            //�߂Â���̊������o���ĉ摜�̕\���̈�𒲐�
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
