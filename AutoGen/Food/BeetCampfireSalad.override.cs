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
    [LocDisplayName("Beet Campfire Salad")]
    [Weight(200)]
    [Tag("CampfireSalad", 1)]
    [Ecopedia("Food", "Campfire", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BeetCampfireSaladItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A myriad of plants that make a healthy and odd blend.");
        
        public override float Calories                  => 650;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 6, Fat = 3, Protein = 4, Vitamins = 8};
    }


    [RequiresSkill(typeof(CampfireCookingSkill), 1)]
    public partial class BeetCampfireSaladRecipe : RecipeFamily
    {
        public BeetCampfireSaladRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "BeetCampfireSalad",  //noloc
                Localizer.DoStr("Beet Campfire Salad"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(BeetGreensItem), 10, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(BeetItem), 10, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),
                    new IngredientElement("Fruit", 10, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<BeetCampfireSaladItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BeetCampfireSaladRecipe), 1, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Beet Campfire Salad"), typeof(BeetCampfireSaladRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}