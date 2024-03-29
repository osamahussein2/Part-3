using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class WithoutCoroutines : MonoBehaviour
{
    public GameObject missile;
    public float speed = 5;
    public float turningSpeedReduction = 0.75f;

    private void Update()
    {
    }

    public void turnHardLeft()
    {
        float interpolation = 0;
        Quaternion currentHeading = missile.transform.rotation;
        Quaternion newHeading = currentHeading * Quaternion.Euler(0, 0, -90);
        while (interpolation < 1)
        {
            interpolation += Time.deltaTime;
            missile.transform.rotation = Quaternion.Lerp(currentHeading, newHeading, interpolation);
            missile.transform.Translate(transform.right * (speed * turningSpeedReduction) * Time.deltaTime);
        }
    }

    public void turnLeft()
    {
        float interpolation = 0;
        Quaternion currentHeading = missile.transform.rotation;
        Quaternion newHeading = currentHeading * Quaternion.Euler(0, 0, -45);
        while (interpolation < 1)
        {
            interpolation += Time.deltaTime;
            missile.transform.rotation = Quaternion.Lerp(currentHeading, newHeading, interpolation);
            missile.transform.Translate(transform.right * (speed * turningSpeedReduction) * Time.deltaTime);
        }
    }

    public void goStraight()
    {
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime;
            missile.transform.Translate(transform.right * speed * Time.deltaTime);
        }
    }

    public void turnRight()
    {
        float interpolation = 0;
        Quaternion currentHeading = missile.transform.rotation;
        Quaternion newHeading = currentHeading * Quaternion.Euler(0, 0, 45);
        while (interpolation < 1)
        {
            interpolation += Time.deltaTime;
            missile.transform.rotation = Quaternion.Lerp(currentHeading, newHeading, interpolation);
            missile.transform.Translate(transform.right * (speed * turningSpeedReduction) * Time.deltaTime);
        }
    }

    public void turnHardRight()
    {
        float interpolation = 0;
        Quaternion currentHeading = missile.transform.rotation;
        Quaternion newHeading = currentHeading * Quaternion.Euler(0, 0, 90);
        while (interpolation < 1)
        {
            interpolation += Time.deltaTime;
            missile.transform.rotation = Quaternion.Lerp(currentHeading, newHeading, interpolation);
            missile.transform.Translate(transform.right * (speed * turningSpeedReduction) * Time.deltaTime);
        }
    }
}
