using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLineControll : MonoBehaviour
//����S���@�c��
//��납��ǂ������Ă���H��𐧌䂷��
{
    [Header("�s���J�n�܂ł̎���")]
    [SerializeField]
    float startTime;
    [Header("�X�s�[�h")]
    [SerializeField]
    float speed;
    [Header("�v���C���[(�ǐՑΏ�)")]
    [SerializeField]
    Transform player;
    [Header("�v���C���[�ʒu�L�^�p�x")]
    [SerializeField]
    float saveLate;
    [Header("�v���C���[�ʒu���ێ������")]
    [SerializeField]
    int maxPlayerDataNum;

    bool isHit=false;
    bool isStart=false;
    List<Vector3> playerPath = new List<Vector3>();
    Vector3 targetPos=new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(StartCount());
        //StartCoroutine(GetPlayerPos());
        targetPos = GetNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStart) { return; }
        if (Vector3.Distance(transform.position,targetPos)<=1) {//�^�[�Q�b�g�̈ʒu�ɋ߂Â�����^�[�Q�b�g�ύX
            targetPos = GetNextPoint();
        }
    }
	private void FixedUpdate()
	{
        if (!isStart) { return; }
        transform.LookAt(player);
        Vector3 movevecter = targetPos - transform.position;//�^�[�Q�b�g�̈ʒu�Ɍ������x�N�g���𐶐�
        transform.position += (movevecter.normalized*Time.deltaTime)*speed;//�������ʂ�1�Ő��K�����A�����ɑ�����������
	}
    public IEnumerator GetPlayerPos()//�v���C���[�̏������Ԋu�ŕۑ�
    {
        while (true) {
            playerPath.Add(player.position);
            if (playerPath.Count >= maxPlayerDataNum) {
                playerPath.RemoveAt(0);
            }
            yield return new WaitForSeconds(saveLate);
        }
    }
	public IEnumerator StartCount()//�X�^�[�g����܂őҋ@����R���[�`��
    {
        /*float time=0;
        while (time<=startTime) {
            time += Time.deltaTime;
        }*/
        yield return null;
        Debug.Log("�H�삪�����o����");
        isStart = true;

    }
    public Vector3 GetNextPoint()//���̖ڕW�n�_���擾
    {
        Vector3 point;
        if (playerPath.Count == 0)
        {
            point = player.transform.position;
        }
        else {
            point = playerPath[playerPath.Count-1];
            if (Mathf.Abs(targetPos.magnitude - point.magnitude) <= 0.1f) {
                point = player.transform.position;
            }
        }
        return point;
    }
	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "player") {
            Debug.Log("�v���C���[�ɏՓ˂���");
            isHit = true;
        }
    }
    public bool GetIsHit() {
        return isHit;
    }
    public bool GetIsStart()
	{
        return isStart;
	}

}
