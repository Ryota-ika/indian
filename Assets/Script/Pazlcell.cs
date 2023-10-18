using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class Pazlcell : MonoBehaviour
{

   
    bool touchFlag = false;//�}�E�X��������Ă���Ƃ�
    bool isMovePice=false;//Pice�̈ړ��p�i�ړ����Ă���Ƃ���true�j

    //RectTransform r, r2;
    //Vector2 m;
    //Vector3 SecondPos;
    //Vector3 currenSwipePos;
    //float datectionButton = -0.8f;
    //float datetctionup = 0.8f;


<<<<<<< Updated upstream
    Vector3 PicePos_Target, PicePos_Target2;//�ړ��\��ʒu
    Vector3 first_Pos;//�^�b�v���̃|�C���^�[�̈ʒu
    Vector3 Piec_Now;//�ړ��O�̌��݈ʒu
    Vector3 Piec_Now2;//�ړ��O�̌��݈ʒu
    private int posNum_Now;
    private int posNum_Now2;
    private int pos_Traget;
    private int pos_Traget2;
    private int dif_PosNum, dif_PosNum2;
=======
	/*Vector3 PicePos_Target, PicePos_Target2;//�ړ��\��ʒu
	Vector3 first_Pos;//�^�b�v���̃|�C���^�[�̈ʒu
	Vector3 Piec_Now;//�ړ��O�̌��݈ʒu
	Vector3 Piec_Now2;//�ړ��O�̌��݈ʒu
	private int posNum_Now;
	private int posNum_Now2;
	private int pos_Traget;
	private int pos_Traget2;
	private int dif_PosNum, dif_PosNum2;*/
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
    //8���ǉ�
    private Vector2Int playerPosition; // �v���C���[�̈ʒu�����i�[����ϐ�
    [Header("�A�C�R����Transform")]
    public Transform playerIconpos; // �v���C���[��Transform
>>>>>>> Stashed changes

    public SensingPazl ClasesensingPazl;//�Ăяo���p
    public int Piec_Num =0 ;//Pice�̔ԍ��p

<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
    {
		posNum_Now = Piec_Num;
		posNum_Now2 = Piec_Num;
		Piec_Now = transform.position;
        Piec_Now2 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SensingTouch();
    }
	public void SensingTouch()
    {


        if (touchFlag)
=======
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
	//�v���p�e�B���Q�Ƃ��邱�ƂŐ����֐����ςɂ��܂���
	void PieceInit(Vector2Int voidPos, Vector2Int MapSize)
	{
		int n = 0;
		pieces = new SensingPazl[MapSize.x, MapSize.y];
		if (maxMapSize.x * maxMapSize.y != pieces_List.Count)
		{
			Debug.LogError("�}�b�v�T�C�Y�̎w��ƃp�Y���s�[�X�̑�������v���܂���");
		}
		//���X�g����1���v�f�𒊏o����2�����z��ɑ�����Ă��܂�
		//����ŋ^���I��serialize�����������Ă܂�
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

	void ClickSwap(int x, int y)//piece�Ɖ����Ȃ���Ԃ����ւ��Ĕz������X�V
	{


		var PieceX = GetPieceX(x, y);
		var PieceY = GetPieceY(x, y);
		var from = pieces[x, y];
		var target = pieces[x + PieceX, y + PieceY];
		pieces[x, y] = null;
		pieces[x + PieceX, y + PieceY] = from;
		from.UpdatePos(PieceX, PieceY, movePow);

		// ����ւ�����ʒu�������Ƃ��ăg���K�[�𔭍s
		swapTrrigerd.Invoke(new Vector2Int(x, y), new Vector2Int(x + PieceX, y + PieceY));

	}
	int GetPieceX(int x, int y)//�����Ŏw�肵���Ƃ���Ɍ��Ԃ���������ړ������邽�߂̐��l��Ԃ�
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
	//8���ǉ�
	[SerializeField]
	private GameObject icon;
/*	public GameObject iconPrefab;*/
	public MapSetPlayer set;
    private bool iconGenerated = false; // �A�C�R��������Ԃ��Ǘ�����t���O
	public GameObject parentObject;
    void UpdatePlayerIconPosition()
    {
        Vector3 playerPosition = icon.transform.position;
        SensingPazl nearestPiece = null;
        float nearestDistance = 3f;
        Vector2Int playerIconIndex = Vector2Int.zero; // �v���C���[�A�C�R���̈ʒu�̃C���f�b�N�X��ێ�����ϐ�
        for (int x = 0; x < pieces.GetLength(0); x++)
>>>>>>> Stashed changes
        {
            Vector3 mousePosNow = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosNow.z = 0;
            Vector3 mouseposDif = mousePosNow - first_Pos;//�����ꂽ�ʒu����}�E�X�̈ړ������Ƌ���
            Vector3 MovePiec = Piec_Now + mouseposDif;//���݈ʒu�Ƀ}�E�X�̈ړ�����������
            

            //�ړ��͈͐ݒ�
            if (Piec_Now2.x >= PicePos_Target2.x)
            {
<<<<<<< Updated upstream
                MovePiec.x = Mathf.Clamp(MovePiec.x, PicePos_Target2.x, Piec_Now2.x);
            }
            else
            {
                MovePiec.x = Mathf.Clamp(MovePiec.x, Piec_Now2.x, PicePos_Target2.x);
            }
            if (Piec_Now2.y >= PicePos_Target2.y)
            {
                MovePiec.y = Mathf.Clamp(MovePiec.y, PicePos_Target2.y, Piec_Now2.y);
            }
            else
            {
                MovePiec.y = Mathf.Clamp(MovePiec.y, Piec_Now2.y, PicePos_Target2.y);
            }
             if (Piec_Now.x >= PicePos_Target.x)
            {
                MovePiec.x = Mathf.Clamp(MovePiec.x, PicePos_Target.x, Piec_Now.x);
            }
            else
            {
                MovePiec.x = Mathf.Clamp(MovePiec.x, Piec_Now.x, PicePos_Target.x);
            }
            if(Piec_Now.y>= PicePos_Target.y)
            {
                MovePiec.y = Mathf.Clamp(MovePiec.y, PicePos_Target.y, Piec_Now.y);
            }
            else
            {
                MovePiec.y = Mathf.Clamp(MovePiec.y, Piec_Now.y, PicePos_Target.y);
            }
            //���̃X�N���v�g������Pice�̈ړ�����
            Piec_Now = Vector3.Lerp(transform.position, MovePiec, 0.2f);
            Piec_Now2 = Vector3.Lerp(transform.position, MovePiec, 0.2f);
        }
            else
            {
                if (isMovePice)
                {
                    transform.position= PicePos_Target;//�ړ��\��ʒu
				    Piec_Now2 = PicePos_Target2;

				    //ClasesensingPazl.PosNumMovePosible(posNum_Now);//��p

				    ClasesensingPazl.PosNumMovePosible1(posNum_Now, posNum_Now2);//��p
                    posNum_Now = pos_Traget;
                    posNum_Now2 = pos_Traget2;
              
                    Piec_Now = PicePos_Target;
				    Piec_Now2 = PicePos_Target2;

				    isMovePice = false;
                }
            }


            //if(touchFlag)
            //{
            //    if (currenSwipePos.y > 0 && currenSwipePos.x > datectionButton && currenSwipePos.x < datetctionup)
            //    {
            //        //SensingPazl.Instance.check(Xpos, Ypos, thisTile);
            //        Debug.Log("��");
            //        Debug.Log("�X���C�v������");
            //         r.localPosition += new Vector3(0, 1, 0);
            //    }
                
            //    if (currenSwipePos.y < 0 && currenSwipePos.x > datectionButton && currenSwipePos.x < datetctionup)
            //    {
            //        Debug.Log("��");
            //        Debug.Log("�X���C�v������");
            //        r.localPosition += new Vector3(0, -1, 0);
            //    }
            //   if (currenSwipePos.x < 0 && currenSwipePos.y > datectionButton && currenSwipePos.y < datetctionup)
            //    {
            //        Debug.Log("��");
            //        Debug.Log("�X���C�v������");
            //        r.localPosition += new Vector3(-1, 0, 0);
            //    }   
            //    if (currenSwipePos.x > 0 && currenSwipePos.y > datectionButton && currenSwipePos.y < datetctionup)
            //    {
            //        Debug.Log("�E");
            //        Debug.Log("�X���C�v������");
            //        r.localPosition += new Vector3(1, 0, 0);
            //   }
            //}
        
    }

    public void MouceClickDown()//�ړ��ł��邩�̔���
    {

        touchFlag = true;
        isMovePice = true;

       /* pos_Traget = ClasesensingPazl.MovePossble();*/ //����p
         (pos_Traget,pos_Traget2) = ClasesensingPazl.MobePossble1();///��p
        dif_PosNum = pos_Traget - posNum_Now;//�ړ��\��ʒu�̔ԍ����猻�݂̔ԍ�������
        PicePos_Target = Piec_Now;

        dif_PosNum2 =pos_Traget2 - posNum_Now2;
		PicePos_Target2 = Piec_Now2;
		////3* 3  �̏ꍇ
		//if (dif_PosNum == 3)
		//{
		//	PicePos_Target.y -= 0.63f;
		//}
		//else if (dif_PosNum == -3)
		//{
		//	PicePos_Target.y += 0.63f;
		//}
		//else if (dif_PosNum == 1 && (posNum_Now != 3 && posNum_Now != 6))
		//{
		//	PicePos_Target.x += 0.64f;
		//}
		//else if (dif_PosNum == -1 && (posNum_Now != 4 && posNum_Now != 7))
		//{
		//	PicePos_Target.x -= 0.64f;
		//}
		//else
		//{
		//	touchFlag = false;
		//	isMovePice = false;
		//	return;
		//}

		//4 * 5�ꍇ
		//���
		if (dif_PosNum == 4 )
		{
			PicePos_Target.y -= 0.63f;//���Ɉړ�
      
		}
		else if (dif_PosNum == -4 )
		{
			PicePos_Target.y += 0.63f;//��Ɉړ�

        }
		else if (dif_PosNum == 1 && (posNum_Now != 4 && posNum_Now != 8 && posNum_Now != 12 && posNum_Now != 16))
		{
			PicePos_Target.x += 0.64f;//�E�Ɉړ�

        }
		else if (dif_PosNum == -1 && (posNum_Now != 5 && posNum_Now != 9 && posNum_Now != 13 && posNum_Now != 17))
		{
			PicePos_Target.x -= 0.64f;//���Ɉړ�

        }
		//���
		else if (dif_PosNum2 == 4)
		{

			PicePos_Target2.y -= 0.63f;
		}
		else if (dif_PosNum2 ==-4)
		{

			PicePos_Target2.y += 0.63f;
		}
		else if (dif_PosNum2 == 1 && (posNum_Now2 != 4 && posNum_Now2 != 8 && posNum_Now2 != 12 && posNum_Now2 !=16))
		{

			PicePos_Target2.x += 0.64f;
		}
		else if (dif_PosNum2 == -1 && (posNum_Now2 != 5 && posNum_Now2 != 9 && posNum_Now2 != 13 && posNum_Now2 != 17))
		{

			PicePos_Target2.x -= 0.64f;
		}
		else
		{
			touchFlag = false;
			isMovePice = false;
			return;
		}

      
        //Piec_Now = transform.position;
        //PicePos_Target = Piec_Now;
        //PicePos_Target.x += 1.0f;
        //Debug.Log("Down");
    }
=======
				SensingPazl piece = pieces[x, y];
				if (piece != null)
                {
                    Vector3 piecePosition = piece.transform.position;
                    float distance = Vector3.Distance(playerPosition, piecePosition);
                    // �ł��߂��s�[�X��T��
                    if (distance < nearestDistance)
                    {
                        nearestPiece = piece;
                        nearestDistance = distance;
                        playerIconIndex = new Vector2Int(x, y); // �v���C���[�A�C�R���̈ʒu�̃C���f�b�N�X���X�V
                    }
                }
			}
        }
		if (nearestPiece != null)
        {
            Vector2Int newPlayerIconPosition = playerIconIndex;
		
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

		if (icon != null)
		{
            if (pieces_List.Count > 0 && pieces_List[set.nearestObjectIndex] != null)
            {
                /*   icon.transform.SetParent(parentObject.transform);*/
                icon.transform.position = pieces_List[set.nearestObjectIndex].transform.position;

            }
            else
            {
                // �A�C�R�������݂���ꍇ�A�A�C�R���̈ʒu���X�V
                icon.transform.position = pieces_List[set.nearestObjectIndex].transform.position;
            }
        }
			
	
	}
>>>>>>> Stashed changes

    public void MouseClickUp() 
    {
        touchFlag =false;

        Debug.Log("Up");
    }





  
}
