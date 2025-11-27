using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Events = EventsDefinition;

public class PlayerDataStuff {
    public string playerName;
    public int playerHealth;
    public bool playerIsDead;
}

public class ObserverExamples : MonoBehaviour {
    public static Action<PlayerDataStuff> OnUpdatePlayerHealthUI;

    List<PlayerDataStuff> players = new List<PlayerDataStuff>();

    private void OnEnable() {
        Signals.Get<Events.TakeDamageSignal>().AddListener(OnDamage); //subscribing to the event
        OnUpdatePlayerHealthUI += UpdatUI;

    }
    private void UpdatUI(PlayerDataStuff obj) {
        throw new NotImplementedException();
    }

    public void DamagePlayer(string name, int health) {
        PlayerDataStuff playerData = players.FirstOrDefault(x => x.playerName == name);
        if(playerData != null) {
            Signals.Get<Events.TakeDamageSignal>().Dispatch(playerData,  health);
        }

        // foreach(PlayerDataStuff pData in players) {
        //     if(pData.playerName == name) {
        //         Signals.Get<TakeDamageSignal>().Dispatch(pData);
        //     }
        // }
    }

    private void OnDamage(PlayerDataStuff obj, int damage) {
        //this will be triggered when the event TakeDamageSignal is dispatched(+1 frame)
        obj.playerHealth -= damage;
        OnUpdatePlayerHealthUI?.Invoke(obj);
        //Signals.Get<Events.UpdatePlayerHealthUI>().Dispatch(obj);
    }

    private void OnDestroy() {
        Signals.Get<Events.TakeDamageSignal>().RemoveListener(OnDamage);
        OnUpdatePlayerHealthUI -= UpdatUI;
    }
}

