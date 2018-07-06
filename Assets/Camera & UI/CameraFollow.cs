using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform playerTransform;

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (go == null)
        {
            Debug.LogError("Couldn't find player!");
            return;
        }
        playerTransform = go.transform;
    }

	void LateUpdate () {
        transform.position = playerTransform.position;
	}
}
