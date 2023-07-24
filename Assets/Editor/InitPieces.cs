using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InitPieces : EditorWindow
{
	int row;
	int column;
	float road_Scale;
	GameObject straightPanel;
	GameObject curvePanel;
	GameObject startPanel;
	GameObject goalPanel;
	[MenuItem("�����Z�b�g�A�b�v/�p�Y��&����񓯊�")]
	public static void RoadSetUp()
	{
		InitPieces window = GetWindow<InitPieces>();
		window.Show();
	}
	private void OnGUI()
	{
		//���j���[
		GUILayout.Label("�p�Y���Ɠ��𓯊����܂�", EditorStyles.boldLabel);

		road_Scale = EditorGUILayout.FloatField("����̑傫��",EditorPrefs.GetFloat("����̑傫��",road_Scale));
		row = EditorGUILayout.IntField("���R�傫��", EditorPrefs.GetInt("���R�傫��",row));
		column = EditorGUILayout.IntField("�^�e�傫��", EditorPrefs.GetInt("�^�e�傫��",column));

		straightPanel = EditorGUILayout.ObjectField("�����p�Y��",straightPanel,typeof(GameObject),true) as GameObject;
		curvePanel = EditorGUILayout.ObjectField("�J�[�u�p�Y��", curvePanel, typeof(GameObject), true) as GameObject;
		startPanel = EditorGUILayout.ObjectField("�X�^�[�g�p�Y��", startPanel, typeof(GameObject), true) as GameObject;
		goalPanel = EditorGUILayout.ObjectField("�S�[���p�Y��",goalPanel , typeof(GameObject), true) as GameObject;

		if (GUILayout.Button("���͂����l���Z�[�u")) {
			EditorPrefs.SetFloat("����̑傫��", road_Scale);
			EditorPrefs.SetInt("���R�傫��", row);
			EditorPrefs.SetInt("�^�e�傫��", column);
		}

		if (GUILayout.Button("�ݒ�J�n")){
			//���o�Ă��铹�����ׂĎ擾
			GameObject[] roads = GameObject.FindGameObjectsWithTag("Road_1A");
			//�}�l�[�W���[�擾
			RoadManager roadScript = GameObject.Find("RoadManeger").GetComponent<RoadManager>();
			Pazlcell pazleScript = GameObject.Find("pazl").GetComponent<Pazlcell>();
			//���X�g�i�[�T���p��Vector2�쐬
			GameObject pazleParent = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);

			//�T���J�n
			for (int z=column-1;z>=0;z--){
			for (int x=0;x<row;x++){
				Debug.Log((road_Scale * x).ToString()+"����"+((road_Scale-1)+(road_Scale*x)).ToString()+"�̊Ԃ�T��");
				foreach (GameObject item in roads) {
						
					if (item.transform.position.x>=road_Scale*x
						&&item.transform.position.x<(road_Scale)+(road_Scale*x)
						&&item.transform.position.z>=road_Scale*z
						&&item.transform.position.z<(road_Scale+(road_Scale*z))){

							roadScript.AddToRoadList(item);
							Debug.Log(x.ToString()+":"+z.ToString()+"��"+item.name+"����ꂽ");
							switch (item.GetComponent<Road_Cell>().GetRoadType())
							{
							//�^�C�v�����ɉ����ăp�l���𐶐�
								case Road_Cell.RoadType.STRAIGHT:
									pazleScript.AddToPieceList(CreatePanel				(straightPanel,item.transform.rotation,pazleParent.transform,new Vector2(x,z)).GetComponent<SensingPazl>());
								break;
								case Road_Cell.RoadType.CORNER:
									pazleScript.AddToPieceList(CreatePanel(curvePanel, item.transform.rotation,pazleParent.transform,new Vector2(x,z)).GetComponent<SensingPazl>());
								break;
								case Road_Cell.RoadType.VOID:
									pazleScript.AddToPieceList(null);
								break;
								case Road_Cell.RoadType.GOAL:
									pazleScript.AddToPieceList(CreatePanel(goalPanel,
									item.transform.rotation, pazleParent.transform,
									new Vector2(x, z)).GetComponent<SensingPazl>());
								break;
							}
							break;
						}
				}
			}

		}
			EditorUtility.SetDirty(pazleScript);
			EditorUtility.SetDirty(roadScript);
		}

	}
	GameObject CreatePanel(GameObject panel,Quaternion rotation,Transform parent,Vector2 pos)
	//�p�l�������p�̊֐�
	{
	  GameObject g=Instantiate(panel,new Vector3(panel.transform.localScale.x*pos.x,panel.transform.localScale.y*pos.y,0),Quaternion.identity);
		g.transform.parent = parent;
		return g;
	}
}
