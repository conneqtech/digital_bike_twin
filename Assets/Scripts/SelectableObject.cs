using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public GraphManager.GraphType graphType;
    public GameObject[] parents;
    public GraphManager graphManager;
    bool isHovering = false;

    private void OnMouseEnter()
    {
        SetObjectColour(Color.blue);
        isHovering = true;
    }

    private void OnMouseExit()
    {
        SetObjectColour(Color.white);
        isHovering = false;
    }

    private void OnMouseUp()
    {
        if (!isHovering)
        {
            return;
        }

        graphManager.OpenGraph(graphType);
    }

    
    void SetObjectColour(Color color)
    {
        List<Renderer> renderers = new List<Renderer>();
        foreach (GameObject obj in parents)
        {
            renderers.AddRange(obj.GetComponentsInChildren<Renderer>());
        }
        foreach (Renderer renderer in renderers)
        {
            renderer.material.color = color;
        }
    }
}
