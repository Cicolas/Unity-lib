using UnityEngine;
using Anna.utils;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Plane : MonoBehaviour {

    [Header("Dimensions")]
    public int width;
    public int height;
    public float resolution;

    private Vector3[] vertices;
    private Vector2[] vertices2D;
    private int[] triangles;
    private Mesh mesh;

    private void Start() {
        CreateQuad();
    }

    public void CreateQuad(){
        vertices = new Vector3[(width+1)*(height+1)];
        vertices2D = new Vector2[(width+1)*(width+1)];
        triangles = new int[(width) * (height) * 6];
        
        mesh = GetComponent<MeshFilter>().sharedMesh;

        for (int j = 0, k = 0; j <= height; j++)
        {
            for (int i = 0; i <= width; i++)
            {
                vertices[k] = new Vector3(i*resolution, j*resolution);
                vertices2D[k] = new Vector2((float)i/width, (float)j/height);
                k++;
            }
        }

        int indice = 0;
        int vertex = 0;
        for (int j = 0; j < height; j++)
        {
            for (int i = 0; i < width; i++)
            {

                triangles[indice] = vertex; //0
                triangles[indice+1] = vertex+width+1; //1
                triangles[indice+2] = vertex+1; //2
                triangles[indice+3] = vertex+1; //2
                triangles[indice+4] = vertex+width+1; //3
                triangles[indice+5] = vertex+width+2; //1

                vertex++;
                indice+=6;
            }
            vertex++;
        }

        mesh.vertices = vertices;
        mesh.uv = vertices2D;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();
    }
}