using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewItemGenarator : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;
    //coinPrefab������
    public GameObject coinPrefab;
    //cornPrefab������
    public GameObject conePrefab;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;
    //Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;
    //�S�[���̃I�u�W�F�N�g
    private GameObject goal;
    //Unity�����̃I�u�W�F�N�g�ƃA�C�e���Ƃ̋���
    private float difference = 40.0f;
    //Unity�����̃I�u�W�F�N�g�ƃS�[���Ƃ̋���
    private float distance;
    float span = 0.9f;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
        //�S�[���̃I�u�W�F�N�g���擾
        this.goal = GameObject.Find("Goal");
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        //Unity�����ƃS�[���Ƃ̋���
        this.distance = goal.transform.position.z - unitychan.transform.position.z;
        //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
        int num = Random.Range(1, 11);
        if (num <= 2&&this.delta>this.span&&this.distance>60)
        {
            this.delta = 0;
            //�R�[����x�������Ɉ꒼���ɐ���
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan.transform.position.z + difference);
            }
        }
        else if(num > 2 && this.delta > this.span&&this.distance > 60)
        {
            this.delta = 0;
            //���[�����ƂɃA�C�e���𐶐�
            for (int j = -1; j <= 1; j++)
            {
                //�A�C�e���̎�ނ����߂�
                int item = Random.Range(1, 11);
                //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                int offsetZ = Random.Range(1, 10);
                //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                if (1 <= item && item <= 6)
                {
                    //�R�C���𐶐�
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychan.transform.position.z + difference + offsetZ);

                }
                else if (7 <= item && item <= 9)
                {
                    //�Ԃ𐶐�
                    GameObject car = Instantiate(carPrefab);
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychan.transform.position.z + difference + offsetZ);
                }
            }




        }
        Debug.Log("" + distance);
    }
}
