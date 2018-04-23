using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    public Transform target;

    public float offsetX = 0f;
    public float offsetY = 25f;
    public float offsetZ = -35f;
    Vector3 cameraPosition;
    
    void LateUpdate()
    {
        cameraPosition.x = target.transform.position.x + offsetX;
        cameraPosition.y = target.transform.position.y + offsetY;
        cameraPosition.z = target.transform.position.z + offsetZ;

        transform.position = Vector3.Lerp(transform.position, cameraPosition, 2.5f*Time.deltaTime);

        
    }
}
