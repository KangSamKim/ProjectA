using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
    private Image fade;

    public float animTime = 2f; // fade 재생시간

    private float start = 1f;
    private float end = 0f;
    private float time = 0f;

    private bool Play = false;

    void Awake()
    {
        fade = this.GetComponent<Image>();
    }
    void Start () {
        
        StartCoroutine("PlayFadeIn");
    }
	
	
    IEnumerator PlayFadeIn()
    {
        Color color = fade.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0f)
        {
            time += Time.deltaTime / animTime;

            color.a = Mathf.Lerp(start, end, time);
            fade.color = color;
            if(color.a==0f) // 컨트롤 ui를 위한 날리기
            {
                fade.gameObject.SetActive(false);
            }
            yield return null;
        }
    }
}
