using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{

    //スタートボタンを押したら実行する
    public void StartGame()
    {
        SceneManager.LoadScene("Maingame");// ３×３の呼び出し

      /*  SceneManager.LoadScene("Maingame 1");// 呼び出し*/
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
    }
}
