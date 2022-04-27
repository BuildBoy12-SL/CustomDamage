// -----------------------------------------------------------------------
// <copyright file="DamageTypeConfig.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomDamage.Configs
{
    using CustomDamage.Models;
    using Exiled.API.Features;
    using InventorySystem.Items.Armor;

    /// <summary>
    /// Handles the <see cref="HitboxValue"/>s for each armor type.
    /// </summary>
    public class DamageTypeConfig
    {
        /// <summary>
        /// Gets or sets the damage values for unarmored targets.
        /// </summary>
        public HitboxValue Unarmored { get; set; } = new();

        /// <summary>
        /// Gets or sets the damage values for targets with light armor.
        /// </summary>
        public HitboxValue LightArmor { get; set; } = new();

        /// <summary>
        /// Gets or sets the damage values for targets with combat armor.
        /// </summary>
        public HitboxValue CombatArmor { get; set; } = new();

        /// <summary>
        /// Gets or sets the damage values for targets with heavy armor.
        /// </summary>
        public HitboxValue HeavyArmor { get; set; } = new();

        /// <summary>
        /// Gets the damage value for the corresponding armor type and hitbox.
        /// </summary>
        /// <param name="target">The player to hurt.</param>
        /// <param name="hitbox">The hitbox.</param>
        /// <returns>The damage value to use.</returns>
        public float GetDamage(Player target, HitboxType hitbox)
        {
            if (!target.Inventory.TryGetBodyArmor(out BodyArmor armor))
                return Unarmored.GetValue(hitbox);

            return armor.ItemTypeId switch
            {
                ItemType.ArmorLight => LightArmor.GetValue(hitbox),
                ItemType.ArmorCombat => CombatArmor.GetValue(hitbox),
                ItemType.ArmorHeavy => HeavyArmor.GetValue(hitbox),
                _ => Unarmored.GetValue(hitbox)
            };
        }
    }
}