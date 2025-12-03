using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PoolSystem {
    private readonly PoolSettings poolSettings;
    public PoolSystem(PoolSettings poolSettings) {
        this.poolSettings = poolSettings;

    }
    private readonly List<TileReference> pool = new List<TileReference>();
    private readonly List<string> tileTypeId = new List<string>();

    public TileSetGameData TileSetGameData { private get; set; }
    public List<TileReference> TilePrefabs { get; private set; } = new List<TileReference>();

    public void Initialize() {
        if(TileSetGameData == null) {
            return;
        }
        TilePrefabs = TileSetGameData.GameTiles;
        InitializePool();
    }

    public TileReference GetPoolItem(string typeID, Transform parent, float scale, bool asActive = true) {
        var tile = GetPoolTile(typeID);
        tile.transform.SetParent(parent);
        tile.transform.localScale *= scale;
        tile.gameObject.SetActive(asActive);
        return tile;
    }

    /// <summary>
    /// Returns the tile to the pool
    /// </summary>
    /// <param name="tileObj"></param>
    public void ReturnItem(GameObject tileObj) {
        tileObj.SetActive(false);
        tileObj.transform.localPosition = Vector3.zero;
        tileObj.transform.localScale = GetScale(tileObj.GetComponent<TileReference>());

        var tile = tileObj.GetComponent<TileReference>();
        if(tile != null) {
            tile.GridCell = new Cell(0, 0);
            tile.IsMoving = false;
        }
    }

    public void InitializePool() {
        for(int i = 0; i < TilePrefabs.Count; i++) {
            for(int j = 0; j < poolSettings.minAmountEach; j++) {
                AddObjectToPool(TilePrefabs[i]);
            }
        }
    }

    private TileReference GetPoolTile(string typeID) {
        TileReference tile = null;
        for(int i = 0; i < tileTypeId.Count; i++) {
            if(typeID == tileTypeId[i]) {
                if(!pool[i].gameObject.activeSelf) {
                    return pool[i];
                }
                tile = pool[i];
            }
        }
        return AddObjectToPool(tile);
    }

    private TileReference AddObjectToPool(TileReference tileObject) {
        var tile = GameObject.Instantiate(tileObject);
        tile.gameObject.SetActive(false);
        if(tile != null) {
            tile.transform.localScale = GetScale(tile);
            pool.Add(tile);
            tileTypeId.Add(tile.typeID);
        }
        return tile;
    }

    private Vector3 GetScale(TileReference tileReference) {
        for(int i = 0; i < TileSetGameData.GameTiles.Count; i++) {
            if(tileReference.typeID == TileSetGameData.GameTiles[i].typeID) {
                return TileSetGameData.GameTiles[i].transform.localScale;
            }
        }
        return Vector3.one;
    }

    public void Dispose() {
        for(int i = 0; i < pool.Count; i++) {
            Object.Destroy(pool[i]);
        }
        pool.Clear();
    }
}
