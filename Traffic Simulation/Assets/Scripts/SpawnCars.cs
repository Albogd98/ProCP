using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class SpawnCars : MonoBehaviour
{
    private float _timer = 2;
    public GameObject _car;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Instantiate(_car, new Vector3(2,0,2.31f), transform.rotation);
            _timer = 2;
        }
    }
}
