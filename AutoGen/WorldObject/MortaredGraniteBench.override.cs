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
    [RequireComponent(typeof(MountComponent))]
    public partial class MortaredGraniteBenchObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(MortaredGraniteBenchItem);
        public override LocString DisplayName => Localizer.DoStr("Mortared Granite Bench");
        public override TableTextureMode TableTexture => TableTextureMode.Stone;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<HousingComponent>().HomeValue = MortaredGraniteBenchItem.homeValue;
            this.GetComponent<MountComponent>().Initialize(1);
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
    [LocDisplayName("Mortared Granite Bench")]
    [Ecopedia("Housing Objects", "Seating", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Housing", 1)]
    [Tag("Mortared Stone Furnishing", 1)]
    public partial class MortaredGraniteBenchItem : WorldObjectItem<MortaredGraniteBenchObject>
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A basic stone bench for sitting.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            Category                 = RoomCategory.General,
            SkillValue               = 1,
            TypeForRoomLimit         = Localizer.DoStr("Seating"),
            DiminishingReturnPercent = 0.5f
        };

    }

    [RequiresSkill(typeof(MasonrySkill), 3)]
    [ForceCreateView]
    public partial class MortaredGraniteBenchRecipe : Recipe
    {
        public MortaredGraniteBenchRecipe()
        {
            this.Init(
                "MortaredGraniteBench",  //noloc
                Localizer.DoStr("Mortared Granite Bench"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(MortaredGraniteItem), 24, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<MortaredGraniteBenchItem>()
                });
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(MasonryTableObject), typeof(MortaredStoneBenchRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
