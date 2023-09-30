using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class InitPieces : EditorWindow
{
	int row;
	int column;
	float road_Scale;
	TextAsset MapData;
	List<string[]> mapDataTextList=new List<string[]>();
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

		road_Scale = EditorGUILayout.FloatField("����̑傫��", EditorPrefs.GetFloat("����̑傫��", road_Scale));
		row = EditorGUILayout.IntField("���R�傫��", EditorPrefs.GetInt("���R�傫��", row));
		column = EditorGUILayout.IntField("�^�e�傫��", EditorPrefs.GetInt("�^�e�傫��", column));
		MapData = EditorGUILayout.ObjectField("�}�b�v��CSV�f�[�^", MapData, typeof(TextAsset), true) as TextAsset;

		if (GUILayout.Button("���͂����l���Z�[�u"))
		{
			EditorPrefs.SetFloat("����̑傫��", road_Scale);
			EditorPrefs.SetInt("���R�傫��", row);
			EditorPrefs.SetInt("�^�e�傫��", column);
		}

		if (GUILayout.Button("�ݒ�J�n"))
		{
			GameObject[] cullentRoad = GameObject.FindGameObjectsWithTag("Road_1A");
			GameObject[] cullentPazzle = GameObject.FindGameObjectsWithTag("Pazzle");
			foreach (GameObject item in cullentRoad)
			{
				DestroyImmediate(item.gameObject);
			}
			foreach (GameObject item in cullentPazzle)
			{
				DestroyImmediate(item.gameObject);
			}
			StringReader reader = new StringReader(MapData.text);
			while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
			{
				string line = reader.ReadLine(); // ��s���ǂݍ���
				mapDataTextList.Add(line.Split(",")); // , ��؂�Ń��X�g�ɒǉ�
			}
			//�}�l�[�W���[�擾
			RoadManager roadScript = GameObject.Find("RoadManeger").GetComponent<RoadManager>();
			Pazlcell pazleScript = GameObject.Find("pazl").GetComponent<Pazlcell>();
			roadScript.ListReset();
			//pazleScript.ListReset();
			//���X�g�i�[�T���p��Vector2�쐬
			GameObject pazleParent = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
			pazleParent.name = "Pazzle";
			pazleParent.tag = "Pazzle";
			GameObject[] roads = new GameObject[row * column];
			GameObject[] pazzle = new GameObject[row * column];
			int n = 0;
			pazleScript.SetMapSize(new Vector2Int(row, column));
			for (int z = column-1; z >= 0; z--)
			{
				for (int x = 0; x < row; x++)
				{
					string prefubName = mapDataTextList[x][z];
					GameObject road = Resources.Load(prefubName) as GameObject;
					GameObject g = Instantiate(road,new Vector3(x*road_Scale,0,z*road_Scale),road.transform.rotation);
					Debug.Log(new Vector2Int(x,z));
					Debug.Log(mapDataTextList[x][z]);
					roads[n] = g;
					roadScript.AddToRoadList(roads[n]);
					if (prefubName=="Void_Pos") {
						pazleScript.AddToPieceList(null); 
						n++;
						continue; }
					GameObject p = Resources.Load(prefubName+"_Pazzle") as GameObject;
					Debug.Log(p.transform.rotation);
					pazzle[n] = CreatePanel(p,p.transform.rotation,pazleParent.transform,new Vector2(x,z));
					pazleScript.SetVoidPos(new Vector2Int(x-1,z+1));
					pazleScript.AddToPieceList(pazzle[n].GetComponent<SensingPazl>());
					n++;
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
