using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Car : MonoBehaviour
{
    private Transform _routeRight;
    private Transform _routeLeft;
    private float _tParam;
    private Vector3 _carPosition;
    
    private bool _coroutineAllowed;

    private float _speedModifier;
    private float _speed = 10;
    private float _acceleration = 1;
    private float _counter = 0;
    private string _collided = "";


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
        _tParam = 0f;
        _coroutineAllowed = true;
        _collided = "";

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

        if (_collided != "" && _collided != "Forward" && _coroutineAllowed)
        {
            switch(_collided)
            {
                case "Left": 
                    StartCoroutine(GoByTheRoute(_routeLeft, false));
                    break;
                case "Right": 
                    StartCoroutine(GoByTheRoute(_routeRight, true));
                    break;
            }
            
            if (_coroutineAllowed)
            {
                       
            }
            
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

    private IEnumerator GoByTheRoute(Transform route, bool turningRight)
    {
        _coroutineAllowed = false;

        Vector3 p0 = route.GetChild(0).position;
        Vector3 p1 = route.GetChild(1).position;
        Vector3 p2 = route.GetChild(2).position;
        Vector3 p3 = route.GetChild(3).position;

        float startingAngle = transform.localEulerAngles.y;
        startingAngle = (startingAngle > 180) ? startingAngle - 360 : startingAngle;

        while (_tParam < 1)
        {
            _tParam += Time.deltaTime * _speedModifier;
            
            _carPosition = Mathf.Pow(1 - _tParam, 3) * p0 +
                           3 * Mathf.Pow(1 - _tParam, 2) * _tParam * p1 +
                           3 * (1 - _tParam) * Mathf.Pow(_tParam, 2) * p2 +
                           Mathf.Pow(_tParam, 3) * p3;
            transform.position = _carPosition;

            float angle = transform.localEulerAngles.y;
            angle = (angle > 180) ? angle - 360 : angle;

            if(turningRight && angle - startingAngle <= 90f)
            {
                transform.Rotate(0, 1f, 0);
            } 
            else if(!turningRight && startingAngle - angle <= 90f)
            {
                transform.Rotate(0, -1f, 0);
            }

            yield return new WaitForEndOfFrame();
        }

        _tParam = 0f;

        /*_routeToGo += 1;

        if (_routeToGo > routes.Length - 1)
            _routeToGo = 0;

        */

        _coroutineAllowed = true;
        _collided = "";
    }

    void OnCollisionEnter(Collision col)
    {
        int randNumber = Random.Range(0, 3);
    
        _speed = 1;
        _collided = col.gameObject.name;
        _routeLeft = col.gameObject.GetComponent<TurnController>().leftRoute;
        _routeRight = col.gameObject.GetComponent<TurnController>().rightRoute;
        col.gameObject.name = randNumber == 0 ? "Left" : randNumber == 1 ? "Right" : "Forward";
    }
    

}
