using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapSetPlayer : MonoBehaviour
{
    public GameObject targetObject; // 対象のオブジェクト
    public List<GameObject> otherObjects; // 他のオブジェクトのリスト
    private GameObject nearestObject; // 最も近いオブジェクト
    public int nearestObjectIndex = 0; // 最も近いオブジェクトのインデックス
    [SerializeField]
    private GameObject icon; // アイコンのインスタンス
    public Transform playerTransform; // プレイヤーのトランスフォームをInspectorで関連付ける
    private void Update()
    {
        FindNearestObject();
        IconRoatition();
       // Debug.Log(nearestObjectIndex);
    }

    void FindNearestObject()
    {
        float nearestDistance = float.MaxValue;

        for (int i = 0; i < otherObjects.Count; i++)
        {
            GameObject obj = otherObjects[i];
            float distance = Vector3.Distance(targetObject.transform.position, obj.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestObject = obj;
                nearestObjectIndex = i; // 最も近いオブジェクトのインデックスを更新
            }
        }
    }
   void IconRoatition()
    {
        Quaternion playerRotation = playerTransform.rotation;
        //Z軸の回転情報を取得
        float zRotation = playerRotation.eulerAngles.y; // Y軸の回転情報をZ軸に適用する場合
                                                        //オブジェクトの回転情報にZ軸の回転情報を適用
        Vector3 newRotation = icon.transform.rotation.eulerAngles;
        newRotation.z = -zRotation;
        //オブジェクトの回転情報を設定
      icon.transform.rotation = Quaternion.Euler(newRotation);

    }
}
