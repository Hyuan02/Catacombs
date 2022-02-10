using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;


    [SerializeField]
    private float angleToOpen = -60, angleToOpen2 = 240;

    private float _metaAngle = 0, _metaAngle2 = 180;

    private Quaternion defaultRotation1, defaultRotation2;

    private Quaternion currentRotation1, currentRotation2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _metaAngle = angleToOpen;
            _metaAngle2 = angleToOpen2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _metaAngle = 0;
            _metaAngle2 = 180;
        }
    }



    private void Update()
    {
        RotateDoors();
    }


    private void RotateDoors()
    {
        currentRotation1 = transform.GetChild(1).localRotation;
        if (Mathf.Abs(currentRotation1.eulerAngles.y - _metaAngle) > 0.01)
        {
            transform.GetChild(1).localRotation = Quaternion.Euler(-90, Mathf.LerpAngle(currentRotation1.eulerAngles.y, _metaAngle, Time.deltaTime * 2), 0);

        }
        currentRotation2 = transform.GetChild(2).localRotation;
        if (Mathf.Abs(currentRotation2.eulerAngles.y - _metaAngle) > 0.01)
        {
            transform.GetChild(2).localRotation = Quaternion.Euler(-90, Mathf.LerpAngle(currentRotation2.eulerAngles.y, _metaAngle2, Time.deltaTime * 2), 0);

        }
        //transform.GetChild(2).localRotation = Quaternion.Lerp(transform.GetChild(2).localRotation, Quaternion.EulerAngles(-90, _metaAngle, defaultRotation1.eulerAngles.z), Time.deltaTime);
    }
}
