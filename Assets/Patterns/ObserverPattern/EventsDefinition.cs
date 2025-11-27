public class EventsDefinition {
    public class TakeDamageSignal : ASignal<PlayerDataStuff, int> { }
    public class UpdatePlayerHealthUI : ASignal<PlayerDataStuff> { }
    public class UpdateUI : ASignal<int> { }
}
