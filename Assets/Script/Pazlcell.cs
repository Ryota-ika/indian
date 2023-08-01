using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.Events;

public class Pazlcell : MonoBehaviour
{
	[Header("�X���p�ړ���")]
	[SerializeField]
	float movePow;
	//�}�b�v�T�C�Y�Ƌ󂫉ӏ����v���p�e�B����ݒ�\�ɂ��܂���
	[Header("�}�b�v�̃^�e���R�T�C�Y")]
	[SerializeField]
	Vector2Int maxMapSize;
	[Header("�X���p�̋󂫉ӏ�")]
	[SerializeField]
	Vector2Int voidPos;
    bool touchFlag = false;//�}�E�X��������Ă���Ƃ�
    bool isMovePice=false;//Pice�̈ړ��p�i�ړ����Ă���Ƃ���true�j
	public static event UnityAction<Vector2Int,Vector2Int> swapTrrigerd;
	//RectTransform r, r2;
	//Vector2 m;
	//Vector3 SecondPos;
	//Vector3 currenSwipePos;
	//float datectionButton = -0.8f;
	//float datetctionup = 0.8f;


	Vector3 PicePos_Target, PicePos_Target2;//�ړ��\��ʒu
    Vector3 first_Pos;//�^�b�v���̃|�C���^�[�̈ʒu
    Vector3 Piec_Now;//�ړ��O�̌��݈ʒu
    Vector3 Piec_Now2;//�ړ��O�̌��݈ʒu
    private int posNum_Now;
    private int posNum_Now2;
    private int pos_Traget;
    private int pos_Traget2;
    private int dif_PosNum, dif_PosNum2;
	[SerializeField]
	SensingPazl PiecePrefub;
	// SensingPazl ClasesensingPazl;//�Ăяo���p
	// public int Piec_Num =0 ;//Pice�̔ԍ��p
    //07-03
	SensingPazl[,] pieces;
    Sprite[] sprites;
	[SerializeField]
	//selialize�w�肷�邽�߂Ɉ�U���X�g�Ɋi�[���邱�Ƃɂ��܂����B
	//���と�E���̏��Ԃœ���Ȃ��ƃo�O��܂�(�\����Ȃ�)
	//�����͕�����Â炭�Ȃ��Ă��܂����̂Ō�Ŏ������ł��Ȃ��������܂��B
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
	//�v���p�e�B���Q�Ƃ��邱�ƂŐ����֐����ςɂ��܂���
     void PieceInit(Vector2Int voidPos,Vector2Int MapSize)
    {
        int n = 0;
		pieces = new SensingPazl[MapSize.x,MapSize.y];
		if (maxMapSize.x * maxMapSize.y != pieces_List.Count)
		{
			Debug.LogError("�}�b�v�T�C�Y�̎w��ƃp�Y���s�[�X�̑�������v���܂���");
		}
		//���X�g����1���v�f�𒊏o����2�����z��ɑ�����Ă��܂�
		//����ŋ^���I��serialize�����������Ă܂�
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

	void ClickSwap(int x,int y)//piece�Ɖ����Ȃ���Ԃ����ւ��Ĕz������X�V
	{
		var PieceX = GetPieceX(x,y);
		var PieceY = GetPieceY(x,y);
		//X����Y���̈ړ��ʂ��擾
		var from = pieces[x,y];
		var target = pieces[x + PieceX, y + PieceY];
		pieces[x,y] = null;
		pieces[x + PieceX, y + PieceY]= from;
		//from��target�����ւ�
		from.UpdatePos(PieceX, PieceY,movePow);
		//����ւ�����ʒu�������Ƃ��ăg���K�[�𔭍s
		swapTrrigerd.Invoke(new Vector2Int(x, y), new Vector2Int(x + PieceX, y + PieceY));
	}

	int GetPieceX(int x,int y)//�����Ŏw�肵���Ƃ���Ɍ��Ԃ���������ړ������邽�߂̐��l��Ԃ�
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
