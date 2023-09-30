using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMap : MonoBehaviour
{   //ミニマップ用
    //ミニマップ用
    public Transform playerTransform;
    [SerializeField]
  //  float Speed = 0f;
    float playerXPosition;
    float playerYPosition;
    private PlayerCtrl playerController;


    private Vector3 lastPlayerPosition;  // 前フレームのプレイヤー位置
    [SerializeField]
    private float iconMoveSpeed = 3f;    // アイコンの移動スピード
    [SerializeField]
    private GameObject iconPosition;     // 目標位置
    public bool turnRight = false;
    private void Start()
    {
        // プレイヤーのTransformを取得
        playerTransform = GameObject.Find("Player").transform;
   
        lastPlayerPosition = playerTransform.position;
    }
    //プレイヤーの移動方法と同じにする
    //曲がりかたも

    private void Update()
    {
        if (turnRight)
        {
            TriggerMoveTurnRight();
        }
      /*  else if (playerController.turnLeft)
        {
            playerController.MoveTurnLeft();
        }*/
        else

        {
            playermovema();
        }
   
        // PlayerMoveMap();
       
    }

 //   void PlayerMoveMap()
 //   {

 //       Quaternion playerRotation = playerTransform.rotation;
 //       // Z軸の回転情報を取得
 //       float zRotation = playerRotation.eulerAngles.y; // Y軸の回転情報をZ軸に適用する場合
 //       // オブジェクトの回転情報にZ軸の回転情報を適用
 //       Vector3 newRotation = transform.rotation.eulerAngles;
 //       newRotation.z = -zRotation;
 //       // オブジェクトの回転情報を設定
 //       transform.rotation = Quaternion.Euler(newRotation);

 //       Vector3 newLocalPosition = transform.position;
 //       // アイコンの移動
 //       playerXPosition = playerTransform.position.x;
 //       playerYPosition = playerTransform.position.z;
 //       newLocalPosition.y = playerYPosition * Speed; // 例: プレイヤーのZ座標をY座標に適用
	//	if (newRotation.z <= -70f && newRotation.z >= -100f)
	//	{
	//		// ここにアイコンのX座標を変更するコードを追加
	//		newLocalPosition.x = playerXPosition * Speed;
	//	}
	//	transform.position = newLocalPosition;
	//	Debug.Log(newLocalPosition);
	//}
    void playermovema()
    {
        iconPosition.transform.position += iconPosition.transform.up * iconMoveSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TurnRight")
        {
            turnRight = true;
        }
    /*    if (collision.gameObject.tag == "TurnLeft")
        {
            playerController.turnLeft = true;
        }*/
    }
    public void TriggerMoveTurnRight()
    {
        // PlayerCtrlのMoveTurnRightメソッドを呼び出す
        playerController.MoveTurnRight();
    }
}
