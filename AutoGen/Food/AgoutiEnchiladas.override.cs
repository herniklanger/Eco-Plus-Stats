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
    [LocDisplayName("Agouti Enchiladas")]
    [Weight(550)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class AgoutiEnchiladasItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Sweet and savory...it doesn't have to be an Agouti.");
        
        public override float Calories                  => 750;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 15, Fat = 8, Protein = 14, Vitamins = 20};
    }


    [RequiresSkill(typeof(AdvancedCookingSkill), 4)]
    public partial class AgoutiEnchiladasRecipe : RecipeFamily
    {
        public AgoutiEnchiladasRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "AgoutiEnchiladas",  //noloc
                Localizer.DoStr("Agouti Enchiladas"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CornmealItem), 4, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(TomatoItem), 6, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(PapayaItem), 6, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(SunCheeseItem), 2, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(PrimeCutItem), 4, typeof(AdvancedCookingSkill), typeof(AdvancedCookingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<AgoutiEnchiladasItem>(2)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(40, typeof(AdvancedCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AgoutiEnchiladasRecipe), 3, typeof(AdvancedCookingSkill), typeof(AdvancedCookingFocusedSpeedTalent), typeof(AdvancedCookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Agouti Enchiladas"), typeof(AgoutiEnchiladasRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}