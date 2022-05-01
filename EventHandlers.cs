using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs;
using InventorySystem.Items.Firearms.BasicMessages;
using PlayerStatsSystem;

namespace customDamageType
{
    public class EventHandlers
    {
        private Config cfg;
        public DamageType[] gunDamageTypes = new[] {DamageType.Com15, DamageType.Com18, DamageType.Crossvec, DamageType.Fsp9, DamageType.Logicer, DamageType.Revolver, DamageType.Shotgun, DamageType.AK, DamageType.E11Sr, DamageType.MicroHid, DamageType.ParticleDisruptor};
        public Dictionary<ItemType, DamageType> ItemDamageTypeMapping = new Dictionary<ItemType, DamageType>()
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
            {ItemType.MicroHID, DamageType.MicroHid},
            {ItemType.ParticleDisruptor, DamageType.ParticleDisruptor},
        };

        public EventHandlers(Plugin plugin)
        {
            cfg = plugin.Config;
        }

        public void OnShot(ShotEventArgs ev)
        {
            if (ev.Hitbox == null || ev.Shooter == null || ev.Target == null)
                return;
            if(!ev.CanHurt || (!Server.FriendlyFire && ev.Shooter.Role.Side == ev.Target.Role.Side))
                return;
            float damage = 0;
            if (ev.Shooter.CurrentItem is Firearm firearm)
            {
                if (ItemDamageTypeMapping.TryGetValue(firearm.Type, out var value) && cfg.GunDamageValues.TryGetValue(value, out var damageValue))
                {
                    if (!ev.Target.Items.Any(x => x.Type.IsArmor()))
                    {
                        if(damageValue.UnArmoured.getValue(ev.Hitbox._dmgMultiplier) != -1)
                        {
                            if (damageValue.UnArmoured.getValue(ev.Hitbox._dmgMultiplier) > 1);
                            {
                                ev.Damage = 0;
                                damage = damageValue.UnArmoured.getValue(ev.Hitbox._dmgMultiplier) - 1;
                            }
                        }
                    }else
                    {
                        if(damageValue.getValue(ev.Target.Items.First(x => x.Type.IsArmor()).Type, ev.Hitbox._dmgMultiplier) != -1)
                        {
                            if(damageValue.getValue(ev.Target.Items.First(x => x.Type.IsArmor()).Type, ev.Hitbox._dmgMultiplier) > 1)
                            {
                                ev.Damage = 0;
                                damage = damageValue.getValue(ev.Target.Items.First(x => x.Type.IsArmor()).Type, ev.Hitbox._dmgMultiplier) - 1;
                            }
                        }
                    }
                }
                if(damage != -1)
                {
                    if (ev.Target.Health - damage <= 0)
                        ev.Target.ReferenceHub.playerStats.KillPlayer(new FirearmDamageHandler(firearm.Base, damage, false));
                    else
                        ev.Target.Health -= damage;
                    Hitmarker.SendHitmarker(ev.Shooter.Connection, 1f);
                    foreach (ReferenceHub spectatingPlayer in ev.Shooter.ReferenceHub.spectatorManager.ServerCurrentSpectatingPlayers)
                        spectatingPlayer.networkIdentity.connectionToClient.Send(new GunHitMessage(false, damage, ev.Shooter.ReferenceHub.transform.eulerAngles));
                }
            }
        }
    }
}