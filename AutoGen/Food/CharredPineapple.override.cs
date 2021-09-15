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
    [LocDisplayName("Charred Pineapple")]
    [Weight(100)]
    [Tag("CharredFruit", 1)]
    [Ecopedia("Food", "Charred Food", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CharredPineappleItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Pineapple that has been charred over a basic campfire.");
        
        public override float Calories                  => 400;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 6, Fat = 0, Protein = 1, Vitamins = 2};
    }


    [RequiresSkill(typeof(CampfireCookingSkill), 0)]
    public partial class CharredPineappleRecipe : RecipeFamily
    {
        public CharredPineappleRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "CharredPineapple",  //noloc
                Localizer.DoStr("Charred Pineapple"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(PineappleItem), 10, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CharredPineappleItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredPineappleRecipe), 0.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Charred Pineapple"), typeof(CharredPineappleRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}