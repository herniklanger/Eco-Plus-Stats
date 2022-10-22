﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated from WorldObjectTemplate.tt />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.Gameplay.Housing.PropertyValues;
    using Eco.Gameplay.Civics.Objects;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Core.Controller;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(CustomTextComponent))]
    public partial class SmallHangingMortaredStoneSignObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(SmallHangingMortaredStoneSignItem);
        public override LocString DisplayName => Localizer.DoStr("Small Hanging Mortared Stone Sign");
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<CustomTextComponent>().Initialize(700);
            this.ModsPostInitialize();
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Small Hanging Mortared Stone Sign")]
    [Ecopedia("Crafted Objects", "Signs", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Small Mortared Stone Furnishing", 1)]
    public partial class SmallHangingMortaredStoneSignItem : WorldObjectItem<SmallHangingMortaredStoneSignObject>, IPersistentData
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A small sign for all of your smaller text needs!");



        [Serialized, SyncToView, TooltipChildren, NewTooltipChildren] public object PersistentData { get; set; }
    }

    [RequiresSkill(typeof(MasonrySkill), 1)]
    public partial class SmallHangingMortaredStoneSignRecipe : RecipeFamily
    {
        public SmallHangingMortaredStoneSignRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "SmallHangingMortaredStoneSign",  //noloc
                Localizer.DoStr("Small Hanging Mortared Stone Sign"),
                new List<IngredientElement>
                {
                    new IngredientElement("MortaredStone", 6, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<SmallHangingMortaredStoneSignItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(MasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SmallHangingMortaredStoneSignRecipe), 5, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Small Hanging Mortared Stone Sign"), typeof(SmallHangingMortaredStoneSignRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
