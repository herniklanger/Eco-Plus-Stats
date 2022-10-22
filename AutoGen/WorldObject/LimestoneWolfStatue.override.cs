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
    using static Eco.Gameplay.Housing.PropertyValues.HomeFurnishingValue;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class LimestoneWolfStatueObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(LimestoneWolfStatueItem);
        public override LocString DisplayName => Localizer.DoStr("Limestone Wolf Statue");
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<HousingComponent>().HomeValue = LimestoneWolfStatueItem.homeValue;
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
    [LocDisplayName("Limestone Wolf Statue")]
    [Ecopedia("Housing Objects", "Decoration", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Housing", 1)]
    [Tag("Mortared Stone Furnishing", 1)]
    public partial class LimestoneWolfStatueItem : WorldObjectItem<LimestoneWolfStatueObject>
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A wolf statue carved from limestone.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            Category                 = RoomCategory.LivingRoom,
            SkillValue               = 1.5f,
            TypeForRoomLimit         = Localizer.DoStr("Decoration"),
            DiminishingReturnPercent = 0.5f
        };

    }

    [RequiresSkill(typeof(MasonrySkill), 3)]
    public partial class LimestoneWolfStatueRecipe : RecipeFamily
    {
        public LimestoneWolfStatueRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "LimestoneWolfStatue",  //noloc
                Localizer.DoStr("Limestone Wolf Statue"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(LimestoneItem), 80, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<LimestoneWolfStatueItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(MasonrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(LimestoneWolfStatueRecipe), 7, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Limestone Wolf Statue"), typeof(LimestoneWolfStatueRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
