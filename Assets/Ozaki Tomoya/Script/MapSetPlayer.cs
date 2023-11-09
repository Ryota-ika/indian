using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapSetPlayer : MonoBehaviour
{
    public GameObject targetObject; // �Ώۂ̃I�u�W�F�N�g
    public List<GameObject> otherObjects; // ���̃I�u�W�F�N�g�̃��X�g
    private GameObject nearestObject; // �ł��߂��I�u�W�F�N�g
    public int nearestObjectIndex = 0; // �ł��߂��I�u�W�F�N�g�̃C���f�b�N�X
    [SerializeField]
    private GameObject icon; // �A�C�R���̃C���X�^���X
    public Transform playerTransform; // �v���C���[�̃g�����X�t�H�[����Inspector�Ŋ֘A�t����
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
                nearestObjectIndex = i; // �ł��߂��I�u�W�F�N�g�̃C���f�b�N�X���X�V
            }
        }
    }
   void IconRoatition()
    {
        Quaternion playerRotation = playerTransform.rotation;
        //Z���̉�]�����擾
        float zRotation = playerRotation.eulerAngles.y; // Y���̉�]����Z���ɓK�p����ꍇ
                                                        //�I�u�W�F�N�g�̉�]����Z���̉�]����K�p
        Vector3 newRotation = icon.transform.rotation.eulerAngles;
        newRotation.z = -zRotation;
        //�I�u�W�F�N�g�̉�]����ݒ�
      icon.transform.rotation = Quaternion.Euler(newRotation);

    }
}
