using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderContrl : MonoBehaviour
{
    public Collider TurnRight;
    public Collider TurnLeft;
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "TurnRight")
		{
			StartCoroutine(DisableColliderForTime(TurnLeft, 2.0f));
		}
		if (collision.gameObject.tag == "TurnLeft")
		{
			StartCoroutine(DisableColliderForTime(TurnRight, 2.0f)); // 2秒間無効にする例
		}
	}
	private IEnumerator DisableColliderForTime(Collider collider, float disableTime)
    { 
        collider.enabled = false; // コライダーを無効にする
        yield return new WaitForSeconds(disableTime); // 指定時間待つ
        collider.enabled = true; // コライダーを再び有効にする
    }
}