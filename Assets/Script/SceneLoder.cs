using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoder : MonoBehaviour
{
	public void LoadMainGame(){
		SceneManager.LoadScene("Maingame");
	}
	public void LoadTitle() {
		SceneManager.LoadScene("Title");
	}
	public void LoadResult() {
		SceneManager.LoadScene("Result");
	}
}
