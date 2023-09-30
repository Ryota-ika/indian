using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.Events;
using TMPro;
using System;

public class Pazlcell : MonoBehaviour
{
	[Header("スラパ移動量")]
	[SerializeField]
	float movePow;
	//マップサイズと空き箇所をプロパティから設定可能にしました
	[Header("マップのタテヨコサイズ")]
	[SerializeField]
	Vector2Int maxMapSize;
	[Header("スラパの空き箇所")]
	[SerializeField]
	Vector2Int voidPos;
	//bool touchFlag = false;//マウスが押されているとき
	//bool isMovePice = false;//Piceの移動用（移動しているときはtrue）
	public static event UnityAction<Vector2Int, Vector2Int> swapTrrigerd;
	//RectTransform r, r2;
	//Vector2 m;
	//Vector3 SecondPos;
	//Vector3 currenSwipePos;
	//float datectionButton = -0.8f;
	//float datetctionup = 0.8f;


	/*Vector3 PicePos_Target, PicePos_Target2;//移動予定位置
	Vector3 first_Pos;//タップ時のポインターの位置
	Vector3 Piec_Now;//移動前の現在位置
	Vector3 Piec_Now2;//移動前の現在位置
	private int posNum_Now;
	private int posNum_Now2;
	private int pos_Traget;
	private int pos_Traget2;
	private int dif_PosNum, dif_PosNum2;*/
	[SerializeField]
	SensingPazl PiecePrefub;
	// SensingPazl ClasesensingPazl;//呼び出し用
	// public int Piec_Num =0 ;//Piceの番号用
	//07-03
	SensingPazl[,] pieces;
	Sprite[] sprites;
	[SerializeField]
	//selialize指定するために一旦リストに格納することにしました。
	//左上→右下の順番で入れないとバグります(申し訳ない)
	//ここは分かりづらくなってしまったので後で自動化できないか試します。
	List<SensingPazl> pieces_List = new List<SensingPazl>();
    //8月追加
    [SerializeField]
    GameObject playerIcon; // プレイヤーの位置を示す2DオブジェクトをInspectorから関連付けます
    private Vector2Int playerPosition; // プレイヤーの位置情報を格納する変数
    [Header("プレイヤーのTransform")]
    public Transform playerIconpos; // プレイヤーのTransform

	// Start is called before the first frame update
	void Start()
	{
		//Piece3x3();
		PieceInit(voidPos, maxMapSize);
/*       PlayerCtrl.PlayerMoved += OnPlayerMoved;*/
    }

	public SensingPazl[,] GetPices()
	{
		return pieces;
	}
	// Update is called once per frame
	void Update()
	{
		//SensingTouch();
		UpdatePlayerIconPosition();
    }
	//0703
	//プロパティを参照することで生成関数を可変にしました
	void PieceInit(Vector2Int voidPos, Vector2Int MapSize)
	{
		int n = 0;
		pieces = new SensingPazl[MapSize.x, MapSize.y];
		if (maxMapSize.x * maxMapSize.y != pieces_List.Count)
		{
			Debug.LogError("マップサイズの指定とパズルピースの多さが一致しません");
		}
		//リストから1個ずつ要素を抽出して2次元配列に代入しています
		//これで疑似的にserialize化を実現してます
		for (int y = maxMapSize.y - 1; y >= 0; y--)
		{
			for (int x = 0; x < maxMapSize.x; x++)
			{
				if (new Vector2Int(x, y) == voidPos)
				{
					pieces[x, y] = null;
					n++;
					continue;
				}
				SensingPazl Piece = pieces_List[n];

				Piece.Init(x, y, n + 1, ClickSwap);
				pieces[x, y] = Piece;
				n++;
			}
		}
	}

