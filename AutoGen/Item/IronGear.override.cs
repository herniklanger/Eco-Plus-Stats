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


    [RequiresSkill(typeof(MechanicsSkill), 1)]
    public partial class IronGearRecipe : RecipeFamily
    {
        public IronGearRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "IronGear",  //noloc
                Localizer.DoStr("Iron Gear"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(IronBarItem), 1, typeof(MechanicsSkill), typeof(MechanicsLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<IronGearItem>(),
                    new CraftingElement<GarbageItem>(0.1f)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(75, typeof(MechanicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronGearRecipe), 0.4f, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Iron Gear"), typeof(IronGearRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ShaperObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [Serialized]
    [LocDisplayName("Iron Gear")]
    [Weight(500)]
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Gear", 1)]
    public partial class IronGearItem : Item
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A toothed machine part that interlocks with others."); } }
    }
}