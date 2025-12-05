using System;
using Template;
using UnityEngine;

public class MainMenuViewInternal {

    public MainMenuViewInternal(int value) {

    }
}

namespace Project {
    /// <summary>
    /// Main menu interface class which is responsible for creating the main menu view and handling the main menu events
    /// </summary>
    public class MainMenuView : IApplicationLifecycle {
        private readonly MenuPrefabsContainer menuPrefabsContainer;
        private readonly MenuApplicationStateData menuApplicationStateData;
        private MainMenuReference mainMenuReference;
        public MainMenuView(MenuPrefabsContainer menuPrefabsContainer, MenuApplicationStateData menuApplicationStateData) {
            this.menuPrefabsContainer = menuPrefabsContainer;
            this.menuApplicationStateData = menuApplicationStateData;
        }
        public void Initialize() {

            var myClass = new MainMenuViewInternal(3);

            mainMenuReference = new GameObject().AddComponent<MainMenuReference>();

            // if(mainMenuReference == null) {
            //     mainMenuReference = GameObject.Instantiate(menuPrefabsContainer.mainMenuReference);
            // }
            // mainMenuReference.exitButton.onClick.AddListener(Application.Quit);
            // mainMenuReference.optionsButton.onClick.AddListener(() => throw new NotImplementedException());
            // mainMenuReference.playButton.onClick.AddListener(() => menuApplicationStateData.startGameRequests.Invoke(GameMode.Tileset));

        }
        public void Tick() { }
        public void Dispose() {
        }
    }
}
