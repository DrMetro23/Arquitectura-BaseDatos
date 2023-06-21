using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Purpose:
* Looping the object transform across a rectangle gameArea.Area
*/

[AddComponentMenu ("ESI/GameAreaKeeper")]
public class GameAreaKeeper : MonoBehaviour
{

    //public Rect area;
    public GameArea gameArea;
    private Vector3 areaSpacePosition;

    // Update is called once per frame
    void Update()
    {
        //areaSpacePosition = transform.areaSpacePosition;
        areaSpacePosition = gameArea.transform.InverseTransformPoint(transform.position);

        if (gameArea.Area.Contains(areaSpacePosition))
            return;

        if (areaSpacePosition.x < gameArea.Area.xMin)
            areaSpacePosition.x = gameArea.Area.xMax;
        else if (areaSpacePosition.x > gameArea.Area.xMax)
            areaSpacePosition.x = gameArea.Area.xMin;

        if (areaSpacePosition.y < gameArea.Area.yMin)
            areaSpacePosition.y = gameArea.Area.yMax;
        else if (areaSpacePosition.y > gameArea.Area.yMax)
            areaSpacePosition.y = gameArea.Area.yMin;

        transform.position = gameArea.transform.TransformPoint(areaSpacePosition);
    }
}
