using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

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
	SensingPazl[,] pieces = new SensingPazl[4,5];
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
		PieceInit(voidPos);

  //      posNum_Now = Piec_Num;
  //posNum_Now2 = Piec_Num;
  //Piec_Now = transform.position;
  //      Piec_Now2 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //SensingTouch();
    }
	//public void SensingTouch()
 //   {


 //       if (touchFlag)
 //       {
 //           Vector3 mousePosNow = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 //           mousePosNow.z = 0;
 //           Vector3 mouseposDif = mousePosNow - first_Pos;//�����ꂽ�ʒu����}�E�X�̈ړ������Ƌ���
 //           Vector3 MovePiec = Piec_Now + mouseposDif;//���݈ʒu�Ƀ}�E�X�̈ړ�����������
 //           //Vector3 MovePiec2 = Piec_Now + mouseposDif;

 //           //�ړ��͈͐ݒ�
 //           if (Piec_Now2.x >= PicePos_Target2.x)
 //           {
 //               MovePiec.x = Mathf.Clamp(MovePiec.x, PicePos_Target2.x, Piec_Now.x);
 //           }
 //           else
 //           {
 //               MovePiec.x = Mathf.Clamp(MovePiec.x, Piec_Now.x, PicePos_Target2.x);
 //           }
 //           if (Piec_Now2.y >= PicePos_Target2.y)
 //           {
 //               MovePiec.y = Mathf.Clamp(MovePiec.y, PicePos_Target2.y, Piec_Now.y);
 //           }
 //           else
 //           {
 //               MovePiec.y = Mathf.Clamp(MovePiec.y, Piec_Now2.y, PicePos_Target2.y);
 //           }

 //           if (Piec_Now.x >= PicePos_Target.x)
 //           {
 //               MovePiec.x = Mathf.Clamp(MovePiec.x, PicePos_Target.x, Piec_Now.x);
 //           }
 //           else
 //           {
 //               MovePiec.x = Mathf.Clamp(MovePiec.x, Piec_Now.x, PicePos_Target.x);
 //           }
 //           if(Piec_Now.y>= PicePos_Target.y)
 //           {
 //               MovePiec.y = Mathf.Clamp(MovePiec.y, PicePos_Target.y, Piec_Now.y);
 //           }
 //           else
 //           {
 //               MovePiec.y = Mathf.Clamp(MovePiec.y, Piec_Now.y, PicePos_Target.y);
 //           }
 //           //���̃X�N���v�g������Pice�̈ړ�����
 //           Piec_Now = Vector3.Lerp(transform.position, MovePiec, 0.2f);
 //           //Piec_Now2 = Vector3.Lerp(transform.position, MovePiec2, 0.2f);
 //       }
 //           else
 //           {
 //               if (isMovePice)
 //               {
 //                   transform.position= PicePos_Target;//�ړ��\��ʒu
 //                  // transform.position = PicePos_Target2; //���������܂��@�\���Ȃ�

	//			    //ClasesensingPazl.PosNumMovePosible(posNum_Now);//��p

	//			    ClasesensingPazl.PosNumMovePosible1(posNum_Now, posNum_Now2);//��p
 //                   posNum_Now = pos_Traget;//�ړ���̏ꏊ�ɂȂ�
 //                   posNum_Now2 = pos_Traget2;
              
 //                   Piec_Now = PicePos_Target;//�ԍ��Əꏊ���ړ���ɕς���
	//			    Piec_Now2 = PicePos_Target2;

	//			    isMovePice = false;
 //               }
 //           }


 //           //if(touchFlag)
 //           //{
 //           //    if (currenSwipePos.y > 0 && currenSwipePos.x > datectionButton && currenSwipePos.x < datetctionup)
 //           //    {
 //           //        //SensingPazl.Instance.check(Xpos, Ypos, thisTile);
 //           //        Debug.Log("��");
 //           //        Debug.Log("�X���C�v������");
 //           //         r.localPosition += new Vector3(0, 1, 0);
 //           //    }
                
 //           //    if (currenSwipePos.y < 0 && currenSwipePos.x > datectionButton && currenSwipePos.x < datetctionup)
 //           //    {
 //           //        Debug.Log("��");
 //           //        Debug.Log("�X���C�v������");
 //           //        r.localPosition += new Vector3(0, -1, 0);
 //           //    }
 //           //   if (currenSwipePos.x < 0 && currenSwipePos.y > datectionButton && currenSwipePos.y < datetctionup)
 //           //    {
 //           //        Debug.Log("��");
 //           //        Debug.Log("�X���C�v������");
 //           //        r.localPosition += new Vector3(-1, 0, 0);
 //           //    }   
 //           //    if (currenSwipePos.x > 0 && currenSwipePos.y > datectionButton && currenSwipePos.y < datetctionup)
 //           //    {
 //           //        Debug.Log("�E");
 //           //        Debug.Log("�X���C�v������");
 //           //        r.localPosition += new Vector3(1, 0, 0);
 //           //   }
 //           //}
        
 //   }

 //   public void MouceClickDown()//�ړ��ł��邩�̔���
 //   {

 //       touchFlag = true;
 //       isMovePice = true;

 //      /* pos_Traget = ClasesensingPazl.MovePossble();*/ //����p
 //        (pos_Traget,pos_Traget2) = ClasesensingPazl.MobePossble1();///��p
 //       dif_PosNum = pos_Traget - posNum_Now;//�ړ��\��ʒu�̔ԍ����猻�݂̔ԍ�������
 //       PicePos_Target = Piec_Now;

 //       dif_PosNum2 =pos_Traget2 - posNum_Now2;
	//	PicePos_Target2 = Piec_Now2;
	//	////3* 3  �̏ꍇ
	//	//if (dif_PosNum == 3)
	//	//{
	//	//	PicePos_Target.y -= 0.63f;
	//	//}
	//	//else if (dif_PosNum == -3)
	//	//{
	//	//	PicePos_Target.y += 0.63f;
	//	//}
	//	//else if (dif_PosNum == 1 && (posNum_Now != 3 && posNum_Now != 6))
	//	//{
	//	//	PicePos_Target.x += 0.64f;
	//	//}
	//	//else if (dif_PosNum == -1 && (posNum_Now != 4 && posNum_Now != 7))
	//	//{
	//	//	PicePos_Target.x -= 0.64f;
	//	//}
	//	//else
	//	//{
	//	//	touchFlag = false;
	//	//	isMovePice = false;
	//	//	return;
	//	//}

	//	//4 * 5�ꍇ
	//	//���
	//	if (dif_PosNum == 4 )
	//	{
	//		PicePos_Target.y -= 0.63f;//���Ɉړ�
      
	//	}
	//	else if (dif_PosNum == -4 )
	//	{
	//		PicePos_Target.y += 0.63f;//��Ɉړ�

 //       }
	//	else if (dif_PosNum == 1 && (posNum_Now != 4 && posNum_Now != 8 && posNum_Now != 12 && posNum_Now != 16))
	//	{
	//		PicePos_Target.x += 0.64f;//�E�Ɉړ�

 //       }
	//	else if (dif_PosNum == -1 && (posNum_Now != 5 && posNum_Now != 9 && posNum_Now != 13 && posNum_Now != 17))
	//	{
	//		PicePos_Target.x -= 0.64f;//���Ɉړ�

 //       }
	//	//���
	//	else if (dif_PosNum2 == 4)
	//	{

	//		PicePos_Target2.y -= 0.63f;
	//	}
	//	else if (dif_PosNum2 ==-4)
	//	{

	//		PicePos_Target2.y += 0.63f;
	//	}
	//	else if (dif_PosNum2 == 1 && (posNum_Now2 != 4 && posNum_Now2 != 8 && posNum_Now2 != 12 && posNum_Now2 !=16))
	//	{

	//		PicePos_Target2.x += 0.64f;
	//	}
	//	else if (dif_PosNum2 == -1 && (posNum_Now2 != 5 && posNum_Now2 != 9 && posNum_Now2 != 13 && posNum_Now2 != 17))
	//	{

	//		PicePos_Target2.x -= 0.64f;
	//	}
	//	else
	//	{
	//		touchFlag = false;
	//		isMovePice = false;
	//		return;
	//	}

 //   }

 //   public void MouseClickUp() 
 //   {
 //       touchFlag =false;

 //       Debug.Log("Up");
 //   }




    //0703
	//�v���p�e�B���Q�Ƃ��邱�ƂŐ����֐����ςɂ��܂���
     void PieceInit(Vector2Int voidPos)
    {
        int n = 0;
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
					Destroy(pieces_List[n].gameObject);
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

		var from = pieces[x,y];
		var target = pieces[x + PieceX, y + PieceY];

		pieces[x,y] = null;
		pieces[x + PieceX, y + PieceY]= from;
		from.UpdatePos(x, y,movePow);
	}

	int GetPieceX(int x,int y)//�����Ŏw�肵���Ƃ���Ɍ��Ԃ���������ړ������邽�߂̐��l��Ԃ�
	{
		if (x < maxMapSize.x && pieces[x + 1, y]==null)
		{
            return 1;
        }
			
		if(x > 0 && pieces[x - 1, y]==null)
		{
			return -1;
		}
		return 0;
	}

	int GetPieceY(int x, int y)
	{
		if (y < maxMapSize.y && pieces[x, y + 1]==null)
		{
			return 1;
		}

		if (y > 0 && pieces[x, y - 1]==null)
		{
			return -1;
		}
		return 0;
	}
}
