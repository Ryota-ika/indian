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
	[MenuItem("初期セットアップ/パズル&道情報同期")]
	public static void RoadSetUp()
	{
		InitPieces window = GetWindow<InitPieces>();
		window.Show();
	}
	private void OnGUI()
	{
		//メニュー
		GUILayout.Label("パズルと道を同期します", EditorStyles.boldLabel);

		road_Scale = EditorGUILayout.FloatField("道一つの大きさ",EditorPrefs.GetFloat("道一つの大きさ",road_Scale));
		row = EditorGUILayout.IntField("ヨコ大きさ", EditorPrefs.GetInt("ヨコ大きさ",row));
		column = EditorGUILayout.IntField("タテ大きさ", EditorPrefs.GetInt("タテ大きさ",column));

		straightPanel = EditorGUILayout.ObjectField("直線パズル",straightPanel,typeof(GameObject),true) as GameObject;
		curvePanel = EditorGUILayout.ObjectField("カーブパズル", curvePanel, typeof(GameObject), true) as GameObject;
		startPanel = EditorGUILayout.ObjectField("スタートパズル", startPanel, typeof(GameObject), true) as GameObject;
		goalPanel = EditorGUILayout.ObjectField("ゴールパズル",goalPanel , typeof(GameObject), true) as GameObject;

		if (GUILayout.Button("入力した値をセーブ")) {
			EditorPrefs.SetFloat("道一つの大きさ", road_Scale);
			EditorPrefs.SetInt("ヨコ大きさ", row);
			EditorPrefs.SetInt("タテ大きさ", column);
		}

		if (GUILayout.Button("設定開始")){
			//今出ている道をすべて取得
			GameObject[] roads = GameObject.FindGameObjectsWithTag("Road_1A");
			//マネージャー取得
			RoadManager roadScript = GameObject.Find("RoadManeger").GetComponent<RoadManager>();
			Pazlcell pazleScript = GameObject.Find("pazl").GetComponent<Pazlcell>();
			//リスト格納探索用のVector2作成
			GameObject pazleParent = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);

			//探索開始
			for (int z=column-1;z>=0;z--){
			for (int x=0;x<row;x++){
				Debug.Log((road_Scale * x).ToString()+"から"+((road_Scale-1)+(road_Scale*x)).ToString()+"の間を探索");
				foreach (GameObject item in roads) {
						
					if (item.transform.position.x>=road_Scale*x
						&&item.transform.position.x<(road_Scale)+(road_Scale*x)
						&&item.transform.position.z>=road_Scale*z
						&&item.transform.position.z<(road_Scale+(road_Scale*z))){

							roadScript.AddToRoadList(item);
							Debug.Log(x.ToString()+":"+z.ToString()+"に"+item.name+"を入れた");
							switch (item.GetComponent<Road_Cell>().GetRoadType())
							{
							//タイプ分けに応じてパネルを生成
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
	//パネル生成用の関数
	{
	  GameObject g=Instantiate(panel,new Vector3(panel.transform.localScale.x*pos.x,panel.transform.localScale.y*pos.y,0),Quaternion.identity);
		g.transform.parent = parent;
		return g;
	}
}
