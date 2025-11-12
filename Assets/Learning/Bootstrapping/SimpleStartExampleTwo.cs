using System;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class SimpleStartExampleTwo : MonoBehaviour, IService {
    [SerializeField] MonoServiceTwo monoServiceTwoPrefab;
    private MonoServiceOne monoServiceOne;
    private MonoServiceTwo monoServiceTwo;

    private bool initialized;
    // add more services to initialize here
    public void Awake() {
        GameObject simpleStartGameObject = new ("SimpleStartExampleTwoHolder");
        simpleStartGameObject.transform.SetParent(transform.parent);
        monoServiceOne = simpleStartGameObject.AddComponent<MonoServiceOne>();
        monoServiceTwo = Instantiate(monoServiceTwoPrefab, simpleStartGameObject.transform); // it automatically implies creates the object and adds the component

        ServiceLocator.Instance.RegisterService(this);
        DontDestroyOnLoad(gameObject);
    }

    public void Initialize() {
        ServiceLocator.Instance.RegisterService(monoServiceOne);
        ServiceLocator.Instance.RegisterService(monoServiceTwo);
    }
    public void Dispose() {
        ServiceLocator.Instance.RemoveService<MonoServiceOne>();
        ServiceLocator.Instance.RemoveService<MonoServiceTwo>();
    }
}
