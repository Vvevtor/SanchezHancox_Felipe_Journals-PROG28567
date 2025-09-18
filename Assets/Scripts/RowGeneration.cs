using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


public class RowGeneration : MonoBehaviour
{

    public UnityEvent ButtonPress;// putting it outside the start stops the error

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //public UnityEvent ButtonPress; // caused error when placed inside start, searched up 
        //ButtonPress2 = int.Parse(ButtonPress); not the solution, need to change to bool not int.
        Application.targetFrameRate = 24;

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawLine(new Vector3(mousePos.x - 1, mousePos.y - 1, 0), new Vector3(mousePos.x - 1, mousePos.y + 1, 0), Color.white, 0f); 
        Debug.DrawLine(new Vector3(mousePos.x - 1, mousePos.y + 1, 0), new Vector3(mousePos.x + 1, mousePos.y + 1, 0), Color.white, 0f); 
        Debug.DrawLine(new Vector3(mousePos.x + 1, mousePos.y + 1, 0), new Vector3(mousePos.x + 1, mousePos.y - 1, 0), Color.white, 0f); 
        Debug.DrawLine(new Vector3(mousePos.x + 1, mousePos.y - 1, 0), new Vector3(mousePos.x - 1, mousePos.y - 1, 0), Color.white, 0f); // copied from first part off assignment
    }

    // Update is called once per frame
    void Update()
    {
        //if (ButtonPress){ failed experiment

        //}

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawLine(new Vector3(mousePos.x - 1, mousePos.y - 1, 0), new Vector3(mousePos.x - 1, mousePos.y + 1, 0), Color.red, 24f);
        Debug.DrawLine(new Vector3(mousePos.x - 1, mousePos.y + 1, 0), new Vector3(mousePos.x + 1, mousePos.y + 1, 0), Color.red, 24f);
        Debug.DrawLine(new Vector3(mousePos.x + 1, mousePos.y + 1, 0), new Vector3(mousePos.x + 1, mousePos.y - 1, 0), Color.red, 24f);
        Debug.DrawLine(new Vector3(mousePos.x + 1, mousePos.y - 1, 0), new Vector3(mousePos.x - 1, mousePos.y - 1, 0), Color.red, 24f);

    }
    //void (UnityEvent buttonPressed); failed experiment
    //{

    //}
 }
    

