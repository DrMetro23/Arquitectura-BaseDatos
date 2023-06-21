using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <sumary>
/// Purpose:
/// Defines a Rectangular Area.
/// </summary>

[AddComponentMenu ("ESI/GameArea")]
public class GameArea : MonoBehaviour
{
    [SerializeField]
    [HideInInspector]
    private Rect _area;

    public Rect Area
    {
        get { return _area; }
        set { _area = value; }
    }

    public Vector2 size;
    public Vector2 Size
    {
        get { return Area.size ;}
        set
        {
            size = value;
            Area = new Rect(size.x * -0.5f, size.y * -0.5f, size.x, size.y);
        }
    }

    public Color gizmoColor = new Color(0, 0, 1, 0.2f);
    private Color gizmoWireColor;

    //public void SetArea (Vector2 size)
    //{
        //Area = new Rect (0, 0, size.x, size,y);
        //Area = new Rect (Vector2.zero, size);
        //Area = new Rect (size.x * -0.5f, size.y * -0.5f, size.x, size.y);
    //}

    private void Awake() 
    {
        //SetArea(size);
    }

    void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = gizmoColor;
        //Gizmos.DrawSphere(transform.position, 1);
        Gizmos.DrawCube(Vector3.zero, new Vector3(Area.width, Area.height, 0));
        Gizmos.color = gizmoWireColor;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(Area.width, Area.height, 0));
    }

    //Method to make changes on execution time
    void OnValidate(){
        //SetArea(size);
        Size = size;
        gizmoWireColor = new Color (gizmoColor.r, gizmoColor.g, gizmoColor.b, 1);
    }

    public Vector3 GetRandomPosition ()
    {
        Vector3 randomPos = Vector3.zero;
        randomPos.x = Random.Range(Area.xMin, Area.xMax);
        randomPos.y = Random.Range(Area.yMin, Area.yMax);
        randomPos = transform.TransformPoint(randomPos);

        return randomPos;
    }

}
