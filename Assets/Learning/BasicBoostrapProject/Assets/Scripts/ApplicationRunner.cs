using System;
using UnityEngine;

public class ApplicationRunner : MonoBehaviour {
    private EntryPoint entryPoint;

    public void InitializeRuner(EntryPoint entryPoint) {
        this.entryPoint = entryPoint;
    }

    private void Awake() {
        entryPoint?.Awake();
    }

    private void Start() {
        entryPoint?.Start();
    }

    private void Update() {
        entryPoint?.Update();
    }

    private void FixedUpdate() {
        entryPoint?.FixedUpdate();
    }

    private void OnDisable() {
        entryPoint?.OnDisable();
    }

    private void OnDestroy() {
        entryPoint?.OnDestroy();
    }

}
