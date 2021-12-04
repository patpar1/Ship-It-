using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoamController : MonoBehaviour
{
    public float speed = 1.0f;
    public float destroyTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestroyObjectAfterFoam");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaPos = new Vector3(0, -speed * Time.deltaTime, 0);
        transform.position = transform.position - deltaPos;
    }

    private IEnumerator DestroyObjectAfterFoam()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
