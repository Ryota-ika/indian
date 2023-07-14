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
	[Header("Ž©•ª‚Ì“¹ƒ^ƒCƒv")]
	[SerializeField]
	RoadType myType;
	public RoadType GetRoadType()
	{
		return myType;
	}
}
