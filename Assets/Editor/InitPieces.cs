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
	[MenuItem("初期セットアップ/パズル&道情報同期")]
	public static void RoadSetUp()
	{
		InitPieces window = GetWindow<InitPieces>();
		window.Show();
	}
	private void OnGUI()
	{
		//メニュー
		GUILayout.Label("設定", EditorStyles.boldLabel);
		road_Scale = EditorGUILayout.FloatField("道一つの大きさ",road_Scale);
		row = EditorGUILayout.IntField("ヨコ大きさ",row);
		column = EditorGUILayout.IntField("タテ大きさ", column);
		StraightPanel = EditorGUILayout.ObjectField("直線パズル",StraightPanel,typeof(GameObject),true) as GameObject;
		curvePanel = EditorGUILayout.ObjectField("カーブパズル", curvePanel, typeof(GameObject), true) as GameObject;
		if (GUILayout.Button("設定開始")){
			//今出ている道をすべて取得
			GameObject[] roads = GameObject.FindGameObjectsWithTag("Road_1A");
			//マネージャー取得
			RoadManager roadScript = GameObject.Find("RoadManeger").GetComponent<RoadManager>();
			Pazlcell pazleScript = GameObject.Find("pazl").GetComponent<Pazlcell>();
			//道サイズ取得
			Debug.Log(roads[0].transform.localScale);
			//リスト格納探索用のVector2作成
			Vector2 max = new Vector2(road_Scale,road_Scale);
			Vector2 min = new Vector2(0, 0);
			GameObject pazleParent = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
			//探索開始
			for (int y=column-1;y>=0;y--){
			for (int x=0;x<row;x++){
				Debug.Log((min.x) + (road_Scale * x).ToString()+"から"+ ((max.x - 1) * x).ToString()+"の間を探索");
				foreach (GameObject item in roads) {
						
					if (item.transform.position.x>=(min.x)&&item.transform.position.x<=(max.x-1)*x	
						&&item.transform.position.y>=(min.y)&&item.transform.position.y<=(max.y-1)*y){
						//道パネルの位置がmin以上max未満ならリストに取得
						roadScript.AddToRoadList(item);
						Debug.Log(x.ToString()+":"+y.ToString()+"に"+item.name+"を入れた");
						switch (item.GetComponent<Road_Cell>().GetRoadType())
						{
						//タイプ分けに応じてパネルを生成
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
