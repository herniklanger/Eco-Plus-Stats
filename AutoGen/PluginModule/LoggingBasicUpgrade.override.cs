﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Core.Controller;

    [RequiresSkill(typeof(LoggingSkill), 7)]
    public partial class LoggingBasicUpgradeRecipe : RecipeFamily
    {
        public LoggingBasicUpgradeRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "LoggingBasicUpgrade",  //noloc
                Localizer.DoStr("Logging Basic Upgrade"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(BasicUpgradeLvl4Item), 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<LoggingBasicUpgradeItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 4;
            this.LaborInCalories = CreateLaborInCaloriesValue(3000, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(LoggingBasicUpgradeRecipe), 10, typeof(LoggingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Logging Basic Upgrade"), typeof(LoggingBasicUpgradeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Logging Basic Upgrade")]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Specialty Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                      //_If_EcopediaPage_
    [Tag("Upgrade", 1)]
    public partial class LoggingBasicUpgradeItem :
        EfficiencyModule
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Basic Upgrade that greatly increases efficiency when crafting Logging recipes."); } }

        public LoggingBasicUpgradeItem() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.7f + 0.05f,
            typeof(LoggingSkill),
            0.7f         
        ) { }
    }
}
