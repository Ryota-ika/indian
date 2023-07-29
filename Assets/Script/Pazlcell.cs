using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.Events;

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
    bool touchFlag = false;//マウスが押されているとき
    bool isMovePice=false;//Piceの移動用（移動しているときはtrue）
	public static event UnityAction<Vector2Int,Vector2Int> swapTrrigerd;
	//RectTransform r, r2;
	//Vector2 m;
	//Vector3 SecondPos;
	//Vector3 currenSwipePos;
	//float datectionButton = -0.8f;
	//float datetctionup = 0.8f;


	Vector3 PicePos_Target, PicePos_Target2;//移動予定位置
    Vector3 first_Pos;//タップ時のポインターの位置
    Vector3 Piec_Now;//移動前の現在位置
    Vector3 Piec_Now2;//移動前の現在位置
    private int posNum_Now;
    private int posNum_Now2;
    private int pos_Traget;
    private int pos_Traget2;
    private int dif_PosNum, dif_PosNum2;
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
    // Start is called before the first frame update
    void Start()
    {
		//Piece3x3();
		PieceInit(voidPos,maxMapSize);
    }
	public SensingPazl[,] GetPices()
	{
		return pieces;
	}
    // Update is called once per frame
    void Update()
    {
        //SensingTouch();
    }
    //0703
	//プロパティを参照することで生成関数を可変にしました
     void PieceInit(Vector2Int voidPos,Vector2Int MapSize)
    {
        int n = 0;
		pieces = new SensingPazl[MapSize.x,MapSize.y];
		if (maxMapSize.x * maxMapSize.y != pieces_List.Count)
		{
			Debug.LogError("マップサイズの指定とパズルピースの多さが一致しません");
		}
		//リストから1個ずつ要素を抽出して2次元配列に代入しています
		//これで疑似的にserialize化を実現してます
        for(int y =maxMapSize.y-1; y >= 0; y--)
		{
            for (int x = 0; x < maxMapSize.x; x++)
            {
				if (new Vector2Int(x, y) == voidPos)
				{
					pieces[x,y] = null;
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

	void ClickSwap(int x,int y)//pieceと何もない空間を入れ替えて配列情報を更新
	{
		var PieceX = GetPieceX(x,y);
		var PieceY = GetPieceY(x,y);
		//X軸とY軸の移動量を取得
		var from = pieces[x,y];
		var target = pieces[x + PieceX, y + PieceY];
		pieces[x,y] = null;
		pieces[x + PieceX, y + PieceY]= from;
		//fromとtargetを入れ替え
		from.UpdatePos(PieceX, PieceY,movePow);
		//入れ替わった位置を引数としてトリガーを発行
		swapTrrigerd.Invoke(new Vector2Int(x, y), new Vector2Int(x + PieceX, y + PieceY));
	}

	int GetPieceX(int x,int y)//引数で指定したところに隙間があったら移動させるための数値を返す
	{
		if (x < maxMapSize.x-1)
		{
			if (pieces[x + 1, y] == null)
			{ 
				return 1;	
			}
        }
			
		if(x > 0 )
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
		if (y < maxMapSize.y-1)
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
}
