//7/10
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObject : MonoBehaviour
{
    //道の方向を示す列挙型（上下、左右、円）
    [SerializeField] public Direction roadDirection;
    //次のオブジェクトへの参照
    [SerializeField] public RoadObject nextRoad;

    public enum Direction
    {
        UpDown,  //上下
        LeftRight,　　//左右
        Circular,　　//円
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
