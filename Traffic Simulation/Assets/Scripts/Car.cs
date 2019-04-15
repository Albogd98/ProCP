using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Car : MonoBehaviour
{
    [SerializeField] private Transform[] routes;
    private int _routeToGo;
    private float _tParam;
    private Vector3 _carPosition;
    
    private bool _coroutineAllowed;

    private float _speedModifier;
    private float _speed = 10;
    private float _acceleration = 1;
    private float _counter = 0;
    private bool _collided;


    public void Accelerate()
    {
        if (_speed < 5)
        {
            _speed += _acceleration;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _speedModifier = 0.5f;
        _routeToGo = 0;
        _tParam = 0f;
        _coroutineAllowed = true;
        _collided = false;

    }

    // Update is called once per frame
    void Update()
    {
        /*_counter += Time.deltaTime;
        if (_counter >= 5)
        {
            Invoke();
            _counter = 0;
        }*/

        if (_collided)
        {
            _routeToGo = Random.Range(0,2);
            if (_coroutineAllowed)
            StartCoroutine(GoByTheRoute(_routeToGo));
        }
        else
        {
            moveForward();
        }
    }
    void moveForward()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.distance > 2f)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                transform.Translate(0, 0, _speed * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(0, 0, _speed * Time.deltaTime);
        }
    }

    void Invoke()
    {
        GameObject newCar = Instantiate(gameObject);
        newCar.transform.position = new Vector3(0,0,1.64f);
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        _coroutineAllowed = false;

        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;

        while (_tParam < 1)
        {
            _tParam += Time.deltaTime * _speedModifier;
            
            _carPosition = Mathf.Pow(1 - _tParam, 3) * p0 +
                           3 * Mathf.Pow(1 - _tParam, 2) * _tParam * p1 +
                           3 * (1 - _tParam) * Mathf.Pow(_tParam, 2) * p2 +
                           Mathf.Pow(_tParam, 3) * p3;
            transform.position = _carPosition;
            transform.Rotate(0, 0.30f, 0);
            
            

            yield return new WaitForEndOfFrame();
        }

        _tParam = 0f;

        _routeToGo += 1;

        if (_routeToGo > routes.Length - 1)
            _routeToGo = 0;

        _coroutineAllowed = true;
        _collided = false;
    }

    void OnCollisionEnter(Collision col)
    {
        _speed = 1;
        _collided = true;
    }
    

}
