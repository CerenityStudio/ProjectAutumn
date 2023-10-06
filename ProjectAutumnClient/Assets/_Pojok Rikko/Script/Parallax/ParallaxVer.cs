using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxVer : MonoBehaviour
{

    [SerializeField] private Transform targetToFollow;

    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        Vector3 targetPosition = targetToFollow.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }


}
