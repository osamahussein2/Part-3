using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject building1;
    public GameObject building2;
    public GameObject building3;

    public Transform buildingTransform1;
    public Transform buildingTransform2;
    public Transform buildingTransform3;

    Vector2 two;
    float timer = 0.0f;

    //public AnimationCurve scaleCurve;

    // Start is called before the first frame update
    void Start()
    {
        two = new Vector2(2.0f, 2.0f);

        StartCoroutine(MakeTheBuilding());
    }

    IEnumerator MakeTheBuilding()
    {
        //float interpolation = scaleCurve.Evaluate(timer);

        // Initialize these 3 buildings to start at a scale of (1, 1)
        building1.transform.localScale = Vector2.one;
        building2.transform.localScale = Vector2.one;
        building3.transform.localScale = Vector2.one;

        // I found that 0.035f is the best time to stop at once the 3 buildings reach the maximum scale during the lerp
        while (timer <= 0.035f)
        {
            timer += Time.deltaTime;

            yield return new WaitForSeconds(1);

            // Buildings take a long time to build so I tried to make it as realistic as possible
            Instantiate(building1, buildingTransform1.position, Quaternion.identity);

            yield return new WaitForSeconds(2);

            building1.transform.localScale = Vector2.Lerp(Vector2.one, two, timer * 30.0f);

            yield return new WaitForSeconds(1);

            Instantiate(building2, (Vector2)buildingTransform2.position + new Vector2(0.0f, 0.4f),
                Quaternion.identity);

            yield return new WaitForSeconds(2);

            building2.transform.localScale = Vector2.Lerp(Vector2.one, two, timer * 30.0f);

            yield return new WaitForSeconds(1);

            Instantiate(building3, (Vector2)buildingTransform3.position + new Vector2(0.1f, 0.7f),
                Quaternion.identity);

            yield return new WaitForSeconds(2);

            building3.transform.localScale = Vector2.Lerp(Vector2.one, two, timer * 30.0f);
        }
    }
}
