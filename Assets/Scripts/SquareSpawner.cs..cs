using UnityEngine;

public class SquareSpawner : MonoBehaviour //note, do not name it squarespawner.cs., just name it squarespawner, my friend
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 24; //had to search this up, lowering framerate so I can see the lines I spawn since they're only there for 1 frame.
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawLine(new Vector3(mousePos.x - 1, mousePos.y - 1, 0), new Vector3(mousePos.x - 1, mousePos.y + 1, 0), Color.white, 0f); //
        Debug.DrawLine(new Vector3(mousePos.x - 1, mousePos.y + 1, 0), new Vector3(mousePos.x + 1, mousePos.y + 1, 0), Color.white, 0f); //
        Debug.DrawLine(new Vector3(mousePos.x + 1, mousePos.y + 1, 0), new Vector3(mousePos.x + 1, mousePos.y - 1, 0), Color.white, 0f); //
        Debug.DrawLine(new Vector3(mousePos.x + 1, mousePos.y - 1, 0), new Vector3(mousePos.x - 1, mousePos.y - 1, 0), Color.white, 0f); //after week
        //3's class I realize I can just call the above function every frame and have that work, so I'm doing that cy calling a method every frame to practice making them

        if (Input.GetMouseButtonDown(0)) {

        //Vector3 mousePos = Input.mousePosition; //might have made a mistake here, it won't let me use mousePos as the Vector3 in the Debug.Drawline

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //my friends in the lab reminded me of this whole camera.main.screentoworldpoint function, 
            //note, realised partway through that I should call this every frame


            Debug.DrawLine(new Vector3(mousePos.x - 2, mousePos.y - 2, 0), new Vector3(mousePos.x - 2, mousePos.y + 2, 0), Color.white, 0f); //
            Debug.DrawLine(new Vector3(mousePos.x - 2, mousePos.y + 2, 0), new Vector3(mousePos.x + 2, mousePos.y + 2, 0), Color.white, 0f); //
            Debug.DrawLine(new Vector3(mousePos.x + 2, mousePos.y + 2, 0), new Vector3(mousePos.x + 2, mousePos.y - 2, 0), Color.white, 0f); //
            Debug.DrawLine(new Vector3(mousePos.x + 2, mousePos.y - 2, 0), new Vector3(mousePos.x - 2, mousePos.y - 2, 0), Color.white, 0f); // I've made a grave error
            //not reading the assignment closely enough, the squares are supposed to be permanent, I don't remember how to do this

            //new note, maybe I was right all along actually and the square isn't supposed to be permanent? I think since this exercise is meant to test my
            //abilities it doesn't really matter, but if this were a proper assignment or piece of code I'm supposed to create, I would absolutely seek clarification asap.

            Debug.DrawLine(new Vector3(0,0,0), new Vector3(100,100,0), Color.red); //the above code didn't initally work, so I'm using this line as a tester to see what might've
            //gone wrong and experiment until I figure that out

            //the answer was that it was working, the lines were just initially positioned very far away and the framerate is higher than this screen can handle
            //so they just didn't show up most of the time.
        }

    


    }

}
