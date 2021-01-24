using UnityEngine;

public class Seek : MonoBehaviour
{
    public GameObject target;

    public float speed;

    void Update()
    {
        SteeringOutput steeringOutput = getSteering();
        transform.position += steeringOutput.vel * Time.deltaTime;
    }

    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        result.vel = target.transform.position - this.transform.position;

        result.vel.Normalize();
        result.vel *= speed;

        float orientation = newOrientation(transform.eulerAngles.y, result.vel);
        this.transform.eulerAngles = new Vector3(0, orientation * (180 / Mathf.PI), 0);

        return result;
    }

    public float newOrientation(float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
        {
            return Mathf.Atan2(velocity.x, velocity.z);
        }
        else
        {
            return current;
        }
    }
}
