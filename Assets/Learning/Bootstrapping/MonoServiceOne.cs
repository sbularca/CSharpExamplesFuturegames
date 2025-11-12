using System;
using UnityEngine;

public class MonoServiceOne : MonoBehaviour, IService {

    public Transform cubeTransform;

    private void Start() {
        Debug.Log("MonoServiceOne started from Start()");
    }

    public void Initialize() {
        Debug.Log("MonoServiceOne started from Initialize()");
        if(cubeTransform) {
            return;
        }
        cubeTransform = FindAnyObjectByType<Cube>(FindObjectsInactive.Include).transform;
        cubeTransform?.gameObject.SetActive(true);
    }

    private void Update() {
        Debug.Log("MonoServiceOne is updating");
    }

    public void Dispose() {
    }
}
