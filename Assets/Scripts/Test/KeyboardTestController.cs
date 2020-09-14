using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardTestController : MonoBehaviour
{
    [SerializeField] private Movement m_movable = null;

    // Update is called once per frame
    void Update()
    {
        if (m_movable == null) return;

        Vector3 finalDir = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            finalDir.x += -1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            finalDir.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            finalDir.z += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            finalDir.x += 1;
        }

        m_movable.Move(finalDir);
    }
}
