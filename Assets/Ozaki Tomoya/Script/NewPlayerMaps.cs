using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMaps : MonoBehaviour
{
    public Transform playerObject; // プレイヤーオブジェクトのTransformコンポーネント
    public Transform[,] puzzlePieces;
    public GameObject playerIcon; // プレイヤーアイコンのゲームオブジェクト
    private Vector2Int currentPlayerPieceIndex = Vector2Int.zero; // 現在のパズルピースのインデックス

    private void Update()
    {
        // プレイヤーオブジェクトの現在の位置を取得
        Vector3 playerPosition = playerObject.position;

        // プレイヤーの位置を特定したパズルピースの位置に合わせる
        Vector2Int newPlayerPieceIndex = FindPlayerPieceIndex(playerPosition);

        if (newPlayerPieceIndex != currentPlayerPieceIndex)
        {
            // プレイヤーの位置が変化した場合の処理をここに記述
            Debug.Log("プレイヤーの位置が変化しました。新しい位置のパズルピースインデックス: " + newPlayerPieceIndex);

            // アイコンを表示したいパズルピースに対応する位置にプレイヤーアイコンを配置
            Transform pieceTransform = puzzlePieces[newPlayerPieceIndex.x, newPlayerPieceIndex.y];
            playerIcon.transform.position = pieceTransform.position;

            // 現在のパズルピースインデックスを更新
            currentPlayerPieceIndex = newPlayerPieceIndex;
        }
    }

    // プレイヤーの位置をパズルピースの位置と比較して特定するメソッド
    private Vector2Int FindPlayerPieceIndex(Vector3 playerPosition)
    {
        if (puzzlePieces == null)
        {
            Debug.LogWarning("puzzlePieces is not assigned.");
            return Vector2Int.zero; // 適切な初期値を返すか、エラーハンドリングを追加する
        }
        for (int x = 0; x < puzzlePieces.GetLength(0); x++)
        {
            for (int y = 0; y < puzzlePieces.GetLength(1); y++)
            {
                Transform pieceTransform = puzzlePieces[x, y];
                float distance = Vector3.Distance(playerPosition, pieceTransform.position);

                // 適切な距離内にプレイヤーがいるかどうかを判定
                if (distance < 1.0f) // 1.0fは適切な距離
                {
                    return new Vector2Int(x, y); // プレイヤーの位置が特定されたらそのパズルピースのインデックスを返す
                }
            }
        }
        return Vector2Int.zero; // プレイヤーがどの位置にもいない場合は(0, 0)を返すか、適切な初期値に応じて変更
    }
}
