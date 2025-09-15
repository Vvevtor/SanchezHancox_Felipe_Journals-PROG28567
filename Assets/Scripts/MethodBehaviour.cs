using UnityEngine;

public class MethodBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(outVector(new Vector2(3, 4)));
        Debug.Log(outVector(new Vector2(-3, 2)));
        //Debug.Log(outVector(new Vector2(1.5, -3.5)));

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        DrawBoxAtPosition(mousePosition, Vector2.one, new Color(1f, 1f, 1f, 0.5f));

       // Vector2 inVector = Vector2.(3, 4); // put it into the start since you just need to print it in debug ONCE

       // outVector(inVector);
    }

    private void DrawBoxAtPosition(Vector2 position, Vector2 size, Color color)
    {
        float halfWidth = size.x / 2f;
        float halfHeight = size.y / 2f;

        Vector2 topLeft = position + new Vector2(-halfWidth, halfHeight);
        Vector2 topRight = topLeft + new Vector2(size.x, 0);
        Vector2 bottomRight = topRight + new Vector2(0, -size.y);
        Vector2 bottomLeft = bottomRight + new Vector2(-size.x, 0);

        Debug.DrawLine(topLeft, topRight, color, 2f);
        Debug.DrawLine(topRight, bottomRight, color, 2f);
        Debug.DrawLine(bottomRight, bottomLeft, color, 2f);
        Debug.DrawLine(bottomLeft, topLeft, color, 2f);

    }

    private Vector2 outVector(Vector3 inVector) //I forgot how to divide in c#
    {
        Vector3 answer;
        float magnitude = inVector.magnitude;


        answer = new Vector2(inVector.x / magnitude, inVector.y / magnitude);
        return answer;
    }
}
