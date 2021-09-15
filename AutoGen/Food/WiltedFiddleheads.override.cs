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
    [LocDisplayName("Wilted Fiddleheads")]
    [Weight(200)]
    [Tag("CharredGreen", 1)]
    [Ecopedia("Food", "Charred Food", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class WiltedFiddleheadsItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Wilted Fiddleheads");
        public override LocString DisplayDescription    => Localizer.DoStr("While a bunch of wilted fiddleheads may seem a bit sad, at least they're nutritious.");
        
        public override float Calories                  => 200;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 4, Fat = 0, Protein = 1, Vitamins = 7};
    }


    [RequiresSkill(typeof(CampfireCookingSkill), 0)]
    public partial class WiltedFiddleheadsRecipe : RecipeFamily
    {
        public WiltedFiddleheadsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "WiltedFiddleheads",  //noloc
                Localizer.DoStr("Wilted Fiddleheads"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(FiddleheadsItem), 40, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<WiltedFiddleheadsItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CampfireCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(WiltedFiddleheadsRecipe), 0.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Wilted Fiddleheads"), typeof(WiltedFiddleheadsRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}