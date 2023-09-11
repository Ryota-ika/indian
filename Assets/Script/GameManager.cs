using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    SceneLoder mySL;
    [SerializeField]
    DeathLineControll deth;
    [SerializeField]
    GameObject gameOverText;
    bool isGameOver=false;
  
   bool  gameCleart = false;
    [SerializeField]
    Criascript clear;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (deth.GetIsHit()&&!isGameOver) {
            StartCoroutine(GameOver());
        }

        if (clear.GetIsHit() && !gameCleart)
        {
            StartCoroutine(GameClear());
        }
    }

    IEnumerator GameOver() {
        isGameOver = true;
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(3);
        mySL.LoadResult();
       
    }

   IEnumerator GameClear()
    {
        gameCleart = true;
        yield return new WaitForSeconds(1);
        mySL.LoadClear();
    }

}
