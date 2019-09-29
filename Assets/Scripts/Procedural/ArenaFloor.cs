using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallGame.Procedural {
  [RequireComponent(
    typeof(MeshFilter), typeof(MeshRenderer)
  )]
  public class ArenaFloor : MonoBehaviour {
    Mesh mesh;
    List<Vector3> vertices;
    List<Color> colors;

    public void Clear(){
      if (mesh != null) {
        mesh.Clear();
      }

      vertices = new List<Vector3>();
      colors = new List<Color>();
    }

    public void Generate(
      int players, float goalDeg, float radius, float goalDepth
    ){
      Debug.Log($"Drawing floor for {players} player(s)");
      Clear();
      vertices.Add(Vector3.zero);
      colors.Add(Color.red);

      float angleDeg = 0;
      float step = 360f / players;

      for(int i = 0; i < 360; ++i){
        float startPos = angleDeg - goalDeg / 2;
        float endPos = angleDeg + goalDeg / 2;

        // Start the goal post
        vertices.Add(
          DrawSphere.CastToAngle(startPos % 360, radius)
        );
        colors.Add(Color.blue);
        // Middle of goal
        vertices.Add(
          DrawSphere.CastToAngle(angleDeg % 360, goalDepth)
        );
        colors.Add(Color.blue);
        // End the goal post
        vertices.Add(
          DrawSphere.CastToAngle(endPos % 360, radius)
        );
        colors.Add(Color.blue);

        angleDeg += step;
        // if(i % step == 0){
        //   Debug.Log("Add Player");
        //   // vertices.Add(
        //   //   DrawSphere.CastToAngle(startPos % 360, radius)
        //   // );
        //   // // Middle of goal
        //   // vertices.Add(
        //   //   DrawSphere.CastToAngle(angleDeg % 360, goalDepth)
        //   // );
        //   // // End the goal post
        //   // vertices.Add(
        //   //   DrawSphere.CastToAngle(endPos % 360, radius)
        //   // );
        //   i += step;
        //   angleDeg += step;
        // }else{
        //   vertices.Add(
        //     DrawSphere.CastToAngle(angleDeg % 360, radius)
        //   );
        //   angleDeg++;
        // }
      }

      CreateMesh();
    }

    void CreateMesh(){
        if (mesh == null) {
          mesh = new Mesh();
        }

        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = vertices.ToArray();
        mesh.triangles = DrawSphere.BuildTriangles(vertices.Count - 1);
        mesh.colors = colors.ToArray();
        mesh.RecalculateNormals();
    }
  }
}
