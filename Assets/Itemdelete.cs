using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemdelete : MonoBehaviour
{
    //Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;
    //�J�����̃I�u�W�F�N�g
    private GameObject camera;
    //Unity�����ƃJ�����̋���
    private float difference;

    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
        //�J�����̃I�u�W�F�N�g���擾
        this.camera = GameObject.Find("Main Camera");
        //Unity�����ƃJ�����̈ʒu�iz���W�j�̍������߂�
        this.difference = unitychan.transform.position.z - camera.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        //�A�C�e�����J�������猩���Ȃ��Ȃ�����j������
        if(unitychan.transform.position.z -this.transform.position.z>difference)
        {
            Destroy(this.gameObject);
        }

        
    }
}
