using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameHandler : MonoBehaviour
{
   
    public CameraFollow cameraFollow;
    public Transform playerTransform;
    public Transform character1Transform;
    public Transform character2Transform;
    public Transform ManualMovimentTransform;

    // Start is called before the first frame update
    void Start()
    {
        //cameraFollow.Setup(() => playerTransform.position);
    }

    public void selectCameraChar(int _camera){
        //if (_camera == 1){
        //    cameraFollow.SetGetCameraFollowPositionFunc(() => playerTransform.position);
        //}
        //else if (_camera == 2){
        //    cameraFollow.SetGetCameraFollowPositionFunc(() => character1Transform.position);
        //}
        //else if (_camera == 3){
        //    cameraFollow.SetGetCameraFollowPositionFunc(() => character2Transform.position);
        //}
        //else if (_camera == 4) {
        //    cameraFollow.SetGetCameraFollowPositionFunc(() => ManualMovimentTransform.position);
        //}
    }

}
