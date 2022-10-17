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
    [RequireComponent(typeof(BedComponent))]
    [RequireComponent(typeof(MountComponent))]
    public partial class CastIronBedObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(CastIronBedItem);
        public override LocString DisplayName => Localizer.DoStr("Cast Iron Bed");
        public override TableTextureMode TableTexture => TableTextureMode.Metal;
        public override LocString PickupConfirmation => GetComponent<BedComponent>().BedPickupConfirmation();

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<HousingComponent>().HomeValue = CastIronBedItem.homeValue;
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
    [LocDisplayName("Cast Iron Bed")]
    [Ecopedia("Housing Objects", "Bedroom", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Housing", 1)]
    public partial class CastIronBedItem : WorldObjectItem<CastIronBedObject>
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A solid bed made slightly more comfortable by adding cotton.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            Category                 = RoomCategory.Bedroom,
            SkillValue               = 3,
            TypeForRoomLimit         = Localizer.DoStr("Bed"),
            DiminishingReturnPercent = 0.3f
        };

    }

    [RequiresSkill(typeof(TailoringSkill), 6)]
    public partial class CastIronBedRecipe : RecipeFamily
    {
        public CastIronBedRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "CastIronBed",  //noloc
                Localizer.DoStr("Cast Iron Bed"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CottonFabricItem), 40, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),
                    new IngredientElement(typeof(FurPeltItem), 20, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),
                    new IngredientElement(typeof(IronBarItem), 16, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CastIronBedItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 10;
            this.LaborInCalories = CreateLaborInCaloriesValue(180, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CastIronBedRecipe), 6, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Cast Iron Bed"), typeof(CastIronBedRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}