using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallGame.Procedural {
  public static class DrawSphere {
    // Helper class for helpful circle calcs
    [Range(1, 100)]
    public static float radius = 5f;
    [Range(0, 360)]
    public static float startAngle = 0f;
    [Range(0, 360)]
    public static float arc = 360f;

    public static Vector3 CastToAngle(float angleDeg){
      return CastToAngle(angleDeg, radius);
    }

    public static Vector3 CastToAngle(float angleDeg, float radius){
        float angleRad = Mathf.PI / 180 * angleDeg;
        Vector3 pointOnCircle = new Vector3(
            radius * Mathf.Sin(angleRad),
            0,
            radius * Mathf.Cos(angleRad)
        );

        return pointOnCircle;
    }

    public static int[] BuildTriangles(int steps){
      int[] triangles = new int[steps * 3];

      for(int i = 0; i < steps; i++){
          int startIndex = i * 3;
          triangles[startIndex] = 0;
          triangles[startIndex+1] = i+1;

          int endPoint = i+2;
          if(endPoint > steps){
              endPoint = 1;
          }
          triangles[startIndex+2] = endPoint;
      }
      return triangles;
    }
  }
}