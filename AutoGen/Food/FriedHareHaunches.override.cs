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
    [LocDisplayName("Fried Hare Haunches")]
    [Weight(100)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class FriedHareHaunchesItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Everything is better deep fried.");
        
        public override float Calories                  => 700;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 6, Fat = 27, Protein = 15, Vitamins = 4};
    }


    [RequiresSkill(typeof(AdvancedCookingSkill), 2)]
    public partial class FriedHareHaunchesRecipe : RecipeFamily
    {
        public FriedHareHaunchesRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "FriedHareHaunches",  //noloc
                Localizer.DoStr("Fried Hare Haunches"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(FlourItem), 8, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(PreparedMeatItem), 4, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(OilItem), 4, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<FriedHareHaunchesItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FriedHareHaunchesRecipe), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingFocusedSpeedTalent), typeof(AdvancedCookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Fried Hare Haunches"), typeof(FriedHareHaunchesRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}