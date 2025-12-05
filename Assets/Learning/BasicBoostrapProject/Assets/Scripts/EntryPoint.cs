using UnityEngine;
using UnityEngine.AddressableAssets;

public class EntryPoint {

    private PrefabRegistry prefabRegistry;
    private UIMenuHandler uiMenuHandler;

    public void Initialize() {
        LoadAssets(); // loading the settings to make the accessible for following steps
        InitializeApplicationRunner(); // we still need one instance of a Monobehaviour to run our game cycles

        // Initialize other systems here like the UI

        uiMenuHandler = new UIMenuHandler(prefabRegistry.uiMenuViewPrefab);
        uiMenuHandler.InitializeMenu();
    }

    public void Awake() { }

    public void Start() { }

    private void InitializeApplicationRunner() {
        var applicationRunner = new GameObject().AddComponent<ApplicationRunner>();
        applicationRunner.InitializeRuner(this);
    }

    private void LoadAssets() {
        prefabRegistry = Addressables.LoadAssetAsync<PrefabRegistry>("PrefabRegistry").WaitForCompletion();
    }

    public void Update() {
        Debug.Log("Me be ticking now");
        uiMenuHandler.Tick();
    }

    public void FixedUpdate() { }
    public void OnDisable() { }
    public void OnDestroy() {
        uiMenuHandler.OnDispose();
    }
}
