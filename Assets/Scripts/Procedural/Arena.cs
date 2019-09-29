using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallGame.Procedural {
  public class Arena : MonoBehaviour {
    public int players = 3;
    public float goalDeg = 180f;
    public float radius = 5f;
    public float goalDepth = 6f;

    public ArenaFloor arenaFloor;

    // void Start() {

    // }

    public void Clear(){
      arenaFloor.Clear();
    }

    public void Generate(){
      arenaFloor.Generate(
        players,
        goalDeg,
        radius,
        goalDepth
      );
    }
  }
}
