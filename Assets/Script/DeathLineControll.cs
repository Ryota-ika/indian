using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLineControll : MonoBehaviour
//制作担当　田上
//後ろから追いかけてくる幽霊を制御する
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

    bool isHit=false;
    bool isStart=false;
    List<Vector3> playerPath = new List<Vector3>();
    Vector3 targetPos=new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(StartCount());
        //StartCoroutine(GetPlayerPos());
        targetPos = GetNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart) { return; }
        if (Vector3.Distance(transform.position,targetPos)<=1) {//ターゲットの位置に近づいたらターゲット変更
            targetPos = GetNextPoint();
        }
    }
	private void FixedUpdate()
	{
        if (!isStart) { return; }
        transform.LookAt(player);
        Vector3 movevecter = targetPos - transform.position;//ターゲットの位置に向かうベクトルを生成
        transform.position += (movevecter.normalized*Time.deltaTime)*speed;//向かう量を1で正規化し、そこに速さをかける
	}
    public IEnumerator GetPlayerPos()//プレイヤーの情報を一定間隔で保存
    {
        while (true) {
            playerPath.Add(player.position);
            if (playerPath.Count >= maxPlayerDataNum) {
                playerPath.RemoveAt(0);
            }
            yield return new WaitForSeconds(saveLate);
        }
    }
	public IEnumerator StartCount()//スタートするまで待機するコルーチン
    {
        /*float time=0;
        while (time<=startTime) {
            time += Time.deltaTime;
        }*/
        yield return null;
        Debug.Log("幽霊が動き出した");
        isStart = true;

    }
    public Vector3 GetNextPoint()//次の目標地点を取得
    {
        Vector3 point;
        if (playerPath.Count == 0)
        {
            point = player.transform.position;
        }
        else {
            point = playerPath[playerPath.Count-1];
            if (Mathf.Abs(targetPos.magnitude - point.magnitude) <= 0.1f) {
                point = player.transform.position;
            }
        }
        return point;
    }
	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "player") {
            Debug.Log("プレイヤーに衝突した");
            isHit = true;
        }
    }
    public bool GetIsHit() {
        return isHit;
    }
    public bool GetIsStart()
	{
        return isStart;
	}

}
