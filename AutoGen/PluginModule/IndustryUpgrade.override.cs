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

    [RequiresSkill(typeof(IndustrySkill), 7)]
    public partial class IndustryUpgradeRecipe : RecipeFamily
    {
        public IndustryUpgradeRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "IndustryUpgrade",  //noloc
                Localizer.DoStr("Industry Upgrade"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(ModernUpgradeLvl4Item), 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<IndustryUpgradeItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 4;
            this.LaborInCalories = CreateLaborInCaloriesValue(9000, typeof(IndustrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(IndustryUpgradeRecipe), 18, typeof(IndustrySkill), typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Industry Upgrade"), typeof(IndustryUpgradeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(RoboticAssemblyLineObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Industry Upgrade")]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Specialty Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                      //_If_EcopediaPage_
    [Tag("Upgrade", 1)]
    public partial class IndustryUpgradeItem :
        EfficiencyModule
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Modern Upgrade that greatly increases efficiency when crafting Industry recipes."); } }

        public IndustryUpgradeItem() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.7f + 0.05f,
            typeof(IndustrySkill),
            0.7f         
        ) { }
    }
}
