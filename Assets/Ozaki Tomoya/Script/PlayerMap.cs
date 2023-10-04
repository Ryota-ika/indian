using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMap : MonoBehaviour
{   //�~�j�}�b�v�p
    //�~�j�}�b�v�p
    public Transform playerTransform;
    [SerializeField]
  //  float Speed = 0f;
    float playerXPosition;
    float playerYPosition;
    private PlayerCtrl playerController;


    private Vector3 lastPlayerPosition;  // �O�t���[���̃v���C���[�ʒu
    [SerializeField]
    private float iconMoveSpeed = 3f;    // �A�C�R���̈ړ��X�s�[�h
    [SerializeField]
    private GameObject iconPosition;     // �ڕW�ʒu
    public bool turnRight = false;
    private void Start()
    {
        // �v���C���[��Transform���擾
        playerTransform = GameObject.Find("Player").transform;
   
        lastPlayerPosition = playerTransform.position;
    }
    //�v���C���[�̈ړ����@�Ɠ����ɂ���
    //�Ȃ��肩����

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
 //       // Z���̉�]�����擾
 //       float zRotation = playerRotation.eulerAngles.y; // Y���̉�]����Z���ɓK�p����ꍇ
 //       // �I�u�W�F�N�g�̉�]����Z���̉�]����K�p
 //       Vector3 newRotation = transform.rotation.eulerAngles;
 //       newRotation.z = -zRotation;
 //       // �I�u�W�F�N�g�̉�]����ݒ�
 //       transform.rotation = Quaternion.Euler(newRotation);

 //       Vector3 newLocalPosition = transform.position;
 //       // �A�C�R���̈ړ�
 //       playerXPosition = playerTransform.position.x;
 //       playerYPosition = playerTransform.position.z;
 //       newLocalPosition.y = playerYPosition * Speed; // ��: �v���C���[��Z���W��Y���W�ɓK�p
	//	if (newRotation.z <= -70f && newRotation.z >= -100f)
	//	{
	//		// �����ɃA�C�R����X���W��ύX����R�[�h��ǉ�
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
        // PlayerCtrl��MoveTurnRight���\�b�h���Ăяo��
        playerController.MoveTurnRight();
    }
}
