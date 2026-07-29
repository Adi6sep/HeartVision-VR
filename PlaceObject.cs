using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class PlaceObject : MonoBehaviour
{
    public GameObject prefab;

    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (raycastManager.Raycast(touch.position, hits, TrackableType.Planes))
            {
                Pose pose = hits[0].pose;

                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(prefab, pose.position, pose.rotation);
                }
                else
                {
                    spawnedObject.transform.position = pose.position;
                }
            }
        }
    }
}