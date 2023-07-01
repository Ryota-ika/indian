using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class Pazlcell : MonoBehaviour
{

   
    bool touchFlag = false;//マウスが押されているとき
    bool isMovePice=false;//Piceの移動用（移動しているときはtrue）

    //RectTransform r, r2;
    //Vector2 m;
    //Vector3 SecondPos;
    //Vector3 currenSwipePos;
    //float datectionButton = -0.8f;
    //float datetctionup = 0.8f;


    Vector3 PicePos_Target, PicePos_Target2;//移動予定位置
    Vector3 first_Pos;//タップ時のポインターの位置
    Vector3 Piec_Now;//移動前の現在位置
    Vector3 Piec_Now2;//移動前の現在位置
    private int posNum_Now;
    private int posNum_Now2;
    private int pos_Traget;
    private int pos_Traget2;
    private int dif_PosNum, dif_PosNum2;

    public SensingPazl ClasesensingPazl;//呼び出し用
    public int Piec_Num =0 ;//Piceの番号用

    // Start is called before the first frame update
    void Start()
    {
		posNum_Now = Piec_Num;
		posNum_Now2 = Piec_Num;
		Piec_Now = transform.position;
        Piec_Now2 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SensingTouch();
    }
	public void SensingTouch()
    {


        if (touchFlag)
        {
            Vector3 mousePosNow = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosNow.z = 0;
            Vector3 mouseposDif = mousePosNow - first_Pos;//押された位置からマウスの移動方向と距離
            Vector3 MovePiec = Piec_Now + mouseposDif;//現在位置にマウスの移動距離をたす
            

            //移動範囲設定
            if (Piec_Now2.x >= PicePos_Target2.x)
            {
                MovePiec.x = Mathf.Clamp(MovePiec.x, PicePos_Target2.x, Piec_Now2.x);
            }
            else
            {
                MovePiec.x = Mathf.Clamp(MovePiec.x, Piec_Now2.x, PicePos_Target2.x);
            }
            if (Piec_Now2.y >= PicePos_Target2.y)
            {
                MovePiec.y = Mathf.Clamp(MovePiec.y, PicePos_Target2.y, Piec_Now2.y);
            }
            else
            {
                MovePiec.y = Mathf.Clamp(MovePiec.y, Piec_Now2.y, PicePos_Target2.y);
            }
             if (Piec_Now.x >= PicePos_Target.x)
            {
                MovePiec.x = Mathf.Clamp(MovePiec.x, PicePos_Target.x, Piec_Now.x);
            }
            else
            {
                MovePiec.x = Mathf.Clamp(MovePiec.x, Piec_Now.x, PicePos_Target.x);
            }
            if(Piec_Now.y>= PicePos_Target.y)
            {
                MovePiec.y = Mathf.Clamp(MovePiec.y, PicePos_Target.y, Piec_Now.y);
            }
            else
            {
                MovePiec.y = Mathf.Clamp(MovePiec.y, Piec_Now.y, PicePos_Target.y);
            }
            //このスクリプトがついたPiceの移動制御
            Piec_Now = Vector3.Lerp(transform.position, MovePiec, 0.2f);
            Piec_Now2 = Vector3.Lerp(transform.position, MovePiec, 0.2f);
        }
            else
            {
                if (isMovePice)
                {
                    transform.position= PicePos_Target;//移動予定位置
                    //transform.position = PicePos_Target2;

				    //ClasesensingPazl.PosNumMovePosible(posNum_Now);//一つ用

				    ClasesensingPazl.PosNumMovePosible1(posNum_Now, posNum_Now2);//二つ用
                    posNum_Now = pos_Traget;//移動先の場所になる
                    posNum_Now2 = pos_Traget2;
              
                    Piec_Now = PicePos_Target;
				    Piec_Now2 = PicePos_Target2;

				    isMovePice = false;
                }
            }


            //if(touchFlag)
            //{
            //    if (currenSwipePos.y > 0 && currenSwipePos.x > datectionButton && currenSwipePos.x < datetctionup)
            //    {
            //        //SensingPazl.Instance.check(Xpos, Ypos, thisTile);
            //        Debug.Log("上");
            //        Debug.Log("スワイプしたよ");
            //         r.localPosition += new Vector3(0, 1, 0);
            //    }
                
            //    if (currenSwipePos.y < 0 && currenSwipePos.x > datectionButton && currenSwipePos.x < datetctionup)
            //    {
            //        Debug.Log("下");
            //        Debug.Log("スワイプしたよ");
            //        r.localPosition += new Vector3(0, -1, 0);
            //    }
            //   if (currenSwipePos.x < 0 && currenSwipePos.y > datectionButton && currenSwipePos.y < datetctionup)
            //    {
            //        Debug.Log("左");
            //        Debug.Log("スワイプしたよ");
            //        r.localPosition += new Vector3(-1, 0, 0);
            //    }   
            //    if (currenSwipePos.x > 0 && currenSwipePos.y > datectionButton && currenSwipePos.y < datetctionup)
            //    {
            //        Debug.Log("右");
            //        Debug.Log("スワイプしたよ");
            //        r.localPosition += new Vector3(1, 0, 0);
            //   }
            //}
        
    }

    public void MouceClickDown()//移動できるかの判定
    {

        touchFlag = true;
        isMovePice = true;

       /* pos_Traget = ClasesensingPazl.MovePossble();*/ //穴一つ用
         (pos_Traget,pos_Traget2) = ClasesensingPazl.MobePossble1();///二つ用
        dif_PosNum = pos_Traget - posNum_Now;//移動予定位置の番号から現在の番号を引く
        PicePos_Target = Piec_Now;

        dif_PosNum2 =pos_Traget2 - posNum_Now2;
		PicePos_Target2 = Piec_Now2;
		////3* 3  の場合
		//if (dif_PosNum == 3)
		//{
		//	PicePos_Target.y -= 0.63f;
		//}
		//else if (dif_PosNum == -3)
		//{
		//	PicePos_Target.y += 0.63f;
		//}
		//else if (dif_PosNum == 1 && (posNum_Now != 3 && posNum_Now != 6))
		//{
		//	PicePos_Target.x += 0.64f;
		//}
		//else if (dif_PosNum == -1 && (posNum_Now != 4 && posNum_Now != 7))
		//{
		//	PicePos_Target.x -= 0.64f;
		//}
		//else
		//{
		//	touchFlag = false;
		//	isMovePice = false;
		//	return;
		//}

		//4 * 5場合
		//一つ目
		if (dif_PosNum == 4 )
		{
			PicePos_Target.y -= 0.63f;//下に移動
      
		}
		else if (dif_PosNum == -4 )
		{
			PicePos_Target.y += 0.63f;//上に移動

        }
		else if (dif_PosNum == 1 && (posNum_Now != 4 && posNum_Now != 8 && posNum_Now != 12 && posNum_Now != 16))
		{
			PicePos_Target.x += 0.64f;//右に移動

        }
		else if (dif_PosNum == -1 && (posNum_Now != 5 && posNum_Now != 9 && posNum_Now != 13 && posNum_Now != 17))
		{
			PicePos_Target.x -= 0.64f;//左に移動

        }
		//二つ目
		else if (dif_PosNum2 == 4)
		{

			PicePos_Target2.y -= 0.63f;
		}
		else if (dif_PosNum2 ==-4)
		{

			PicePos_Target2.y += 0.63f;
		}
		else if (dif_PosNum2 == 1 && (posNum_Now2 != 4 && posNum_Now2 != 8 && posNum_Now2 != 12 && posNum_Now2 !=16))
		{

			PicePos_Target2.x += 0.64f;
		}
		else if (dif_PosNum2 == -1 && (posNum_Now2 != 5 && posNum_Now2 != 9 && posNum_Now2 != 13 && posNum_Now2 != 17))
		{

			PicePos_Target2.x -= 0.64f;
		}
		else
		{
			touchFlag = false;
			isMovePice = false;
			return;
		}

      
        //Piec_Now = transform.position;
        //PicePos_Target = Piec_Now;
        //PicePos_Target.x += 1.0f;
        //Debug.Log("Down");
    }

    public void MouseClickUp() 
    {
        touchFlag =false;

        Debug.Log("Up");
    }





  
}
