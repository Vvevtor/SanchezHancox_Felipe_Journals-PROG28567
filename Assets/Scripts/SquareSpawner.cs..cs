using UnityEngine;

public class SquareSpawner : MonoBehaviour //note, do not name it squarespawner.cs., just name it squarespawner, my friend
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetMouseButtonDown(0)) {

        Vector3 mousePos = Input.mousePosition; //might have made a mistake here, it won't let me use mousePos as the Vector3 in the Debug.Drawline

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //my friends in the lab reminded me of this whole camera.main.screentoworldpoint function, 

            Debug.DrawLine(mousePos(-5, 5, 0), )
    }
    }
}
