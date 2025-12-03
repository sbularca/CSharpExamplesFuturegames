using System.Collections;
using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

public class TileGamePlayTests {
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.

    // [UnitySetUp]
    // public IEnumerator UnitySetUp() {
    //     AsyncOperation handler = SceneManager.LoadSceneAsync("Start", LoadSceneMode.Additive);
    //     if(handler != null) yield return new WaitUntil(() => handler.isDone);
    // }

    [UnityTest]
    public IEnumerator SceneFoundAndLoaded() {
        AsyncOperation handler = SceneManager.LoadSceneAsync("Init");
        Assert.IsNotNull(handler);
        while(!handler.isDone) {
            yield return null;
        }
        Assert.IsTrue(handler.isDone);
    }

    [UnityTest]
    public IEnumerator ThereIsOnlyOneSingletonOfTypeSimpleStartSuccess() {
        AsyncOperation handler = SceneManager.LoadSceneAsync("Start", LoadSceneMode.Additive);
        if(handler != null) yield return new WaitUntil(() => handler.isDone);
        SimpleStart[] objects = Object.FindObjectsByType<SimpleStart>(FindObjectsSortMode.None);
        Assert.AreEqual(1, objects.Length);
    }

    [UnityTest]
    public IEnumerator ThereIsOnlyOneSingletonOfTypeSimpleStartFail() {
        AsyncOperation handler = SceneManager.LoadSceneAsync("Start", LoadSceneMode.Additive);
        if(handler != null) yield return new WaitUntil(() => handler.isDone);
        Object.Instantiate(new GameObject().AddComponent<SimpleStart>());
        SimpleStart[] objects = Object.FindObjectsByType<SimpleStart>(FindObjectsSortMode.None);
        Assert.AreNotEqual(1, objects.Length);
    }

    // [UnityTearDown]
    // public IEnumerator UnityTearDown() {
    //     AsyncOperation handler = SceneManager.UnloadSceneAsync("Start");
    //     if(handler != null) yield return new WaitUntil(() => handler.isDone);
    // }
}
