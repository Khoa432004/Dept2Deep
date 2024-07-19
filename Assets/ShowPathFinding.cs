using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPathFinding : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public List<Vector3> path;

    void Start()
    {
        if (lineRenderer != null && path != null && path.Count > 0)
        {
            ShowPath();
        }
        else
        {
            Debug.LogError("Không thấy đường đi");
        }
    }

    void ShowPath()
    {
        if (lineRenderer != null && path != null && path.Count > 0)
        {
            lineRenderer.positionCount = path.Count;
            lineRenderer.SetPositions(path.ToArray());
        }
        else
        {
            Debug.LogWarning("Không có path để vẽ");
        }
    }

}