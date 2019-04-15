using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateObject : MonoBehaviour
{

    [SerializeField] GameObject myObject = null;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(myObject, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
