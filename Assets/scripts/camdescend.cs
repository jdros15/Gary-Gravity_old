using UnityEngine;
using System.Collections;

public class camdescend : MonoBehaviour
{

    public int MoveSpeed = 0;
    void Update()
    {
        transform.Translate((Vector3.down * (Time.deltaTime * MoveSpeed)), Space.World);
    }

}
