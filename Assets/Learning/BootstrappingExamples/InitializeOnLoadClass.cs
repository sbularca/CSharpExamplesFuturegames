using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeOnLoadClass : MonoBehaviour {
    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    public static void Init() {
        Debug.Log("InitializeOnLoadClass static constructor called");
        for(int i = 0; i < SceneManager.sceneCount; i++) {
            Scene scene = SceneManager.GetSceneAt(i);
            if(scene.isLoaded) {
                SceneManager.UnloadSceneAsync(scene.name).completed += operation => {
                    Debug.Log($"Scene '{scene.name}' unloaded");
                };
            }
        }
        SceneManager.LoadSceneAsync("Init").completed += operation => {
            SceneManager.LoadSceneAsync("Start", LoadSceneMode.Additive).completed += operation2 => {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Start"));
                SimpleStartExampleTwo startExample = FindFirstObjectByType<SimpleStartExampleTwo>(FindObjectsInactive.Include);
                startExample?.gameObject.SetActive(true);
            };
        };
    }
}
