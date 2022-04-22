using System;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace customDamageType
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "customDamageType";
        public override string Author { get; } = "moddedmcplayer";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 1, 0);

        public EventHandlers EventHandler;

        public override void OnEnabled()
        {
            EventHandler = new EventHandlers(this);
            Player.Shot += EventHandler.OnShot;
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.Shot -= EventHandler.OnShot;
            EventHandler = null;
            
            base.OnDisabled();
        }
    }
}