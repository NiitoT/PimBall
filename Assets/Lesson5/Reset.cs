using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {


    public void OnClick() {

        Debug.Log("button click!");

            SceneManager.LoadScene("GameScene");

    }

}
