// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomDamage
{
    using System;
    using Exiled.API.Features;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <inheritdoc/>
        public override string Author => "Build";

        /// <inheritdoc />
        public override string Name => "CustomDamage";

        /// <inheritdoc />
        public override string Prefix => "CustomDamage";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new(5, 1, 3);

        /// <inheritdoc />
        public override Version Version { get; } = new(1, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            Config.Reload();

            eventHandlers = new EventHandlers(this);
            Exiled.Events.Handlers.Player.Shot += eventHandlers.OnShot;
            Exiled.Events.Handlers.Server.ReloadedConfigs += eventHandlers.OnReloadedConfigs;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Shot -= eventHandlers.OnShot;
            Exiled.Events.Handlers.Server.ReloadedConfigs -= eventHandlers.OnReloadedConfigs;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}