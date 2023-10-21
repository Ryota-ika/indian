using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerMap : MonoBehaviour
{   //ミニマップ用
    //ミニマップ用
    /*    public Transform playerTransform; // プレイヤーのトランスフォームをInspectorで関連付ける
        public Transform iconTransform;   // アイコンのトランスフォームをInspectorで関連付ける
        [SerializeField]
      //  float Speed = 0f;
        float playerXPosition;
        float playerYPosition;
        //private PlayerCtrl playerController;


        private Vector3 lastPlayerPosition;  // 前フレームのプレイヤー位置
        [SerializeField]
        private float iconMoveSpeed = 3f;    // アイコンの移動スピード
        [SerializeField]
        private GameObject iconPosition;     // 目標位置
        *//*public bool turnRight = false;*//*
        //10追加分
        public Transform startingPosition; // アイコンのスタート位置をInspectorで関連付ける
        private float previousPlayerZ;*/
    [SerializeField]
    Pazlcell pazzleManeger;
    public Transform playerObject; // プレイヤーオブジェクトのTransformコンポーネント
    public Transform[] puzzlePieces; // パズルピースのTransformコンポーネントの配列
    public GameObject playerIcon; // プレイヤーアイコンのゲームオブジェクト


    private void Start()
    {
        // プレイヤーのTransformを取得
/*        playerTransform = GameObject.Find("Player").transform;
        lastPlayerPosition = playerTransform.position;*/

        // アイコンの位置をスタート位置に設定
      /*  startingPosition.position = transform.position;
        playerYPosition = startingPosition.position.y;*/
        // アイコンのスケールを1/86に変更
        // transform.localScale = initialScale * scaleFactor;



    }
    //プレイヤーの移動方法と同じにする
    //曲がりかたも

    private void Update()
    {
      




        /*	if (turnRight)
            {
                TriggerMoveTurnRight();
            }*/
        /*else if (playerController.turnLeft)
		{
			playerController.MoveTurnLeft();
		}*/
        /*else

		{
			//playermovema();
		}*/
        /* PlayerMoveMap();*/

        // プレイヤーの現在の位置を取得


    }
  

    void PlayerMoveMap()
	{
	/*	Quaternion playerRotation = playerTransform.rotation;
		//Z軸の回転情報を取得
		float zRotation = playerRotation.eulerAngles.y; // Y軸の回転情報をZ軸に適用する場合
		//オブジェクトの回転情報にZ軸の回転情報を適用
        Vector3 newRotation = transform.rotation.eulerAngles;
		newRotation.z = -zRotation;
		//オブジェクトの回転情報を設定
		transform.rotation = Quaternion.Euler(newRotation);

		Vector3 newLocalPosition =new Vector3(0,0,0);
		//アイコンの移動
	    playerXPosition = playerTransform.localPosition.x/300;
		playerYPosition = playerTransform.localPosition.z/215;
        newLocalPosition.y = playerYPosition; // 例: プレイヤーのZ座標をY座標に適用
        *//*if (newRotation.z <= -70f && newRotation.z >= -100f)
		{
			
          
        }*//*
        //ここにアイコンのX座標を変更するコードを追加
        newLocalPosition.x = playerXPosition;
        transform.localPosition = newLocalPosition;
        Debug.Log("playerXposition" + playerXPosition);*/
    }
    //void playermovema()
    //   {
    //       // 他の処理を追加できます
    //       float currentPlayerZ = playerTransform.position.z/5f;
    //       if (currentPlayerZ != previousPlayerZ)
    //       {
    //           // プレイヤーのZ軸が変更された場合、アイコンのY軸を動かす
    //           Vector3 newPosition = startingPosition.position;
    //           newPosition.y = currentPlayerZ; // ここでY軸の変更を行う
    //           transform.position = newPosition;
    //           Debug.Log(newPosition);
    //       }

    //       // 前回のフレームでのプレイヤーのZ軸位置を更新
    //       previousPlayerZ = currentPlayerZ;

    //   }
    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "TurnRight")
         {
             turnRight = true;
         }
     *//*    if (collision.gameObject.tag == "TurnLeft")
         {
             playerController.turnLeft = true;
         }*//*
     }*/
    /*  public void TriggerMoveTurnRight()
      {
          // PlayerCtrlのMoveTurnRightメソッドを呼び出す
          //playerController.MoveTurnRight();
      }*/



}
