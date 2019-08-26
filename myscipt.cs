using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class myscipt : MonoBehaviour
{
    public Camera mycamera;
   // public GameObject Andy;
    public GameObject Andyplaneprefab;
    public GameObject Andypointprefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Touch mytouch;
        if(Input.touchCount<1 || (mytouch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon | TrackableHitFlags.FeaturePointWithSurfaceNormal;
            if (Frame.Raycast(mytouch.position.x, mytouch.position.y, raycastFilter, out hit)) 
        {
            GameObject prefab;
            if(hit.Trackable is FeaturePoint)
            {
                prefab = Andypointprefab;
            }
            else
            {
                prefab = Andyplaneprefab;
            }
            var andyobject = Instantiate(prefab, hit.Pose.position, hit.Pose.rotation);
            andyobject.transform.Rotate(0, 180.0f, 0, Space.Self);

            var anchor = hit.Trackable.CreateAnchor(hit.Pose);
            andyobject.transform.parent = anchor.transform;

        }
    }
}
