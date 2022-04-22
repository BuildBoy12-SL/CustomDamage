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
            if (ev.Hitbox == null || ev.Shooter == null)
                return;

            if (ev.Shooter.CurrentItem is Firearm firearm)
            {
                if (ItemDamageTypeMapping.TryGetValue(firearm.Type, out var value) && cfg.GunDamageValues.TryGetValue(value, out var damageValue))
                {
                    if (ev.Target.Items.Where(x => x.Type.IsArmor()).Count() == 0)
                    {
                        if(damageValue.UnArmoured.getValue(ev.Hitbox._dmgMultiplier) != -1f)
                        {
                            ev.Damage = 1;
                            if(damageValue.UnArmoured.getValue(ev.Hitbox._dmgMultiplier)-1 > 0)
                                ev.Target.Hurt(ev.Shooter, damageValue.UnArmoured.getValue(ev.Hitbox._dmgMultiplier)-1, value);
                        }
                    }else
                    {
                        if(damageValue.getValue(ev.Target.Items.First(x => x.Type.IsArmor()).Type, ev.Hitbox._dmgMultiplier) != -1f)
                        {
                            ev.Damage = 1;
                            if(damageValue.getValue(ev.Target.Items.First(x => x.Type.IsArmor()).Type, ev.Hitbox._dmgMultiplier) -1 > 0) 
                                ev.Target.Hurt(ev.Shooter, damageValue.getValue(ev.Target.Items.First(x => x.Type.IsArmor()).Type, ev.Hitbox._dmgMultiplier), value);
                        }
                    }
                }
            }
        }
        
        public void OnHurting(HurtingEventArgs ev)
        {
            if(gunDamageTypes.Contains(ev.Handler.Type))
                return;
            if(cfg.DamageValues.TryGetValue(ev.Handler.Type, out var amount) || amount != -1f)
                ev.Amount = amount;
        }
    }
}