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
    [LocDisplayName("Fruit Tart")]
    [Weight(400)]
    [Ecopedia("Food", "Baking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class FruitTartItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A sweet pastry that is great for breakfast or anytime you need a quick boost in energy.");
        
        public override float Calories                  => 800;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 14, Fat = 9, Protein = 5, Vitamins = 20};
    }


    [RequiresSkill(typeof(AdvancedBakingSkill), 1)]
    public partial class FruitTartRecipe : RecipeFamily
    {
        public FruitTartRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "FruitTart",  //noloc
                Localizer.DoStr("Fruit Tart"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(PastryDoughItem), 6, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),
                    new IngredientElement("Fruit", 20, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<FruitTartItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(AdvancedBakingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(FruitTartRecipe), 2, typeof(AdvancedBakingSkill), typeof(AdvancedBakingFocusedSpeedTalent), typeof(AdvancedBakingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Fruit Tart"), typeof(FruitTartRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}