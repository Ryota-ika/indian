using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float saveInterval = 1.0f; // �ۑ��Ԋu�i�b�j
    [SerializeField]
    Transform player;
    [Header("�v���C���[�ʒu���ێ������")]
    [SerializeField]
    int maxPlayerDataNum;
    List<Vector3> playerPath = new List<Vector3>();

    private void Start()
    {
        StartCoroutine(GetPlayerPos());

    }
    IEnumerator GetPlayerPos()//�v���C���[�̏������Ԋu�ŕۑ�
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
    





