using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper {

    [RuntimeInitializeOnLoadMethod]
    public static void Boot() {
        // load your first scene here
        // first unload the current scenes and then load the MainMenu
        var loader= SceneManager.LoadSceneAsync(0);

        if(loader != null) {
            loader.completed += operation => {
                var entryPoint = new EntryPoint();
                entryPoint.Initialize();
            };
        }
    }
}
