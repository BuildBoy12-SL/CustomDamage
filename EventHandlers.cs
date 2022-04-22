using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features.Items;
using Exiled.Events;
using Exiled.Events.EventArgs;

namespace customDamageType
{
    public class EventHandlers
    {
        private Config cfg;
        public DamageType[] gunDamageTypes = new[] {DamageType.Com15, DamageType.Com18, DamageType.Crossvec, DamageType.Fsp9, DamageType.Logicer, DamageType.Revolver, DamageType.Shotgun, DamageType.AK, DamageType.E11Sr, DamageType.MicroHid, DamageType.ParticleDisruptor};
        public Dictionary<ItemType, DamageType> ItemDamageTypeMapping = new Dictionary<ItemType, DamageType>()
        {
            {ItemType.GunCrossvec, DamageType.Crossvec},
            {ItemType.GunLogicer, DamageType.Crossvec},
            {ItemType.GunRevolver, DamageType.Crossvec},
            {ItemType.GunShotgun, DamageType.Crossvec},
            {ItemType.GunAK, DamageType.Crossvec},
            {ItemType.GunCOM15, DamageType.Crossvec},
            {ItemType.GunCOM18, DamageType.Crossvec},
            {ItemType.GunE11SR, DamageType.Crossvec},
            {ItemType.GunFSP9, DamageType.Crossvec},
            {ItemType.MicroHID, DamageType.Crossvec},
            {ItemType.ParticleDisruptor, DamageType.Crossvec},
        };

        public EventHandlers(Plugin plugin)
        {
            cfg = plugin.Config;
        }

        public void OnShot(ShotEventArgs ev)
        {
            if (ev.Shooter.CurrentItem is Firearm firearm)
            {
                if (ItemDamageTypeMapping.TryGetValue(firearm.Type, out var value) && cfg.GunDamageValues.TryGetValue(value, out var damageValue))
                {
                    if (ev.Target.Items.Where(x => x.Type.IsArmor()).Count() == 0)
                    {
                        ev.Damage = damageValue.UnArmoured.getValue(ev.Hitbox._dmgMultiplier);
                    }else
                    {
                        ev.Damage = damageValue.getValue(ev.Target.Items.First(x => x.Type.IsArmor()).Type, ev.Hitbox._dmgMultiplier);
                    }
                }
            }
        }
        
        public void OnHurting(HurtingEventArgs ev)
        {
            if(gunDamageTypes.Contains(ev.Handler.Type))
                return;
            
        }
    }
}