	void ClickSwap(int x, int y)//pieceと何もない空間を入れ替えて配列情報を更新
	{


		var PieceX = GetPieceX(x, y);
		var PieceY = GetPieceY(x, y);
		var from = pieces[x, y];
		var target = pieces[x + PieceX, y + PieceY];
		pieces[x, y] = null;
		pieces[x + PieceX, y + PieceY] = from;
		from.UpdatePos(PieceX, PieceY, movePow);

		// 入れ替わった位置を引数としてトリガーを発行
		swapTrrigerd.Invoke(new Vector2Int(x, y), new Vector2Int(x + PieceX, y + PieceY));

	}
	int GetPieceX(int x, int y)//引数で指定したところに隙間があったら移動させるための数値を返す
	{
		if (x < maxMapSize.x - 1)
		{
			if (pieces[x + 1, y] == null)
			{
				return 1;
			}
		}

		if (x > 0)
		{
			if (pieces[x - 1, y] == null)
			{
				return -1;
			}
		}
		return 0;
	}

	int GetPieceY(int x, int y)
	{
		if (y < maxMapSize.y - 1)
		{
			if (pieces[x, y + 1] == null)
			{
				return 1;
			}
		}

		if (y > 0)
		{
			if (pieces[x, y - 1] == null)
			{
				return -1;
			}
		}
		return 0;
	}
	public void AddToPieceList(SensingPazl Piece)
	{
		pieces_List.Add(Piece);
	}
	public void SetVoidPos(Vector2Int value)
	{
		voidPos = value;
	}
	public void SetMapSize(Vector2Int value)
	{
		maxMapSize = value;
	}
    //8月追加

    void UpdatePlayerIconPosition()
    {
        Vector3 playerPosition = playerIconpos.position;
        SensingPazl nearestPiece = null;
        float nearestDistance = 3f;
        Vector2Int playerIconIndex = Vector2Int.zero; // プレイヤーアイコンの位置のインデックスを保持する変数
        for (int x = 0; x < pieces.GetLength(0); x++)
        {
            for (int y = 0; y < pieces.GetLength(1); y++)
            {

				SensingPazl piece = pieces[x, y];
				if (piece != null)
                {
                    Vector3 piecePosition = piece.transform.position;
                    float distance = Vector3.Distance(playerPosition, piecePosition);
                 
                    // 最も近いピースを探す
                    if (distance < nearestDistance)
                    {
                        nearestPiece = piece;
                        nearestDistance = distance;
                        playerIconIndex = new Vector2Int(x, y); // プレイヤーアイコンの位置のインデックスを更新
                    }
                }
				

			}
        }
		
		if (nearestPiece != null)
        {

            // 最も近いピースが見つかった場合の処理を行う
            Vector2Int newPlayerIconPosition = playerIconIndex;
			// 新しい位置を使用してプレイヤーアイコンを移動
			// playerIcon.transform.position = new Vector3();//プレイヤーの位置をと同じ場所にしたい

			//if (newPlayerIconPosition == PiecePrefub.posIndex)
			//{
			//	Debug.Log("プレイヤーアイコンの新しい位置: " + newPlayerIconPosition);

			//	// クリック操作を無効にする
			//	nearestPiece.SetClickEnabled(false);
			//}
			//else
			//{
			//	// クリック操作を有効にする
			//	nearestPiece.SetClickEnabled(true);
			//}
			foreach (SensingPazl piece in pieces_List)
			{
				if (piece != null)
				{
					if (newPlayerIconPosition != piece.posIndex)
					{
						piece.canBeClicked = true;
					}
					else
					{
						piece.canBeClicked = false;
					}
				}
			}
		}
    }


    private void OnPlayerMoved(Vector2Int newPosition)
    {
        Debug.Log("プレイヤーの位置が更新されました: " + newPosition);
        // プレイヤーの位置を更新
        playerPosition = newPosition;

        // プレイヤーの位置に2Dオブジェクトを移動
        Vector3 playerIconPosition = new Vector3(playerPosition.x * movePow, 0, playerPosition.y * movePow);
        playerIcon.transform.position = playerIconPosition;
    }

}

