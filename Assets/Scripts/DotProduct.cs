using UnityEngine;

public class DotProduct : MonoBehaviour
{
    public float redAngleInDegrees = 60f;
    public float blueAngleInDegrees = 30f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 redVector = VectorFromAngle(redAngleInDegrees);
        Vector2 blueVector = VectorFromAngle(blueAngleInDegrees);

        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.blue);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float dot = dotProduct(redVector, blueVector);

            if (Mathf.Abs(dot) < 0.001) dot = 0;

            Debug.Log($"<color=yellow><size=16>{dot}</size></color>");
        }
    }

    public float dotProduct(Vector3 a, Vector3 b)
    {
        return a.x * b.x + a.y * b.y;
    }


    private Vector2 VectorFromAngle(float angle)
    {
        float angleInRad = Mathf.Deg2Rad * angle;
        return new Vector2(Mathf.Cos(angleInRad), Mathf.Sin(angleInRad));
    }
}
