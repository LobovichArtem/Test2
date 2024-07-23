using System;
using UnityEngine;

public class ScreenEdgeColliders : MonoBehaviour
{
    void Awake()
    {
        AddCollider();
    }

    private void AddCollider()
    {
        if (Camera.main == null)
            throw new Exception("Camera.main not found, failed to create edge colliders");

        var cam = Camera.main;
        if (!cam.orthographic)
            throw new Exception("Camera.main is not Orthographic, failed to create edge colliders");

        var bottomLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        var topLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        var topRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        var bottomRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));


        var edge = GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : GetComponent<EdgeCollider2D>();

        var edgePoints = new[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
        edge.points = edgePoints;
    }
}
