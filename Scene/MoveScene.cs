using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    [SerializeField]
    private string targetScene;

    [SerializeField]
    private RectTransform curtain;

    [SerializeField]
    private CurtainUpDown updowner;

    public void Move()
    {
        StartCoroutine(MoveCoroutine());
    }

    //public void MoveStage()
    //{
    //    StartCoroutine(MoveCoroutineUpdowner());
    //}

    //IEnumerator MoveCoroutineUpdowner()
    //{
    //    updowner.value = true;
    //    yield return new WaitForSeconds(0.5f);
    //    SceneManager.LoadScene(targetScene);
    //}

    IEnumerator MoveCoroutine()
    {
        //float screenWidth = 1920.0f;
        //float screenHeight = screenWidth * ((float)Screen.height / Screen.width);
        //int iteratorTime = 35;

        //for (int i = 0; i <= iteratorTime; i++)
        //{
        //    curtain.sizeDelta = new Vector2((screenWidth / iteratorTime) * i, screenHeight);
        yield return new WaitForSecondsRealtime(0.01f);
        //};

        SceneManager.LoadScene(targetScene);
    }
}
