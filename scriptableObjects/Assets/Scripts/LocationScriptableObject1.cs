using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu
    (
    fileName = "New Location",
    menuName = "New Location",
    order = 0
    )
]

public class LocationScriptableObject1 : ScriptableObject
{
    public string locationName;
    public string locationDesc;
    public LocationScriptableObject1 north;
    public LocationScriptableObject1 south;
    public LocationScriptableObject1 east;
    public LocationScriptableObject1 west;
    public void PrintLocation()
    {
        string printStr =
            "\n Location Name: " + locationName +
            "\n Location Description: " + locationDesc;
        Debug.Log(printStr);
    }

    public void UpdateCurrentLocation(GameManager gm)
    {
        gm.titleUI.text = locationName;
        gm.descriptionUI.text = locationDesc;
        // turning off north button if no further north options
        if (north == null)
        {
            gm.buttonNorth.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonNorth.gameObject.SetActive(true);
            north.south = this;
        }
        // south button
        if (south == null)
        {
            gm.buttonSouth.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonSouth.gameObject.SetActive(true);
            south.north = this;
        }
        // east button
        if (east == null)
        {
            gm.buttonEast.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonEast.gameObject.SetActive(true);
            east.west = this;
        }
        // west button
        if (west == null)
        {
            gm.buttonWest.gameObject.SetActive(false);
        }
        else
        {
            gm.buttonWest.gameObject.SetActive(true);
            west.east = this;
        }
    }
}
