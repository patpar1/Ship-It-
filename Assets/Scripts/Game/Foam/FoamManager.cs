using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoamManager : MonoBehaviour
{
    public GameObject foamObject;
    public float spawnRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FoamGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FoamGenerator()
    {
        Ray ray;
        RaycastHit hit;
        ray = new Ray(Camera.main.transform.position, transform.position - Camera.main.transform.position);
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Water")))
        {
            if (hit.collider.tag == "Water")
            {
                Instantiate(foamObject, hit.point, this.transform.rotation * Quaternion.AngleAxis(90.0f, Vector3.up));
            }
        }

        yield return new WaitForSeconds(spawnRate);
        yield return StartCoroutine("FoamGenerator");
    }
}
