using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trainingball 
{
    public class Trainingball : ScriptableObject
    {
        private GameObject _trainingBallObject;
        public Trainingball(string trainingBallTag, string name)
        {
            _trainingBallObject = GameObject.FindGameObjectWithTag(trainingBallTag);

            if (_trainingBallObject is null)
            {
                Debug.Log($"No trainingBall object found with the tag: {trainingBallTag}");
            }
            else 
            {
                _trainingBallObject.name = name;
            }
        }

        public void FollowCamera(Vector3 cameraPosition,Vector3 cameraForward, float distanceFromCamera)
        {
            Vector3 resultingPosition = cameraPosition + cameraForward * distanceFromCamera;
            _trainingBallObject.transform.position = resultingPosition;
        }

    }
}

