﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Core.Controller;


    [RequiresSkill(typeof(OilDrillingSkill), 1)]
    public partial class NylonRecipe : RecipeFamily
    {
        public NylonRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Nylon",  //noloc
                Localizer.DoStr("Nylon"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(PetroleumItem), 4, typeof(OilDrillingSkill), typeof(OilDrillingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<NylonItem>(2),
                    new CraftingElement<BarrelItem>(typeof(OilDrillingSkill), 3, typeof(OilDrillingLavishResourcesTalent)),
                    new CraftingElement<GarbageItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(180, typeof(OilDrillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(NylonRecipe), 1.5f, typeof(OilDrillingSkill), typeof(OilDrillingFocusedSpeedTalent), typeof(OilDrillingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Nylon"), typeof(NylonRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [Serialized]
    [LocDisplayName("Nylon")]
    [Weight(500)]
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class NylonItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Nylon is a synthetic polymer that can be used as a cheap alternative to more natural textiles. "); } }
    }
}