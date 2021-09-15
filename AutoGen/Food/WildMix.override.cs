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
    [LocDisplayName("Wild Mix")]
    [Weight(600)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class WildMixItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A dressed salad that, with the added sweetness, its pretty tasty.");
        
        public override float Calories                  => 900;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 11, Fat = 6, Protein = 8, Vitamins = 21};
    }


    [RequiresSkill(typeof(AdvancedCookingSkill), 1)]
    public partial class WildMixRecipe : RecipeFamily
    {
        public WildMixRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "WildMix",  //noloc
                Localizer.DoStr("Wild Mix"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(BasicSaladItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(HuckleberryExtractItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<WildMixItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(WildMixRecipe), 4, typeof(AdvancedCookingSkill), typeof(AdvancedCookingFocusedSpeedTalent), typeof(AdvancedCookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Wild Mix"), typeof(WildMixRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}