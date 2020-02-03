using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlaneGen : MonoBehaviour
{
    public float w_size = 1;
    public int w_grid_size = 16;

    private MeshFilter filter;

    // Start is called before the first frame update
    void Start()
    {
        filter = GetComponent<MeshFilter>();
        filter.mesh = GenerateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Mesh GenerateMesh()
    {
        Mesh m = new Mesh();
        var vertices = new List<Vector3>();
        var normals = new List<Vector3>();
        var uvs = new List<Vector2>();

        for(int x = 0; x < w_grid_size + 1; x++)
        {
            for(int y = 0; y < w_grid_size + 1; y++)
            {
                vertices.Add(new Vector3(-w_size * 0.5f + w_size * (x / ((float)w_grid_size)), 0, -w_size * 0.5f + w_size * (y / ((float)w_grid_size))));
                normals.Add(Vector3.up);
                uvs.Add(new Vector2(x / (float)w_grid_size, y / (float)w_grid_size));
            }
        }

        var triangles = new List<int>();
        var vert_count = w_grid_size + 1;
        for(int i = 0; i < vert_count * vert_count - vert_count; i++)
        {
            if((i + 1) % vert_count == 0)
            {
                continue;
            }
            triangles.AddRange(new List<int>()
            {
                i+1+vert_count, i+vert_count, i,
                i, i+1, i+1+vert_count
            });
        }

        m.SetVertices(vertices);
        m.SetNormals(normals);
        m.SetUVs(0, uvs);
        m.SetTriangles(triangles, 0);

        return m;
    }
}
