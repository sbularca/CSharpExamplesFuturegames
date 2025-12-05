using UnityEngine;
using UnityEngine.AddressableAssets;

public class EntryPoint {

    private PrefabRegistry prefabRegistry;

    public void Initialize() {
        LoadAssets();
        var uiMenuHandler = new UIMenuHandler(prefabRegistry.uiMenuViewPrefab);
        uiMenuHandler.InitializeMenu();

        // Initialize different services like input etc.
        //Instantiate the main menu
        // Handle the application runtime cycle
        // etc.
    }

    private void LoadAssets() {
        prefabRegistry = Addressables.LoadAssetAsync<PrefabRegistry>("PrefabRegistry").WaitForCompletion();
    }
}
