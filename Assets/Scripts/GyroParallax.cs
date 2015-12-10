using UnityEngine;
using System.Collections;

public class GyroParallax : MonoBehaviour
{
    float speed;

    // Use this for initialization
    void Start()
    {
        speed = PlayerPrefs.GetFloat("bgsymbols.parallaxspeed", 1f);

        //todo: move blur props to separate scirpt?

        var blur = GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>();

        blur.blurIterations = (int)PlayerPrefs.GetFloat("bgsymbols.blur.iterations", 1f);
        blur.blurSize = PlayerPrefs.GetFloat("bgsymbols.blur.size", 1f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Input.gyro.enabled = true;
        if (Input.gyro.enabled)
        {
            float initialOrientationX = Input.gyro.rotationRateUnbiased.x;
            float initialOrientationY = Input.gyro.rotationRateUnbiased.y;

            Vector3 acceleration = new Vector3(-initialOrientationY, initialOrientationX);

            transform.Translate(acceleration * speed);
        }


    }
}
