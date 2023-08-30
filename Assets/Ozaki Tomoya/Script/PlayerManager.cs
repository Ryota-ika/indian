using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float saveInterval = 1.0f; // 保存間隔（秒）
    [SerializeField]
    Transform player;
    [Header("プレイヤー位置情報保持数上限")]
    [SerializeField]
    int maxPlayerDataNum;
    List<Vector3> playerPath = new List<Vector3>();

    private void Start()
    {
        StartCoroutine(GetPlayerPos());

    }
    IEnumerator GetPlayerPos()//プレイヤーの情報を一定間隔で保存
    {
        while (true)
        {
            playerPath.Add(player.position);
            if (playerPath.Count >= maxPlayerDataNum)
            {
                playerPath.RemoveAt(0);
            }
            yield return new WaitForSeconds(saveInterval);
        }
    }
   
}
    





