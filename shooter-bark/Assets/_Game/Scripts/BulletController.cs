using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector3 dest => dest_;
    

    public Vector3 dest_;
    private IEnumerator Start()
    {
        Vector3 startpos = transform.position;
        yield return new WaitForSeconds(0.5f);
        Vector3 distance = transform.position - dest;
        for (int i = 0; i < 74747; i++)
        {
            distance = transform.position - dest;
            if(distance.y != 0)
            {
                transform.position -= new Vector3(0, distance.y, 0);
                distance.y = 0;
            }

            if (distance.x != 0)
            {
                if (Mathf.Abs(distance.x) > 0.5f)
                {
                    transform.position -= new Vector3(2f, 0, 0);
                    distance.x -= 0.5f;
                }
                else
                {
                    transform.position -= new Vector3(distance.x, 0, 0);
                    distance.x = 0;

                }
            }
            if (distance.z != 0)
            {
                if (Mathf.Abs(distance.z) > 2f)
                {
                    transform.position += new Vector3(0, 0, 0.5f);
                    distance.z += 0.5f;
                }
                else
                {
                    transform.position -= new Vector3(0, 0, distance.z);
                    distance.z = 0f;
                }
            }
            
            if (transform.position == dest) break;
            yield return new WaitForSeconds(0.7f);
        }
        gameObject.SetActive(false);
    }
}
