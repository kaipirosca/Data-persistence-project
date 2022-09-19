using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public static string playerName;

    public void StartNew()
    {
        playerName = GameObject.Find("NameInput").GetComponent<InputField>().text;
        MySceneManager.Instance.playerName = playerName;

        SceneManager.LoadScene(1);
    }
}
