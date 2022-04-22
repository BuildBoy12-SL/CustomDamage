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

        [Description("The non gun damage custom values, set to -1 for default")]
        public Dictionary<DamageType, float> DamageValues { get; set; } = new Dictionary<DamageType, float>()
        {
            {DamageType.Asphyxiation, -1f},
            {DamageType.Bleeding, -1f},
            {DamageType.Crushed, -1f},
            {DamageType.Decontamination, -1f},
            {DamageType.Explosion, -1f},
            {DamageType.Falldown, -1f},
            {DamageType.Hypothermia, -1f},
            {DamageType.Poison, -1f},
            {DamageType.Scp018, -1f},
            {DamageType.Scp049, -1f},
            {DamageType.Scp096, -1f},
            {DamageType.Scp106, -1f},
            {DamageType.Scp173, -1f},
            {DamageType.Scp207, -1f},
            {DamageType.Scp0492, -1f},
            {DamageType.Scp939, -1f},
            {DamageType.Warhead, -1f},
            {DamageType.SeveredHands, -1f},
        };
            
        [Description("The custom damage values of the Com15, set to -1 for default")]
        public Dictionary<DamageType, DamageTypeConfig> GunDamageValues { get; set; } = new Dictionary<DamageType, DamageTypeConfig>()
        {
            {
                DamageType.Com15, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                }
            },
            {
                DamageType.Com18, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                }
            },
            {
                DamageType.Crossvec, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                }
            },
            {
                DamageType.Fsp9, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                }
            },
            {
                DamageType.Logicer, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                }
            },
            {
                DamageType.Revolver, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                }
            },
            {
                DamageType.Shotgun, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                }
            },
            {
                DamageType.AK, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                }
            },
            {
                DamageType.E11Sr, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                }
            },
            {
                DamageType.MicroHid, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                }
            },
            {
                DamageType.ParticleDisruptor, new DamageTypeConfig()
                {
                    UnArmoured = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    LightArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    CombatArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                    HeavyArmour = new hitBoxValues()
                    {
                        Body = -1f,
                        Limb = -1f,
                        Head = -1f,
                    },
                }
            },
        };
    }
}