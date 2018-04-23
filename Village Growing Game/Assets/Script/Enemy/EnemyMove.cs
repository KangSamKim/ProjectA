using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    private float targetdis;
    private GameObject PlayerTarget;


	void Start () {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
	}
	
	
	void Update () {
        targetdis = Vector3.Distance(this.transform.position, PlayerTarget.transform.position);
        if(targetdis <=10f) // 거리가 10안에 들어오면?
        {

        }
        else // 그게아니라면 ?
        {
            MovePatten();
        }
	}

    void MovePatten()
    {

    }
}
