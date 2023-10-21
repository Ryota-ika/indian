using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMaps : MonoBehaviour
{
    public Transform playerObject; // �v���C���[�I�u�W�F�N�g��Transform�R���|�[�l���g
    public Transform[,] puzzlePieces;
    public GameObject playerIcon; // �v���C���[�A�C�R���̃Q�[���I�u�W�F�N�g
    private Vector2Int currentPlayerPieceIndex = Vector2Int.zero; // ���݂̃p�Y���s�[�X�̃C���f�b�N�X

    private void Update()
    {
        // �v���C���[�I�u�W�F�N�g�̌��݂̈ʒu���擾
        Vector3 playerPosition = playerObject.position;

        // �v���C���[�̈ʒu����肵���p�Y���s�[�X�̈ʒu�ɍ��킹��
        Vector2Int newPlayerPieceIndex = FindPlayerPieceIndex(playerPosition);

        if (newPlayerPieceIndex != currentPlayerPieceIndex)
        {
            // �v���C���[�̈ʒu���ω������ꍇ�̏����������ɋL�q
            Debug.Log("�v���C���[�̈ʒu���ω����܂����B�V�����ʒu�̃p�Y���s�[�X�C���f�b�N�X: " + newPlayerPieceIndex);

            // �A�C�R����\���������p�Y���s�[�X�ɑΉ�����ʒu�Ƀv���C���[�A�C�R����z�u
            Transform pieceTransform = puzzlePieces[newPlayerPieceIndex.x, newPlayerPieceIndex.y];
            playerIcon.transform.position = pieceTransform.position;

            // ���݂̃p�Y���s�[�X�C���f�b�N�X���X�V
            currentPlayerPieceIndex = newPlayerPieceIndex;
        }
    }

    // �v���C���[�̈ʒu���p�Y���s�[�X�̈ʒu�Ɣ�r���ē��肷�郁�\�b�h
    private Vector2Int FindPlayerPieceIndex(Vector3 playerPosition)
    {
        if (puzzlePieces == null)
        {
            Debug.LogWarning("puzzlePieces is not assigned.");
            return Vector2Int.zero; // �K�؂ȏ����l��Ԃ����A�G���[�n���h�����O��ǉ�����
        }
        for (int x = 0; x < puzzlePieces.GetLength(0); x++)
        {
            for (int y = 0; y < puzzlePieces.GetLength(1); y++)
            {
                Transform pieceTransform = puzzlePieces[x, y];
                float distance = Vector3.Distance(playerPosition, pieceTransform.position);

                // �K�؂ȋ������Ƀv���C���[�����邩�ǂ����𔻒�
                if (distance < 1.0f) // 1.0f�͓K�؂ȋ���
                {
                    return new Vector2Int(x, y); // �v���C���[�̈ʒu�����肳�ꂽ�炻�̃p�Y���s�[�X�̃C���f�b�N�X��Ԃ�
                }
            }
        }
        return Vector2Int.zero; // �v���C���[���ǂ̈ʒu�ɂ����Ȃ��ꍇ��(0, 0)��Ԃ����A�K�؂ȏ����l�ɉ����ĕύX
    }
}
