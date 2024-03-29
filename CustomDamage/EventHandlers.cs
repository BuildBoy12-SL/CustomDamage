﻿// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomDamage
{
    using CustomDamage.Configs;
    using Exiled.API.Enums;
    using Exiled.API.Extensions;
    using Exiled.API.Features.Items;
    using Exiled.Events.EventArgs;
    using PlayerStatsSystem;

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
            if (ev.Shooter is null || ev.Target is null)
                return;

            if (ev.Shooter.CurrentItem is not Firearm firearm)
                return;

            if (!DamageTypeExtensions.ItemConversion.TryGetValue(firearm.Type, out DamageType value) ||
                !plugin.Config.DamageValues.TryGetValue(value, out DamageTypeConfig damageConfig))
                return;

            float damage = damageConfig.GetDamage(ev.Target, ev.Hitbox._dmgMultiplier);
            if (damage > 0)
            {
                // This is stupid and I'm mad about it
                ev.Damage = 1;
                ev.Target.Hurt(new UniversalDamageHandler(damage - 1f, DeathTranslations.BulletWounds));
            }
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnReloadedConfigs()"/>
        public void OnReloadedConfigs() => plugin.Config.Reload();
    }
}