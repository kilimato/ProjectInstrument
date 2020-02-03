using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWaterNoise : MonoBehaviour
{
    public float power = 3;
    public float scale = 1;
    public float time_scale = 1;

    private float offsetX;
    private float offsetY;
    private MeshFilter mf;

    // Start is called before the first frame update
    void Start()
    {
        mf = GetComponent<MeshFilter>();
        MakeNoise();
    }

    // Update is called once per frame
    void Update()
    {
        MakeNoise();
        offsetX += Time.deltaTime * time_scale;
        if (offsetY <= 0.1) offsetY += Time.deltaTime * time_scale;
        if (offsetY >= power) offsetY -= Time.deltaTime * time_scale;
    }

    void MakeNoise()
    {
        Vector3[] vertices = mf.mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = CalculateHeight(vertices[i].x, vertices[i].z * power);
        }

        mf.mesh.vertices = vertices;
    }

    float CalculateHeight(float x, float y)
    {
        float cordinateX = x * scale + offsetX;
        float cordinateY = y * scale + offsetY;

        return Mathf.PerlinNoise(cordinateX, cordinateY);
    }
}
