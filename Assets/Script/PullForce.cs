using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullForce : MonoBehaviour
{
    public Camera cam;
    public bool pullForce;
    public float pullStrength, pushStrength;
    public float pullRange = 25, pullRadius = 1;

    public Collider targetObject;

    public Transform holdPosition;

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            pullForce = true;
            GetPullObject();
        }

        if (Input.GetMouseButton(1)) 
        {
            if(pullForce)
                Pullforce();
        }

        if (Input.GetMouseButtonUp(1))
        {
            pullForce = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (pullForce)
            {
                ThrowForce();
                pullForce = false;
            }

            else
            {
                //push
            }
        }
    }

    public void ThrowForce()
    {
        if (targetObject != null)
        {
            Rigidbody targetRigidbody = targetObject.GetComponent<Rigidbody>();
            if (targetRigidbody != null)
                targetRigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * pushStrength, ForceMode.Impulse);
        }

    }

    public void Pullforce() 
    {
        if (targetObject != null)
        {
        Rigidbody targetRigidbody = targetObject.GetComponent<Rigidbody>();
            if (targetRigidbody != null)
            {
                targetRigidbody.velocity = (holdPosition.position - targetObject.transform.position) * pullStrength * Time.deltaTime;
                targetObject.gameObject.tag = "Deadly";
            }
        }
    }

    public void GetPullObject()
    {
        targetObject = null;
        RaycastHit hit;
        
        if(Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, pullRange))
        {
            targetObject = hit.collider;
        }


    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullForce : MonoBehaviour
{
    public Camera cam;
    public bool pullForce;
    public float pullStrength, pushStrength;
    public float pullRange = 25, pullRadius = 1;

    public Collider[] targetObject;

    public Transform holdPosition;

    private void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            pullForce = true;
            GetPullObject();
        }

        if (Input.GetMouseButton(1))
        {
            if (pullForce)
                Pullforce();
        }

        if (Input.GetMouseButtonUp(1))
        {
            pullForce = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (pullForce)
            {
                ThrowForce();
                pullForce = false;
            }

            else
            {
                //push
            }
        }
    }

    public void ThrowForce()
    {
        if (targetObject != null && targetObject.Length > 0)
        {
            foreach (Collider col in targetObject)
            {
                if (col.GetComponent<Rigidbody>())
                    col.GetComponent<Rigidbody>().AddForce(cam.transform.TransformDirection(Vector3.forward) * pushStrength, ForceMode.Impulse);
            }
        }

    }

    public void Pullforce()
    {
        if (targetObject != null && targetObject.Length > 0)
        {
            foreach (Collider col in targetObject)
            {
                if (col.GetComponent<Rigidbody>())
                    col.GetComponent<Rigidbody>().velocity = (holdPosition.position - col.transform.position) * pullStrength * Time.deltaTime;
            }
        }
    }

    public void GetPullObject()
    {
        targetObject = null;
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, pullRange))
        {
            targetObject = Physics.OverlapSphere(hit.point, pullRadius);
        }


    }
}
*/