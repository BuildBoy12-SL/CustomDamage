// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomDamage
{
    using System.Linq;
    using Exiled.API.Enums;
    using Exiled.API.Extensions;
    using Exiled.API.Features.Items;
    using Exiled.Events.EventArgs;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnShot(ShotEventArgs)"/>
        public void OnShot(ShotEventArgs ev)
        {
            if (ev.Hitbox == null || ev.Shooter == null || ev.Target == null)
                return;

            if (ev.Shooter.CurrentItem is not Firearm firearm)
                return;

            if (!DamageTypeExtensions.ItemConversion.TryGetValue(firearm.Type, out DamageType value) ||
                !plugin.Config.DamageValues.TryGetValue(value, out DamageTypeConfig damageValue))
                return;

            float damage = GetDamage(damageValue, ev.Hitbox._dmgMultiplier, ev.Target.Items.FirstOrDefault(item => item.Type.IsArmor()));
            if (damage > 0)
            {
                ev.CanHurt = false;
                ev.Target.Hurt(ev.Shooter, damage, value);
            }
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnReloadedConfigs()"/>
        public void OnReloadedConfigs() => plugin.Config.Reload();

        private static float GetDamage(DamageTypeConfig damageTypeConfig, HitboxType hitboxType, Item armor)
        {
            if (armor is null)
                return damageTypeConfig.UnArmoured.GetValue(hitboxType);

            return damageTypeConfig.GetValue(armor.Type, hitboxType);
        }
    }
}