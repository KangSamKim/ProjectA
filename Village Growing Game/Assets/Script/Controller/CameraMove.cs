using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public Transform target;
    public float dis = 10.0f;
    public float height = 5.0f;
    public float smoothRotate = 5.0f;

    private Transform CamaraTr;
	// Use this for initialization
	void Start () {
        CamaraTr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float currYAngle = Mathf.LerpAngle(CamaraTr.eulerAngles.y, target.eulerAngles.y, smoothRotate * Time.deltaTime);

        Quaternion rot = Quaternion.Euler(0, currYAngle, 0);
        CamaraTr.position = target.position - (rot* Vector3.forward *dis)+ (Vector3.up * height);


        CamaraTr.LookAt(target);
	}
}
