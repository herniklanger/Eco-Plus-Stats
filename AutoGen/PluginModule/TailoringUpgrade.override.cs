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

    [RequiresSkill(typeof(TailoringSkill), 7)]
    public partial class TailoringUpgradeRecipe : RecipeFamily
    {
        public TailoringUpgradeRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "TailoringUpgrade",  //noloc
                Localizer.DoStr("Tailoring Basic Upgrade"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(BasicUpgradeLvl4Item), 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<TailoringUpgradeItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 4;
            this.LaborInCalories = CreateLaborInCaloriesValue(3000, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(TailoringUpgradeRecipe), 10, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Tailoring Basic Upgrade"), typeof(TailoringUpgradeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Tailoring Basic Upgrade")]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Specialty Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                      //_If_EcopediaPage_
    [Tag("Upgrade", 1)]
    public partial class TailoringUpgradeItem :
        EfficiencyModule
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Tailoring Basic Upgrades"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Basic Upgrade that greatly increases efficiency when crafting Tailoring recipes."); } }

        public TailoringUpgradeItem() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.7f + 0.05f,
            typeof(TailoringSkill),
            0.7f         
        ) { }
    }
}
