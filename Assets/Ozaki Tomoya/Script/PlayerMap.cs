using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerMap : MonoBehaviour
{   //�~�j�}�b�v�p
    //�~�j�}�b�v�p
    /*    public Transform playerTransform; // �v���C���[�̃g�����X�t�H�[����Inspector�Ŋ֘A�t����
        public Transform iconTransform;   // �A�C�R���̃g�����X�t�H�[����Inspector�Ŋ֘A�t����
        [SerializeField]
      //  float Speed = 0f;
        float playerXPosition;
        float playerYPosition;
        //private PlayerCtrl playerController;


        private Vector3 lastPlayerPosition;  // �O�t���[���̃v���C���[�ʒu
        [SerializeField]
        private float iconMoveSpeed = 3f;    // �A�C�R���̈ړ��X�s�[�h
        [SerializeField]
        private GameObject iconPosition;     // �ڕW�ʒu
        *//*public bool turnRight = false;*//*
        //10�ǉ���
        public Transform startingPosition; // �A�C�R���̃X�^�[�g�ʒu��Inspector�Ŋ֘A�t����
        private float previousPlayerZ;*/
    [SerializeField]
    Pazlcell pazzleManeger;
    public Transform playerObject; // �v���C���[�I�u�W�F�N�g��Transform�R���|�[�l���g
    public Transform[] puzzlePieces; // �p�Y���s�[�X��Transform�R���|�[�l���g�̔z��
    public GameObject playerIcon; // �v���C���[�A�C�R���̃Q�[���I�u�W�F�N�g


    private void Start()
    {
        // �v���C���[��Transform���擾
/*        playerTransform = GameObject.Find("Player").transform;
        lastPlayerPosition = playerTransform.position;*/

        // �A�C�R���̈ʒu���X�^�[�g�ʒu�ɐݒ�
      /*  startingPosition.position = transform.position;
        playerYPosition = startingPosition.position.y;*/
        // �A�C�R���̃X�P�[����1/86�ɕύX
        // transform.localScale = initialScale * scaleFactor;



    }
    //�v���C���[�̈ړ����@�Ɠ����ɂ���
    //�Ȃ��肩����

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

        // �v���C���[�̌��݂̈ʒu���擾


    }
  

    void PlayerMoveMap()
	{
	/*	Quaternion playerRotation = playerTransform.rotation;
		//Z���̉�]�����擾
		float zRotation = playerRotation.eulerAngles.y; // Y���̉�]����Z���ɓK�p����ꍇ
		//�I�u�W�F�N�g�̉�]����Z���̉�]����K�p
        Vector3 newRotation = transform.rotation.eulerAngles;
		newRotation.z = -zRotation;
		//�I�u�W�F�N�g�̉�]����ݒ�
		transform.rotation = Quaternion.Euler(newRotation);

		Vector3 newLocalPosition =new Vector3(0,0,0);
		//�A�C�R���̈ړ�
	    playerXPosition = playerTransform.localPosition.x/300;
		playerYPosition = playerTransform.localPosition.z/215;
        newLocalPosition.y = playerYPosition; // ��: �v���C���[��Z���W��Y���W�ɓK�p
        *//*if (newRotation.z <= -70f && newRotation.z >= -100f)
		{
			
          
        }*//*
        //�����ɃA�C�R����X���W��ύX����R�[�h��ǉ�
        newLocalPosition.x = playerXPosition;
        transform.localPosition = newLocalPosition;
        Debug.Log("playerXposition" + playerXPosition);*/
    }
    //void playermovema()
    //   {
    //       // ���̏�����ǉ��ł��܂�
    //       float currentPlayerZ = playerTransform.position.z/5f;
    //       if (currentPlayerZ != previousPlayerZ)
    //       {
    //           // �v���C���[��Z�����ύX���ꂽ�ꍇ�A�A�C�R����Y���𓮂���
    //           Vector3 newPosition = startingPosition.position;
    //           newPosition.y = currentPlayerZ; // ������Y���̕ύX���s��
    //           transform.position = newPosition;
    //           Debug.Log(newPosition);
    //       }

    //       // �O��̃t���[���ł̃v���C���[��Z���ʒu���X�V
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
          // PlayerCtrl��MoveTurnRight���\�b�h���Ăяo��
          //playerController.MoveTurnRight();
      }*/



}
