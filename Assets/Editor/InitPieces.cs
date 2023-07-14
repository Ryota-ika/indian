using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InitPieces : EditorWindow
{
	int row;
	int column;
	float road_Scale;
	GameObject StraightPanel;
	GameObject curvePanel;
	[MenuItem("�����Z�b�g�A�b�v/�p�Y��&����񓯊�")]
	public static void RoadSetUp()
	{
		InitPieces window = GetWindow<InitPieces>();
		window.Show();
	}
	private void OnGUI()
	{
		//���j���[
		GUILayout.Label("�ݒ�", EditorStyles.boldLabel);
		road_Scale = EditorGUILayout.FloatField("����̑傫��",road_Scale);
		row = EditorGUILayout.IntField("���R�傫��",row);
		column = EditorGUILayout.IntField("�^�e�傫��", column);
		StraightPanel = EditorGUILayout.ObjectField("�����p�Y��",StraightPanel,typeof(GameObject),true) as GameObject;
		curvePanel = EditorGUILayout.ObjectField("�J�[�u�p�Y��", curvePanel, typeof(GameObject), true) as GameObject;
		if (GUILayout.Button("�ݒ�J�n")){
			//���o�Ă��铹�����ׂĎ擾
			GameObject[] roads = GameObject.FindGameObjectsWithTag("Road_1A");
			//�}�l�[�W���[�擾
			RoadManager roadScript = GameObject.Find("RoadManeger").GetComponent<RoadManager>();
			Pazlcell pazleScript = GameObject.Find("pazl").GetComponent<Pazlcell>();
			//���T�C�Y�擾
			Debug.Log(roads[0].transform.localScale);
			//���X�g�i�[�T���p��Vector2�쐬
			Vector2 max = new Vector2(road_Scale,road_Scale);
			Vector2 min = new Vector2(0, 0);
			GameObject pazleParent = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
			//�T���J�n
			for (int y=column-1;y>=0;y--){
			for (int x=0;x<row;x++){
				Debug.Log((min.x) + (road_Scale * x).ToString()+"����"+ ((max.x - 1) * x).ToString()+"�̊Ԃ�T��");
				foreach (GameObject item in roads) {
						
					if (item.transform.position.x>=(min.x)&&item.transform.position.x<=(max.x-1)*x	
						&&item.transform.position.y>=(min.y)&&item.transform.position.y<=(max.y-1)*y){
						//���p�l���̈ʒu��min�ȏ�max�����Ȃ烊�X�g�Ɏ擾
						roadScript.AddToRoadList(item);
						Debug.Log(x.ToString()+":"+y.ToString()+"��"+item.name+"����ꂽ");
						switch (item.GetComponent<Road_Cell>().GetRoadType())
						{
						//�^�C�v�����ɉ����ăp�l���𐶐�
							case Road_Cell.RoadType.STRAIGHT:
								pazleScript.AddToPieceList(CreatePanel				(StraightPanel,item.transform.rotation,pazleParent.transform).GetComponent<SensingPazl>());
							break;
							case Road_Cell.RoadType.CORNER:
								pazleScript.AddToPieceList(CreatePanel(curvePanel, item.transform.rotation,pazleParent.transform).GetComponent<SensingPazl>());
							break;
							case Road_Cell.RoadType.VOID:
								pazleScript.AddToPieceList(null);
							break;
						}
						break;
					}
				}
			}
		}
		}
	}
	GameObject CreatePanel(GameObject panel,Quaternion rotation,Transform parent)
	{
	  GameObject g=Instantiate(panel,new Vector3(panel.transform.localScale.x,panel.transform.localScale.y,0),rotation);
		g.transform.parent = parent;
		return g;
	}
}
