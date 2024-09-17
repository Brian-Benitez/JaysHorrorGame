using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    Mesh Mesh;
    Vector3[] Vertices;
    int[] Triangles;

    public int XSize;
    public int ZSize;

    private void Start()
    {
        Mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = Mesh;
        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        Vertices = new Vector3[(XSize + 1) * (ZSize + 1)];
        {
           
            for (int i = 0, z = 0; z <= ZSize; z++)
            {
                for (int x = 0; x <= XSize; x++)
                {
                    float y = Mathf.PerlinNoise(x * .3f, z * .3f) *2f;
                    Vertices[i] = new Vector3(x, y, z);
                    i++;
                }
            }
        };

        Triangles = new int[XSize * ZSize * 6];
        int vert = 0;
        int tris = 0;

        for (int z = 0; z < ZSize; z++)
        {
            for (int i = 0; i < XSize; i++)
            {
                Triangles[tris + 0] = vert + 0;
                Triangles[tris + 1] = vert + XSize + 1;
                Triangles[tris + 2] = vert + 1;
                Triangles[tris + 3] = vert + 1;
                Triangles[tris + 4] = vert + XSize + 1;
                Triangles[tris + 5] = vert + XSize + 2;
                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    void UpdateMesh()
    {
        Mesh.Clear();
        Mesh.vertices = Vertices;
        Mesh.triangles = Triangles;

        Mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if(Vertices ==  null)
            return;

        for(int i = 0; i < Vertices.Length; i++)
        {
            Gizmos.DrawSphere(Vertices[i], .1f);
        }
    }
}
