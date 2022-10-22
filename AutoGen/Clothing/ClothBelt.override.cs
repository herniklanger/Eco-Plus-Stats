﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Core.Items;
    using Eco.Shared.Gameplay;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Core.Controller;
    
    [Serialized]
    [LocDisplayName("Cloth Belt")]
    [StartsDiscovered]
    [Weight(100)]
    [Tag("Clothes", 1)]
    [Tag("Small Fabric", 1)]
    [Ecopedia("Items", "Clothing", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ClothBeltItem :
        ClothingItem
    {
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A fashionable cloth belt that drapes across the waist."); } }
        public override string Slot             { get { return ClothingSlots.Belt; } }
        public override bool Starter            { get { return true ; } }

    }
    

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public partial class ClothBeltRecipe : RecipeFamily
    {
        public ClothBeltRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "ClothBelt",  //noloc
                Localizer.DoStr("Cloth Belt"),
                new List<IngredientElement>
                {
                    new IngredientElement("Fabric", 10, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<ClothBeltItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 3;
            this.LaborInCalories = CreateLaborInCaloriesValue(40, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(1);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Cloth Belt"), typeof(ClothBeltRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
