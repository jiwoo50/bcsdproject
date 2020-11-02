using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        rubycontroller controller = other.GetComponent<rubycontroller>();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }
}
