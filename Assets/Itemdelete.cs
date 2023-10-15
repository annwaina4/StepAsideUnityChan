using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemdelete : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //カメラのオブジェクト
    private GameObject camera;
    //Unityちゃんとカメラの距離
    private float difference;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //カメラのオブジェクトを取得
        this.camera = GameObject.Find("Main Camera");
        //Unityちゃんとカメラの位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - camera.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        //アイテムがカメラから見えなくなったら破棄する
        if(unitychan.transform.position.z -this.transform.position.z>difference)
        {
            Destroy(this.gameObject);
        }

        
    }
}
