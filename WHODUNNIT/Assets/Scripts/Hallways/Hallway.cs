using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway : MonoBehaviour
{
    public Vector3 startAnchor;
    public float startAngle;

    public Vector3 endAnchor;
    public float endAngle;

    public void OnDrawGizmosSelected()
    {
        float a = Mathf.Deg2Rad * endAngle;
        float x = endAnchor.x + (1 * Mathf.Cos(a));
        float z = endAnchor.z + (1 * Mathf.Sin(a));

        Vector3 endPos = new Vector3(x, endAnchor.y, z);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.TransformPoint(endAnchor), transform.TransformPoint(endPos));
        Gizmos.DrawSphere(transform.TransformPoint(endAnchor), 0.2f);


        a = Mathf.Deg2Rad * startAngle;
        x = startAnchor.x + (1 * Mathf.Cos(a));
        z = startAnchor.z + (1 * Mathf.Sin(a));

        endPos = new Vector3(x, startAnchor.y, z);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.TransformPoint(startAnchor), transform.TransformPoint(endPos));

        Gizmos.DrawSphere(transform.TransformPoint(startAnchor), 0.2f);
    }
}
