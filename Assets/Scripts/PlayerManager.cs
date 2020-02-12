using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;
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

    Camera cam;
    public LayerMask groundMask;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, groundMask))
            {
                GameSceneManager.instance.getCurrentBlob().ManualMovement(hit.point);
            }
        }


    }
}
