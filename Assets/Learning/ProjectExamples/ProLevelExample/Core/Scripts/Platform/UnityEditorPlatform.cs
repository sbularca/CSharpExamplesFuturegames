using System.Collections;
using UnityEngine.AddressableAssets;

namespace Template {
    public class UnityEditorPlatform: IPlatform {
        private readonly AssetReference assetReference;

        public UnityEditorPlatform(AssetReference assetReference) {
            this.assetReference = assetReference;
        }
        public IEnumerator Initialize(object applicationData) {
            throw new System.NotImplementedException();
        }
        public IApplicationLifecycle InputHandler() {
            throw new System.NotImplementedException();
        }
        public void Tick() {
            throw new System.NotImplementedException();
        }
        public void Dispose() {
            throw new System.NotImplementedException();
        }
        public void OnApplicationQuit() {
            throw new System.NotImplementedException();
        }
    }
}
