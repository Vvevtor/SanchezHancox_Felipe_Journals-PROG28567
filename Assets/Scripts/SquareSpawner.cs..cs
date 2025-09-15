using UnityEngine;

public class SquareSpawner : MonoBehaviour //note, do not name it squarespawner.cs., just name it squarespawner, my friend
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 24;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) {

        //Vector3 mousePos = Input.mousePosition; //might have made a mistake here, it won't let me use mousePos as the Vector3 in the Debug.Drawline

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //my friends in the lab reminded me of this whole camera.main.screentoworldpoint function, 
            //note, realised partway through that I should call this every frame


            Debug.DrawLine(new Vector3(mousePos.x - 1, mousePos.y - 1, 0), new Vector3(mousePos.x - 1, mousePos.y + 1, 0), Color.white, 0f); //
            Debug.DrawLine(new Vector3(mousePos.x - 1, mousePos.y + 1, 0), new Vector3(mousePos.x + 1, mousePos.y + 1, 0), Color.white, 0f); //
            Debug.DrawLine(new Vector3(mousePos.x + 1, mousePos.y + 1, 0), new Vector3(mousePos.x + 1, mousePos.y - 1, 0), Color.white, 0f); //
            Debug.DrawLine(new Vector3(mousePos.x + 1, mousePos.y - 1, 0), new Vector3(mousePos.x - 1, mousePos.y - 1, 0), Color.white, 0f); // I've made a grave error
            //not reading the assignment closely enough, the squares are supposed to be permanent, I don't remember how to do this
            Debug.DrawLine(new Vector3(0,0,0), new Vector3(100,100,0), Color.red); //the above code didn't initally work, so I'm using this one as a tester to see what might've
            //gone wrong and experiment until I figure that out
        }
    }
}
