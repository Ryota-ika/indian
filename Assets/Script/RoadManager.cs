using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadManager : MonoBehaviour
{
    SensingPazl[,] pieces;
    [SerializeField]
    Vector2Int maxMapSize;
    [Header("�����X�g(����`�E��)")]
    [SerializeField]
    List<GameObject> road_List;
    GameObject[,] roads;
    [Header("�p�Y���Ǘ��N���X")]
    [SerializeField]
    Pazlcell pazzleManeger;
    [Header("��1�s�[�X�̑傫��")]
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
        GameObject from_Copy = roads[from.x, from.y];//����p�̈ꎞ�R�s�[�쐬
        roads[from.x, from.y] = roads[target.x, target.y];//�z����̗v�f�����ւ���
        roads[target.x, target.y] = from_Copy;
        roads[from.x, from.y].transform.position = new Vector3(from.x * road_Scale, 0, from.y * road_Scale);
        roads[target.x, target.y].transform.position = new Vector3(target.x * road_Scale, 0, target.y * road_Scale);
    }
    IEnumerator RoadSetUp()//2�����z��ւ̊i�[������
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
