using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Transform player; 
    public LineRenderer lineRenderer; 
   // public int maxPoints = 100; 

    private List<Vector3> pathPoints = new List<Vector3>();

    private void Update()
    {
        Vector3 playerPosition = new Vector3(player.position.x, player.position.y+ 0.15f , player.position.z);

        // Dodaj now� pozycj� do listy
        pathPoints.Add(playerPosition);

        // Je�li przekroczono maksymaln� liczb� punkt�w, usu� najstarszy punkt
     //  if (pathPoints.Count > maxPoints)
     //  {
     //      pathPoints.RemoveAt(0);
     //  }

        // Ustaw punkty linii
        lineRenderer.positionCount = pathPoints.Count;
        lineRenderer.SetPositions(pathPoints.ToArray());
    }
}
