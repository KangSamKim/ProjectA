using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
    public Image fade;

    public float animTime = 2f; // fade 재생시간

    private float start = 0f;
    private float end = 1f;
    private float time = 0f;

    private bool Play = false;

    
    public void Start_Game() {
        fade.gameObject.SetActive(true);
        if(Play == true)
        {
            return;
        }
        
        StartCoroutine("PlayFadeOut");
    }
    
    IEnumerator PlayFadeOut()
    {
        Play = true;
        Color color = fade.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while(color.a <1f)
        {
            time += Time.deltaTime / animTime;

            color.a = Mathf.Lerp(start, end, time);
            fade.color = color;
            yield return null;
        }
        Play = false;
        SceneManager.LoadScene("Loding");
    }
}
