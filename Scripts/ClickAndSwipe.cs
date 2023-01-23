using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class ClickAndSwipe : MonoBehaviour
{

    private GameManager _gameManager;
    private Camera _cam;
    private Vector3 _mousePos;
    private TrailRenderer _trail;
    private BoxCollider _col;
    private bool _swiping = false;

    // Start is called before the first frame update
    private void Awake()
    {
        _cam = Camera.main;
        _trail = GetComponent<TrailRenderer>();
        _col = GetComponent<BoxCollider>();
        _trail.enabled = false;
        _col.enabled = false;

        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if(_gameManager.isGameActive)
        {
            if(Input.GetMouseButtonDown(0))
            {
                _swiping = true;
                UpdateCompents();
            }
            else if (Input.GetMouseButtonDown(0))
            {
                _swiping = false;
                UpdateCompents();
            }
            if(_swiping)
            {
                UpdateMousePostion();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Targets>())
        {
            //Destroy the targets
            collision.gameObject.GetComponent<Targets>().DestroyTarget();
        }
    }
    void UpdateMousePostion()
    {
        _mousePos = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = _mousePos;
    }
    void UpdateCompents()
    {
        _trail.enabled = _swiping;
        _col.enabled = _swiping;
    }
}
