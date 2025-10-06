using UnityEngine;
using UnityEngine.Rendering;

public class Turret : MonoBehaviour
{
    public Transform target;
    public float angularSpeedInDegrees = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 directionToTarget = (target.position - transform.position).normalized;
        float upAngle = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;
        float directionAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

        float deltaAngle = Mathf.DeltaAngle(upAngle, directionAngle);
        Debug.Log($"<color=yellow><size=16>{deltaAngle}</size></color>");

        float dot = Vector3.Dot(transform.up, directionToTarget);
        float sign = Mathf.Sign(deltaAngle);


        if (dot < 0.999f)
            transform.Rotate(0, 0, angularSpeedInDegrees * Time.deltaTime * sign);

        if (dot < 0) Debug.Log("behind!");
        else if (dot > 0) Debug.Log("in front");



            Debug.DrawLine(transform.position, transform.position + transform.up, Color.green);
        Debug.DrawLine(transform.position, transform.position + directionToTarget, Color.magenta);


    }
}
