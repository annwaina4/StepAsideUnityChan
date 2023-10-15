using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewItemGenarator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //ゴールのオブジェクト
    private GameObject goal;
    //Unityちゃんのオブジェクトとアイテムとの距離
    private float difference = 40.0f;
    //Unityちゃんのオブジェクトとゴールとの距離
    private float distance;
    float span = 0.9f;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //ゴールのオブジェクトを取得
        this.goal = GameObject.Find("Goal");
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        //Unityちゃんとゴールとの距離
        this.distance = goal.transform.position.z - unitychan.transform.position.z;
        //どのアイテムを出すのかをランダムに設定
        int num = Random.Range(1, 11);
        if (num <= 2&&this.delta>this.span&&this.distance>60)
        {
            this.delta = 0;
            //コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan.transform.position.z + difference);
            }
        }
        else if(num > 2 && this.delta > this.span&&this.distance > 60)
        {
            this.delta = 0;
            //レーンごとにアイテムを生成
            for (int j = -1; j <= 1; j++)
            {
                //アイテムの種類を決める
                int item = Random.Range(1, 11);
                //アイテムを置くZ座標のオフセットをランダムに設定
                int offsetZ = Random.Range(1, 10);
                //60%コイン配置:30%車配置:10%何もなし
                if (1 <= item && item <= 6)
                {
                    //コインを生成
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychan.transform.position.z + difference + offsetZ);

                }
                else if (7 <= item && item <= 9)
                {
                    //車を生成
                    GameObject car = Instantiate(carPrefab);
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychan.transform.position.z + difference + offsetZ);
                }
            }




        }
        Debug.Log("" + distance);
    }
}
