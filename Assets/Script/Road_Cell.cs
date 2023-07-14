using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Cell:MonoBehaviour
{
	public enum RoadType { 
		STRAIGHT,
		CORNER,
		START,
		GOAL,
		VOID
	}
	[Header("�����̓��^�C�v")]
	[SerializeField]
	RoadType myType;
	public RoadType GetRoadType()
	{
		return myType;
	}
}
