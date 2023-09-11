using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class SensingPazl : MonoBehaviour
{
	//public GameObject X, Y;
	//const int CELL_X = 4;
	//const int CELL_Y = 5;
	//public int width = 4;
	//public int height = 5;
	
    public int index = 0;
    public int Maxindex =0;
    [SerializeField]
    Vector2Int posIndex;//自分の位置番号(xとyでばらばらになっていたためvec2intで統一しました)
    public int MovePossible =10; //空いている番号

    public Action<int,int>swapFunc = null; 
    //8月追加


    public void Init(int x ,int y,int index,Action<int ,int> swapFunc)
    {
        this.index = index;
        posIndex = new Vector2Int(x, y);
        this.swapFunc = swapFunc;   
 
    }

    public void UpdatePos(int i ,int j,float moveScale)//数値を代入から加算へ+intの固定値での移動ではサイズ変更に対応できないため対応できる形に変更
    {
       
        posIndex.x += i;
        posIndex.y += j;
        this.gameObject.transform.localPosition += new Vector3((float)i*moveScale,(float)j*moveScale,transform.localPosition.z);
    }


    public bool IsEmpty()
    {
        return index == Maxindex;
    }
    //8月追加分
  
    //




    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && swapFunc != null)
        {
                // プレイヤーが道ピースの上にいない場合、通常のクリック処理を行う
                swapFunc(posIndex.x, posIndex.y);
                Debug.Log("クリック処理を実行");
        }
        else
        {
            Debug.Log("プレイヤーが乗っています");
        }
    }

    
  

    //Start is called before the first frame update
    void Start()
    {
     


    }

    // Update is called once per frame
   void Update()
    {

    }


 //   public int MovePossble()
 //   {
        
 //       return  MovePossible;
 //   }

	//public (int id, int id1) MobePossble1()
	//{

	//	return (MovePossible, MovePossible1);
	//}


	//public void PosNumMovePosible(int nextMovePossible)
 //   {
 //       MovePossible  = nextMovePossible;
	//}


 //   public void PosNumMovePosible1(int nexMove, int nexMove1)
 //   {

 //       MovePossible = nexMove;
 //       MovePossible1 = nexMove1;
 //   }





    //public void check(int Xpos, int Ypos, Pazlcell thisTile)
    //{

    //	if ((Xpos - 1) >= 0)
    //	{
    //		// we can move left, is the space currently being used?
    //		return GetTileAtThisGridLocation(Xpos - 1, Ypos, thisTile);
    //		Debug.Log("左");

    //	}

    //	if ((Xpos + 1) < width)
    //	{
    //		// we can move right, is the space currently being used?
    //		return GetTileAtThisGridLocation(Xpos + 1, Ypos, thisTile);
    //		Debug.Log("右");
    //	}
    //	if ((Ypos - 1) >= 0)
    //	{
    //		// we can move down, is the space currently being used?
    //		return (Xpos, Ypos - 1, thisTile);
    //		Debug.Log("上");
    //	}
    //	if ((Ypos - 1) >= 0)
    //	{
    //		// we can move down, is the space currently being used?
    //		return GetTileAtThisGridLocation(Xpos, Ypos - 1, thisTile);
    //		Debug.Log("上");
    //	}

    //}


    //	int no = 0;
    //	if (no >= 3 && Pazls[no - 3].gameObject)
    //	{
    //		Debug.Log("上");
    //	}
    //	else if (no <= 5 && Pazls[no + 3].gameObject)
    //	{
    //		Debug.Log("上");
    //	}
    //	else if (no % 3 != 2 && Pazls[no + 1].gameObject)
    //		{
    //			Debug.Log("右");
    //		}
    //		else if (no % 3 != 0 && Pazls[no - 1].gameObject)
    //		{
    //			Debug.Log("左");
    //		}
    //	}

}


