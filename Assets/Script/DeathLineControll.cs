using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLineControll : MonoBehaviour
{
    [Header("�s���J�n�܂ł̎���")]
    [SerializeField]
    float startTime;
    [Header("�X�s�[�h")]
    [SerializeField]
    float speed;
    [Header("�v���C���[(�ǐՑΏ�)")]
    [SerializeField]
    Transform player;
    bool isStart=false;
    Vector3 latePos;
    // Start is called before the first frame update
    void Start()
    {
        latePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart) { return; }
        StartCoroutine(GetRatePos(startTime));
        transform.position = latePos;
    }
    IEnumerator GetRatePos(float waitTime)
    {
        Vector3 nowPos = player.position;
        yield return new WaitForSeconds(waitTime);
        latePos = nowPos;
    }
    IEnumerator StartCount()//�X�^�[�g����܂őҋ@����R���[�`��
    {
        float time=0;
        while (time<=startTime) {
            time += Time.deltaTime;
            yield return null;
        }
        Debug.Log("�H�삪�����o����");
        isStart = true;

    }
}
