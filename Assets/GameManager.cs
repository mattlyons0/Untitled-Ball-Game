using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;

    void Start()
    {
        ball = Instantiate(ball);
    }
}
