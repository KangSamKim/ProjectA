
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Outing : MonoBehaviour {

    private float time = 0;
    private float timer = 2f;

   void Update()
    {
        time += Time.deltaTime;
        if (time > 5f)
        {
            SceneManager.LoadScene("Robby");
        }
    }
}
