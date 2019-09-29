using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour {
    public GameObject ballPrefab;

    void Start() {
        AddBall();
    }

    void AddBall(){
		if(NetworkServer.active){
            Debug.Log("Adding Ball!");
            GameObject ball = (GameObject)Instantiate(
                ballPrefab,
                transform.position,
                transform.rotation
            );
            NetworkServer.Spawn(ball);
        }else{
            Debug.Log("Network not ready");
        }
    }
}
