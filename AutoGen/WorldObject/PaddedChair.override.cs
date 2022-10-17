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
    public partial class PaddedChairObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(PaddedChairItem);
        public override LocString DisplayName => Localizer.DoStr("Padded Chair");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<HousingComponent>().HomeValue = PaddedChairItem.homeValue;
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
    [LocDisplayName("Padded Chair")]
    [Ecopedia("Housing Objects", "Seating", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Housing", 1)]
    public partial class PaddedChairItem : WorldObjectItem<PaddedChairObject>
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A comfy chair to rest in.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            Category                 = RoomCategory.LivingRoom,
            SkillValue               = 1.5f,
            TypeForRoomLimit         = Localizer.DoStr("Seating"),
            DiminishingReturnPercent = 0.8f
        };

    }

    [RequiresSkill(typeof(TailoringSkill), 1)]
    public partial class PaddedChairRecipe : RecipeFamily
    {
        public PaddedChairRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "PaddedChair",  //noloc
                Localizer.DoStr("Padded Chair"),
                new List<IngredientElement>
                {
                    new IngredientElement("HewnLog", 10, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)), //noloc
                    new IngredientElement("WoodBoard", 20, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)), //noloc
                    new IngredientElement("Fabric", 10, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)), //noloc
                    new IngredientElement(typeof(FurPeltItem), 8, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<PaddedChairItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PaddedChairRecipe), 8, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Padded Chair"), typeof(PaddedChairRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
