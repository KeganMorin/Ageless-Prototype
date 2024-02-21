using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(3, 5), Random.Range(-7, 12));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
