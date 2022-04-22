using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;

namespace customDamageType
{
    public class Config : IConfig
    {
        [Description("Whether or not to enable the plugin")]
        public bool IsEnabled { get; set; } = true;

        [Description("The non gun damage custom values")]
        public Dictionary<DamageType, float> DamageValues = new Dictionary<DamageType, float>()
        {
            {DamageType.Asphyxiation, 1f},
        };
            
        [Description("The custom damage values of guns")]
        public Dictionary<DamageType, DamageTypeConfig> GunDamageValues = new Dictionary<DamageType, DamageTypeConfig>()
        {
            {
                DamageType.Com15, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = 19.6f,
                        Limb = 13.72f,
                        Head = 68.6f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = 13.7f,
                        Limb = 13.72f,
                        Head = 53.2f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = 10.8f,
                        Limb = 13.72f,
                        Head = 27.3f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = 7.8f,
                        Limb = 13.72f,
                        Head = 27.3f,
                    },
                }
            },
            {
                DamageType.Com18, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = 20.2f,
                        Limb = 14.14f,
                        Head = 70.7f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = 15.8f,
                        Limb = 14.14f,
                        Head = 59.15f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = 13.5f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = 11.3f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                }
            },
            {
                DamageType.Crossvec, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = 20.2f,
                        Limb = 14.14f,
                        Head = 70.7f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = 15.8f,
                        Limb = 14.14f,
                        Head = 59.15f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = 13.5f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = 11.3f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                }
            },
            {
                DamageType.Fsp9, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = 20.2f,
                        Limb = 14.14f,
                        Head = 70.7f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = 15.8f,
                        Limb = 14.14f,
                        Head = 59.15f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = 13.5f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = 11.3f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                }
            },
            {
                DamageType.Logicer, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = 20.2f,
                        Limb = 14.14f,
                        Head = 70.7f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = 15.8f,
                        Limb = 14.14f,
                        Head = 59.15f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = 13.5f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = 11.3f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                }
            },
            {
                DamageType.Revolver, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = 20.2f,
                        Limb = 14.14f,
                        Head = 70.7f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = 15.8f,
                        Limb = 14.14f,
                        Head = 59.15f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = 13.5f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = 11.3f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                }
            },
            {
                DamageType.Shotgun, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = 20.2f,
                        Limb = 14.14f,
                        Head = 70.7f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = 15.8f,
                        Limb = 14.14f,
                        Head = 59.15f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = 13.5f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = 11.3f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                }
            },
            {
                DamageType.AK, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = 20.2f,
                        Limb = 14.14f,
                        Head = 70.7f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = 15.8f,
                        Limb = 14.14f,
                        Head = 59.15f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = 13.5f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = 11.3f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                }
            },
            {
                DamageType.E11Sr, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = 20.2f,
                        Limb = 14.14f,
                        Head = 70.7f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = 15.8f,
                        Limb = 14.14f,
                        Head = 59.15f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = 13.5f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = 11.3f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                }
            },
            {
                DamageType.MicroHid, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = 20.2f,
                        Limb = 14.14f,
                        Head = 70.7f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = 15.8f,
                        Limb = 14.14f,
                        Head = 59.15f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = 13.5f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = 11.3f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                }
            },
            {
                DamageType.ParticleDisruptor, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = 20.2f,
                        Limb = 14.14f,
                        Head = 70.7f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = 15.8f,
                        Limb = 14.14f,
                        Head = 59.15f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = 13.5f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = 11.3f,
                        Limb = 14.14f,
                        Head = 39.55f,
                    },
                }
            },
        };
    }
}