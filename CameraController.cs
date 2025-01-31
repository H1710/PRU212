using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Transform target;
    public float smoothing;
    /*public Vector2 minPos;
    public Vector2 maxPos;*/

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        /*transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);*/

        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            /* targetPosition.x = Mathf.Clamp(targetPosition.x, minPos.x, maxPos.x);

             targetPosition.y = Mathf.Clamp(targetPosition.y, minPos.y, maxPos.y);*/

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
