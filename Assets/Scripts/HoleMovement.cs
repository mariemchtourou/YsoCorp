using System.Collections.Generic;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [Header("HoleMesh")]
    [SerializeField] MeshFilter meshfilter;
    [SerializeField] MeshCollider meshCollider;

    [Header("Hole Sommet Radius")]
    [SerializeField] float radius;
    [SerializeField] Transform holeCenter;
    [SerializeField] Vector2 moveLimits;

    [Space]
    [SerializeField] float moveSpeed;

    Mesh mesh;
    List<int> holeVertices;
    List<Vector3> offsets;
    int holeVerticesCount;

    float x, y;
    Vector3 touch, targetPos;

    void Start()
    {
        Game.isMoving = false;
        Game.isGameover = false;

        holeVertices = new List<int>();
        offsets = new List<Vector3>();
        
        mesh = meshfilter.mesh;

        //Trouver les sommets dans mesh
        FindHoleVertices();
    }

    // Update is called once per frame
    void Update()
    {
        Game.isMoving = Input.GetMouseButton(0);
        if (!Game.isGameover && Game.isMoving)
        {
            //changer le centre du trou
            MoveHole();
            //changer les sommets du cercle
            UpdateHoleVerticesPosition();
        }
    }
    //changer le centre du trou
    void MoveHole()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        touch = Vector3.Lerp(
            holeCenter.position, 
            holeCenter.position + new Vector3(x,0f,y), 
            moveSpeed * Time.deltaTime);

        targetPos = new Vector3(
            //Clamp: to prevent hole from going outside of the ground
            Mathf.Clamp(touch.x, -moveLimits.x, moveLimits.x),//limit X
            touch.y,
            Mathf.Clamp(touch.z, -moveLimits.y, moveLimits.y)//limit Z
        );

        holeCenter.position = targetPos;
    }
    //changer les sommets du cercle
    void UpdateHoleVerticesPosition()
    {
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < holeVerticesCount; i++)
        {
            vertices[holeVertices[i]] = holeCenter.position + offsets[i];
        }
        // maj mesh
        mesh.vertices = vertices;
        meshfilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
    }
    void FindHoleVertices()
    {
        for (int i=0; i<mesh.vertices.Length; i++)
        {
            float distance = Vector3.Distance(holeCenter.position, mesh.vertices[i]);
            if (distance < radius)
            {
                holeVertices.Add(i);
                offsets.Add(mesh.vertices[i] - holeCenter.position);
            }
        }
        holeVerticesCount = holeVertices.Count;
    }
}
