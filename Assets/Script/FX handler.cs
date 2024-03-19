using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXhandler : MonoBehaviour
{
    [SerializeField]
    public GameObject Throweffect;
    public GameObject Auraeffect;


    void Update()
    {

        ThrowEffectfunc();
        HoldEffectfunc();

    }


    private void ThrowEffectfunc()
    {
        if (Input.GetMouseButton(0))
        {
            Throweffect.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Throweffect.SetActive(false);
        }
    }

    private void HoldEffectfunc()
    {
        if (Input.GetMouseButton(1))
        {
            Auraeffect.SetActive(true);
        }

        if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonDown (0))
        {
            Auraeffect.SetActive(false);
        }
    }
}
