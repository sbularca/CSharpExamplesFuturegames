using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

internal class TileGameEditorTests {
    PoolSystem poolSystem;
    private PoolSettings settings;

    [SetUp]
    public void Setup() {
        settings ??= ScriptableObject.CreateInstance<PoolSettings>();
        settings.minAmountEach = 10;
        poolSystem ??= new PoolSystem(settings);
        for (int i = 0; i < settings.minAmountEach; i++) {
            TileReference tilePrefab = new GameObject().AddComponent<TileReference>();
            tilePrefab.typeID = $"test{i}";
            poolSystem.TilePrefabs.Add(tilePrefab);
            poolSystem.Initialize();
        }
    }

    [Test]
    public void CorrectAmountOfPrefabsInStartingPool() {
        Assert.AreEqual(poolSystem.TilePrefabs.Count, settings.minAmountEach);
    }

    [Test]
    public void PrefabsHaveCorrectTypeId() {
        for(int i = 0; i < settings.minAmountEach; i++) {
            Assert.AreEqual(poolSystem.TilePrefabs[i].typeID, $"test{i}");
        }
    }

    [TearDown]
    public void TearDown() {
        poolSystem.Dispose();
    }
}
