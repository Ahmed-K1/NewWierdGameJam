using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Header("Follow")]
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);

    [Header("Zoom")]
    public Camera cam;
    public float zoomSpeed = 5f;
    public float minZoom = 3f;
    public float maxZoom = 15f;

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }

        if (cam != null)
        {
            float scroll = Input.mouseScrollDelta.y;
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
    }
}