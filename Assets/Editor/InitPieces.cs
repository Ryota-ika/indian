using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InitPieces : EditorWindow
{
	int row;
	int column;
	[MenuItem("初期セットアップ/パズル&道情報同期")]
	public static void RoadSetUp()
	{
		InitPieces window = GetWindow<InitPieces>();
		window.Show();
	}
	private void OnGUI()
	{

		GUILayout.Label("設定", EditorStyles.boldLabel);
		row = EditorGUILayout.IntField("ヨコ大きさ",row);
		column = EditorGUILayout.IntField("タテ大きさ", column);
		if (GUILayout.Button("設定開始")){
			GameObject[] roads = GameObject.FindGameObjectsWithTag("Road_1A");
			RoadManager roadScript = GameObject.Find("RoadManeger").GetComponent<RoadManager>();
			Pazlcell pazleScript = GameObject.Find("Pazl").GetComponent<Pazlcell>();
			for (int y=column;y>=0;y++) {
				for (int x=0;x<row;x++) {
					
				}
			}
		}
	}
	public void PazleSetUp()
	{ 
		
	}
}
