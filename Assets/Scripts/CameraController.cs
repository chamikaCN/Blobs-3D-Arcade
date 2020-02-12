using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Singleton
    
    public static CameraController instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("many cameracontollers");
            return;
        }

        instance = this;
    }
    #endregion
    public Transform target;
    public Vector3 offset;

    public float maxZoom = 15f, minZoom = 5f, zoomSpeed = 4f, yawSpeed = 10f;
    float currrentZoom = 10f, currentYaw = 1f, pitch = 2f;

    void Update()
    {
        currrentZoom -= Input.GetAxis("Mouse ScrollWheel")*zoomSpeed;
        currrentZoom = Mathf.Clamp(currrentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }
    void LateUpdate()
    {
        transform.position = target.position + offset;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }

    public void setTransform(Transform transform)
    {
        target = transform;

    }
}