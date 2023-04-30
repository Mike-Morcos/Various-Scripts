using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSize : MonoBehaviour
{
    private float randomScale;
    // Start is called before the first frame update
    void Start()
    {
        randomScale = Random.Range(.5f, 2f);
        transform.localScale = new Vector3(randomScale, randomScale, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
