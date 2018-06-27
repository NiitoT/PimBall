using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarContoroller : MonoBehaviour {

    //回転速度
    private float rotSpeed = 1.0f;

    void Start()
    {
        //回転を開始する角度を設定
        this.transform.Rotate(0, Random.Range(0, 360), 0);
    }

    void Update()
    {
        //回転
        this.transform.Rotate (0, this.rotSpeed, 0);
    }

}
