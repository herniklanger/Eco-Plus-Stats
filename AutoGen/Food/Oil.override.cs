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
    [LocDisplayName("Oil")]
    [Weight(100)]
    [Fuel(4000)][Tag("Fuel")]
    [Tag("Fat", 1)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class OilItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Oil");
        public override LocString DisplayDescription    => Localizer.DoStr("A plant fat extracted for use in cooking.");
        
        public override float Calories                  => 60;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 0, Fat = 15, Protein = 0, Vitamins = 0};
    }


    [RequiresSkill(typeof(MillingSkill), 1)]
    public partial class OilRecipe : RecipeFamily
    {
        public OilRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Oil",  //noloc
                Localizer.DoStr("Oil"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CerealGermItem), 12, typeof(MillingSkill), typeof(MillingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<OilItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(MillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(OilRecipe), 2, typeof(MillingSkill), typeof(MillingFocusedSpeedTalent), typeof(MillingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Oil"), typeof(OilRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}