// -----------------------------------------------------------------------
// <copyright file="DamageTypeConfig.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomDamage
{
    using CustomDamage.Models;

    /// <summary>
    /// Handles the <see cref="HitboxValue"/>s for each armor type.
    /// </summary>
    public class DamageTypeConfig
    {
        /// <summary>
        /// Gets or sets the damage values for unarmored targets.
        /// </summary>
        public HitboxValue UnArmoured { get; set; } = new();

        /// <summary>
        /// Gets or sets the damage values for targets with light armor.
        /// </summary>
        public HitboxValue LightArmour { get; set; } = new();

        /// <summary>
        /// Gets or sets the damage values for targets with combat armor.
        /// </summary>
        public HitboxValue CombatArmour { get; set; } = new();

        /// <summary>
        /// Gets or sets the damage values for targets with heavy armor.
        /// </summary>
        public HitboxValue HeavyArmour { get; set; } = new();

        /// <summary>
        /// Gets the damage value for the corresponding armor type and hitbox.
        /// </summary>
        /// <param name="armor">The armor type.</param>
        /// <param name="hitbox">The hitbox.</param>
        /// <returns>The damage value to use.</returns>
        public float GetValue(ItemType armor, HitboxType hitbox)
        {
            switch (armor)
            {
                case ItemType.ArmorLight:
                    return LightArmour.GetValue(hitbox);
                case ItemType.ArmorCombat:
                    return CombatArmour.GetValue(hitbox);
                case ItemType.ArmorHeavy:
                    return HeavyArmour.GetValue(hitbox);
                default:
                    return UnArmoured.GetValue(hitbox);
            }
        }
    }
}