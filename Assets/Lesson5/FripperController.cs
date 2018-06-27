using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;
    private int leftFingerId = 0;
    private int rightFingerId = 0;
    private float defaultAngle = 20;
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            int id = Input.touches[i].fingerId;
            TouchPhase phase = Input.touches[i].phase;
            Vector2 pos = Input.touches[i].position;

            if (phase == TouchPhase.Began)
            {
                Debug.LogFormat("Touch Began. fingerId:{0}, x:{1}, Screen.width:{2}, Tag: {3}", id, pos.x, Screen.width, tag);

                if (pos.x > Screen.width * 0.5 && tag == "RightFripperTag") // タイプミスがありますね
                {
                    Debug.Log("Flick Right Fripper");
                    rightFingerId = id;
                    SetAngle(this.flickAngle);
                }
                else if (pos.x < Screen.width * 0.5 && tag == "LeftFripperTag") // タイプミスがありますね
                {
                    Debug.Log("Flick Left Fripper");
                    leftFingerId = id;
                    SetAngle(this.flickAngle);
                }
            }
            else if (phase == TouchPhase.Ended)
            {
                Debug.LogFormat("Touch Ended. fingerId:{0}, x:{1}, Screen.width:{2}, Tag: {3}", id, pos.x, Screen.width, tag);

                if (id == rightFingerId && tag == "RightFripperTag") // タイプミスがありますね
                {                                 
                    Debug.Log("Release Right Fripper");
                    SetAngle(this.defaultAngle);
                }
                else if (id == leftFingerId && tag == "LeftFripperTag")
                {
                    Debug.Log("Release Left Fripper");
                    SetAngle(this.defaultAngle);
                }
            }
        }
    }

    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}