using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatCam : MonoBehaviour {
    public Transform Target;
    private float dis = 2.5f; // 떨어질 z값거리
    private float height = 2f; // 높이 y값

    private Transform thistrans; // 자기 트랜스폼값
	// Use this for initialization
	void Start () {
        thistrans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float currYAngle = Mathf.LerpAngle(thistrans.eulerAngles.x, Target.eulerAngles.x, 2.5f * Time.smoothDeltaTime);
        Quaternion rot = Quaternion.Euler(0, currYAngle, 0);

        thistrans.position = Target.position - (rot * Vector3.forward * dis) + (Vector3.up * height);

        thistrans.LookAt(Target);
	}
}
