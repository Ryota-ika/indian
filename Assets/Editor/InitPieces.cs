using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InitPieces : EditorWindow
{
	int row;
	int column;
	[MenuItem("�����Z�b�g�A�b�v/�p�Y��&����񓯊�")]
	public static void RoadSetUp()
	{
		InitPieces window = GetWindow<InitPieces>();
		window.Show();
	}
	private void OnGUI()
	{

		GUILayout.Label("�ݒ�", EditorStyles.boldLabel);
		row = EditorGUILayout.IntField("���R�傫��",row);
		column = EditorGUILayout.IntField("�^�e�傫��", column);
		if (GUILayout.Button("�ݒ�J�n")){
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
