using System;
using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace customDamageType
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "customDamageType";
        public override string Author { get; } = "moddedmcplayer";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 2, 0);

        public EventHandlers EventHandler;

        public static Dictionary<ItemType, DamageType> damageTypes = new Dictionary<ItemType, DamageType>()
        {
            {ItemType.GunCrossvec, DamageType.Crossvec},
            {ItemType.GunLogicer, DamageType.Logicer},
            {ItemType.GunRevolver, DamageType.Revolver},
            {ItemType.GunShotgun, DamageType.Shotgun},
            {ItemType.GunAK, DamageType.AK},
            {ItemType.GunCOM15, DamageType.Com15},
            {ItemType.GunCOM18, DamageType.Com18},
            {ItemType.GunE11SR, DamageType.E11Sr},
            {ItemType.GunFSP9, DamageType.Fsp9},
        };

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