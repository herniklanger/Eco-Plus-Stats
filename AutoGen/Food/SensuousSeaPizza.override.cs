﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]
    [LocDisplayName("Sensuous Sea Pizza")]
    [Weight(300)]
    [Ecopedia("Food", "Baking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class SensuousSeaPizzaItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("The chewyness is unreal.");
        
        public override float Calories                  => 1200;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 10, Fat = 18, Protein = 16, Vitamins = 10};
    }


    [RequiresSkill(typeof(AdvancedBakingSkill), 3)]
    public partial class SensuousSeaPizzaRecipe : RecipeFamily
    {
        public SensuousSeaPizzaRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "SensuousSeaPizza",  //noloc
                Localizer.DoStr("Sensuous Sea Pizza"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(LeavenedDoughItem), 4, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),
                    new IngredientElement(typeof(PacificSardineItem), 2, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),
                    new IngredientElement(typeof(KelpItem), 2, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),
                    new IngredientElement(typeof(SunCheeseItem), 2, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),
                    new IngredientElement(typeof(TomatoItem), 4, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<SensuousSeaPizzaItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedBakingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SensuousSeaPizzaRecipe), 3, typeof(AdvancedBakingSkill), typeof(AdvancedBakingFocusedSpeedTalent), typeof(AdvancedBakingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Sensuous Sea Pizza"), typeof(SensuousSeaPizzaRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}