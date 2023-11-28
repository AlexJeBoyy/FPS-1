using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshRenderer))]

public class MeshGenerator : MonoBehaviour
{
    Vector3[] vertices;
    int[] triangles;
    Mesh mesh;
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }


    void CreateShape()
    {
        vertices = new Vector3[]
        {
            new Vector3 (0f, 0f , 0f), //0 
            new Vector3 (1f, 0f , 0f), //1
            new Vector3 (0f, 0f , 1f), //2
            new Vector3 (1f, 0f , 1f), //3
            new Vector3 (0.5f, 1f , 0.5f), //4
            new Vector3 (0.5f , -1f, 0.5f), //5
        };

        triangles = new int[]
        {
            //middles
            0, 1, 2,
            3, 2, 1,
            //top
             1, 0, 4,
             0, 2, 4,
             2, 3, 4,
             3, 1, 4,
             //bottom
             1, 0, 5,
             0, 2, 5,
             2, 3, 5,
             3, 1, 5,






        };
    }
    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

}
