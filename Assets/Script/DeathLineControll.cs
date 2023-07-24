using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLineControll : MonoBehaviour
{
    [Header("行動開始までの時間")]
    [SerializeField]
    float startTime;
    [Header("スピード")]
    [SerializeField]
    float speed;
    [Header("プレイヤー(追跡対象)")]
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
    IEnumerator StartCount()//スタートするまで待機するコルーチン
    {
        float time=0;
        while (time<=startTime) {
            time += Time.deltaTime;
            yield return null;
        }
        Debug.Log("幽霊が動き出した");
        isStart = true;

    }
}
