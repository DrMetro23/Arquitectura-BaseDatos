using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu ("ESI/FitAreaToCamera")]
[RequireComponent (typeof (GameArea))]
public class FitAreaToCamera : MonoBehaviour
{
    private GameArea area;

    void Awake()
    {
        area = GetComponent<GameArea>();
    }

    private GameArea Area
    {
        get { return GetComponent<GameArea>(); }
    }

    private void FitToCamera(Camera cam)
    {
        //cam.aspect
        //cam.orthographicsSize

        //Area.SetArea(new Vector2 (cam.aspect * cam.orthographicSize * 2, cam.orthographicSize * 2));
        Area.Size = new Vector2(cam.aspect * cam.orthographicSize * 2, cam.orthographicSize * 2);
        transform.position = (Vector2)cam.transform.position;
        transform.rotation = cam.transform.rotation;
    }

    private void FitToMainCamera()
    {
        FitToCamera(Camera.main);
    }

    /*private void OnValidate()
    {
        FitToMainCamera();
    }*/

    private void Reset()
    {
        FitToMainCamera();
    }
}
