// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomDamage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using Exiled.API.Enums;
    using Exiled.API.Extensions;
    using Exiled.API.Features;
    using Exiled.API.Interfaces;
    using Exiled.Loader;
    using YamlDotNet.Serialization;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the types corresponding with their respective configs.
        /// </summary>
        [YamlIgnore]
        public Dictionary<DamageType, DamageTypeConfig> DamageValues { get; set; } = new();

        /// <summary>
        /// Gets or sets the folder containing the configs.
        /// </summary>
        [Description("The folder containing the configs.")]
        public string Folder { get; set; } = Path.Combine(Paths.Configs, "CustomDamage");

        /// <summary>
        /// Reloads the config file.
        /// </summary>
        public void Reload()
        {
            if (!Directory.Exists(Folder))
                Directory.CreateDirectory(Folder);

            foreach (DamageType damageType in Enum.GetValues(typeof(DamageType)))
            {
                try
                {
                    if (!damageType.IsWeapon())
                        continue;

                    string path = Path.Combine(Folder, damageType + ".yml");
                    DamageTypeConfig value = File.Exists(path)
                        ? Loader.Deserializer.Deserialize<DamageTypeConfig>(File.ReadAllText(path))
                        : new DamageTypeConfig();

                    DamageValues.Add(damageType, value);
                    File.WriteAllText(path, Loader.Serializer.Serialize(value));
                }
                catch (Exception e)
                {
                    Log.Error($"Error while attempting to reload config file '{damageType}':\n{e.Message}");
                }
            }
        }
    }
}