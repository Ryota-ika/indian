using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadManager : MonoBehaviour
{
    SensingPazl[,] pieces;
    [SerializeField]
    Vector2Int maxMapSize;
    [Header("道リスト(左上～右下)")]
    [SerializeField]
    List<GameObject> road_List;
    GameObject[,] roads;
    [Header("パズル管理クラス")]
    [SerializeField]
    Pazlcell pazzleManeger;
    [Header("道1ピースの大きさ")]
    [SerializeField]
    float road_Scale;
    // Start is called before the first frame update
    void Start()
    {
        Pazlcell.swapTrrigerd += OnSwapTriigerd;
        StartCoroutine(RoadSetUp());
    }
    void OnSwapTriigerd(Vector2Int from,Vector2Int target)//
    {
        GameObject from_Copy = roads[from.x, from.y];//代入用の一時コピー作成
        roads[from.x, from.y] = roads[target.x, target.y];//配列内の要素を入れ替える
        roads[target.x, target.y] = from_Copy;
        roads[from.x, from.y].transform.position = new Vector3(from.x * road_Scale, 0, from.y * road_Scale);
        roads[target.x, target.y].transform.position = new Vector3(target.x * road_Scale, 0, target.y * road_Scale);
    }
    IEnumerator RoadSetUp()//2次元配列への格納をする
    {
        roads = new GameObject[maxMapSize.x, maxMapSize.y];
        int n=0;
        for (int y=maxMapSize.y-1;y>=0;y--) {
            for (int x=0;x<maxMapSize.x;x++) {
                roads[x, y] = road_List[n];
                n++;
            }
        }
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddToRoadList(GameObject item)
    {
        road_List.Add(item);
    }
}
