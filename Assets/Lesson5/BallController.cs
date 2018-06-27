using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    private GameObject ScoreText;


    private int score = 0;

    private int deathtime = 0;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");


        ScoreText = GameObject.Find("Score Text");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            deathtime += 1;

            Vector3 pos = transform.position;
            pos.x = 3;
            pos.y = 3;
            pos.z = 2;
            transform.position = pos;
        }

        if (deathtime > 2)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
            this.gameObject.SetActive(false);

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    // タッチ開始
                    Debug.Log("リセット");
                    SceneManager.LoadScene("GameScene");

                }


                

            }
        }

        this.ScoreText.GetComponent<Text>().text = score.ToString();

        if (Input.GetKey("left shift"))
        {
            Debug.Log("LeftShiftChara");
            SceneManager.LoadScene("GameScrene");
        }



    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "LargeCloudTag")
        {
            score += 300;

            Debug.Log(score);
        }
        if (other.gameObject.tag == "SmallCloudTag")
        {
            score += 100;

            Debug.Log(score);
        }
        if (other.gameObject.tag == "LargeStarTag")
        {
            score += 50;

            Debug.Log(score);
        }
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 10;

            Debug.Log(score);
        }

    }


}