using System.Collections.Generic;
using UnityEngine;

public class UIMenuHandler {
    private readonly UIMenuView uiMenuViewPrefab;
    private UIMenuView uiMenuView;
    private readonly List<ButtonReference> menuButtonList = new ();
    public UIMenuHandler(UIMenuView uiMenuViewPrefab) {
        this.uiMenuViewPrefab = uiMenuViewPrefab;
    }

    public void InitializeMenu() {
        uiMenuView = GameObject.Instantiate(uiMenuViewPrefab);
        SetupButtons();
    }

    public void Tick() {
        //not doing much, just an example
    }

    private void SetupButtons() {
        for(int i = 0; i < 3; i++) {
            ButtonReference button = GameObject.Instantiate(uiMenuView.buttonReferencePrefab, uiMenuView.menuParent);
            menuButtonList.Add(button);
        }

        menuButtonList[0].label.text = "Start";
        menuButtonList[0].button.onClick.AddListener(LoadLevel);

        menuButtonList[1].label.text = "Options";
        menuButtonList[2].label.text = "Exit";
    }
    private void LoadLevel() {
        // This method will load the first game level
    }
    public void OnDispose() {
        if(uiMenuView != null) {
            GameObject.Destroy(uiMenuView.gameObject);
        }
    }
}
