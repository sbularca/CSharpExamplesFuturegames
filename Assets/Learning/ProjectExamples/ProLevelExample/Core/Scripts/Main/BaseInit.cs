using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Project {
    public class BaseInit {
        /// <summary>
        /// The is the first method called when the game starts. It will load the Initializer prefab which will initialize the project
        /// </summary>
        [RuntimeInitializeOnLoadMethod]
        private static void Initialize() {
#if UNITY_EDITOR
            if(BootMode.BootType == BootType.UnityDefault) {
                return;
            }
#endif
            var handler = Addressables.InstantiateAsync("Initializer");
        }
    }
}
