using UnityEngine;
using System.Collections;

public class GyroParallax : MonoBehaviour
{



    public float speed = 1f;
    Vector3 acceleration;

    Vector3 basicPosition;

    // Use this for initialization
    void Start()
    {

        basicPosition = transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (Input.gyro.enabled)
        {


            //Input.gyro.a
            float initialOrientationX = Input.gyro.rotationRateUnbiased.x;
            float initialOrientationY = Input.gyro.rotationRateUnbiased.y;
            transform.Translate(initialOrientationY * speed, 0.0f, -initialOrientationX * speed);

            //todo: refac
            //transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);

        }
        else
        {

            acceleration = new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));


            //todo: refac
            //acceleration = Vector3.Lerp(acceleration, Camera.main.ScreenToViewportPoint(Input.mousePosition) - new Vector3(0.5f, 0.5f), Time.deltaTime * speed);
        }


        transform.Translate(acceleration);

        Debug.Log(acceleration);
    }
}
