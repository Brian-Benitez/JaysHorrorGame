using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    Mesh Mesh;
    Vector3[] Vertices;
    int[] Triangles;
    Color[] Colors;

    public Gradient Gradient;

    public int XSize;
    public int ZSize;

    private float _minTerrainHeight;
    private float _maxTerrainHeight;

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
                    if(y > _maxTerrainHeight)
                        _maxTerrainHeight = y;
                    if(y < _minTerrainHeight)
                        _minTerrainHeight = y;

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

        Colors = new Color[Vertices.Length];
        for (int z = 0, i = 0; z <= ZSize; z++)
        {
            for (int x = 0; x < XSize; x++)
            {
                float height = Mathf.InverseLerp(_minTerrainHeight, _maxTerrainHeight, Vertices[i].y);
                Colors[i] = Gradient.Evaluate(height);
                i++;
            }
        }
    }

    void UpdateMesh()
    {
        Mesh.Clear();
        Mesh.vertices = Vertices;
        Mesh.triangles = Triangles;
        Mesh.colors = Colors;
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
