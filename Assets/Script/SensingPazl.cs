using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SensingPazl : MonoBehaviour
{
	//public GameObject X, Y;
	//const int CELL_X = 4;
	//const int CELL_Y = 5;
	//public int width = 4;
	//public int height = 5;
	public GameObject[] Pazls;
	public GameObject[,] pec;



    public int MovePossible =10; //ãÛÇ¢ÇƒÇ¢ÇÈî‘çÜ
           int MovePossible1=20;

    

    //Start is called before the first frame update
    void Start()
	{
		
		
	}

	// Update is called once per frame
	void Update()
    {
	
	}
	
	
    public int MovePossble()
    {
        
        return  MovePossible;
    }

	public (int id, int d1) MobePossble1()
	{

		return (MovePossible, MovePossible1);
	}


	public void PosNumMovePosible(int nextMovePossible)
    {
        MovePossible  = nextMovePossible;
	}


    public void PosNumMovePosible1(int nexMove, int nexMove1)
    {

        MovePossible = nexMove;
        MovePossible1 = nexMove1;
    }





    //public void check(int Xpos, int Ypos, Pazlcell thisTile)
    //{

    //	if ((Xpos - 1) >= 0)
    //	{
    //		// we can move left, is the space currently being used?
    //		return GetTileAtThisGridLocation(Xpos - 1, Ypos, thisTile);
    //		Debug.Log("ç∂");

    //	}

    //	if ((Xpos + 1) < width)
    //	{
    //		// we can move right, is the space currently being used?
    //		return GetTileAtThisGridLocation(Xpos + 1, Ypos, thisTile);
    //		Debug.Log("âE");
    //	}
    //	if ((Ypos - 1) >= 0)
    //	{
    //		// we can move down, is the space currently being used?
    //		return (Xpos, Ypos - 1, thisTile);
    //		Debug.Log("è„");
    //	}
    //	if ((Ypos - 1) >= 0)
    //	{
    //		// we can move down, is the space currently being used?
    //		return GetTileAtThisGridLocation(Xpos, Ypos - 1, thisTile);
    //		Debug.Log("è„");
    //	}

    //}


    //	int no = 0;
    //	if (no >= 3 && Pazls[no - 3].gameObject)
    //	{
    //		Debug.Log("è„");
    //	}
    //	else if (no <= 5 && Pazls[no + 3].gameObject)
    //	{
    //		Debug.Log("è„");
    //	}
    //	else if (no % 3 != 2 && Pazls[no + 1].gameObject)
    //		{
    //			Debug.Log("âE");
    //		}
    //		else if (no % 3 != 0 && Pazls[no - 1].gameObject)
    //		{
    //			Debug.Log("ç∂");
    //		}
    //	}

}


