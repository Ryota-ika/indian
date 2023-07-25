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
    [Header("プレイヤー位置記録頻度")]
    [SerializeField]
    float saveLate;
    [Header("プレイヤー位置情報保持数上限")]
    [SerializeField]
    int maxPlayerDataNum;


    bool isStart=false;
    [SerializeField]
    List<Vector3> playerPath = new List<Vector3>();
    [SerializeField]
    Vector3 targetPos=new Vector3();
    float timer;
    int nextTargetIndex;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCount());
        StartCoroutine(GetPlayerPos());
        targetPos = GetNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart) { return; }
        if (Vector3.Distance(transform.position,targetPos)<=0.1f) {
            targetPos = GetNextPoint();
        }
    }
	private void FixedUpdate()
	{
        if (!isStart) { return; }
        transform.LookAt(player);
        Vector3 movevecter = targetPos - transform.position;
        if (movevecter.magnitude<=1) {
            movevecter = player.position - transform.position;
        }
        transform.position += (movevecter.normalized*Time.deltaTime)*speed;
	}
    IEnumerator GetPlayerPos()//プレイヤーの情報を一定間隔で保存
    {
        while (true) {
            playerPath.Add(player.position);
            if (playerPath.Count >= maxPlayerDataNum) {
                playerPath.RemoveAt(0);
            }
            yield return new WaitForSeconds(saveLate);
        }
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
    Vector3 GetNextPoint()
    {
        Vector3 point;
        if (playerPath.Count == 0)
        {
            point = player.transform.position;
        }
        else {
            point = playerPath[playerPath.Count-1];
        }
        return point;
    }
}
