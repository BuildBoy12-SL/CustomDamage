namespace customDamageType
{
    public class DamageTypeConfig
    {
        public hitBoxValues UnArmoured{ get; set; }
        public hitBoxValues LightArmour{ get; set; }
        public hitBoxValues CombatArmour{ get; set; }
        public hitBoxValues HeavyArmour{ get; set; }

        public float getValue(ItemType? armour, HitboxType type)
        {
            switch (armour)
            {
                case null:
                    return UnArmoured.getValue(type);
                case ItemType.ArmorLight:
                    return LightArmour.getValue(type);
                case ItemType.ArmorCombat:
                    return CombatArmour.getValue(type);
                case ItemType.ArmorHeavy:
                    return HeavyArmour.getValue(type);
            }
            return 0f;
        }
    }

    public class hitBoxValues
    {
        public float Body{ get; set; }
        public float Limb{ get; set; }
        public float Head{ get; set; }
        
        public float getValue(HitboxType type)
        {
            switch (type)
            {
                case HitboxType.Body:
                    return Body;
                case HitboxType.Limb:
                    return Limb;
                case HitboxType.Headshot:
                    return Head;
            }

            return 0f;
        }
    }
}