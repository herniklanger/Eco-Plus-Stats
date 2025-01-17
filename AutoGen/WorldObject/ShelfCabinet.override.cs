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
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class ShelfCabinetObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(ShelfCabinetItem);
        public override LocString DisplayName => Localizer.DoStr("Shelf Cabinet");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<HousingComponent>().HomeValue = ShelfCabinetItem.homeValue;
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(8);
            storage.Storage.AddInvRestriction(new NotCarriedRestriction()); // can't store block or large itemsa
            this.ModsPostInitialize();
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Shelf Cabinet")]
    [Ecopedia("Housing Objects", "Decoration", createAsSubPage: true)]
    [Tag("Housing", 1)]
    [Tag("Lumber Furnishing", 1)]
    public partial class ShelfCabinetItem : WorldObjectItem<ShelfCabinetObject>
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("When a shelf and a cabinet aren't enough individually.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            Category                 = RoomCategory.General,
            HouseValue               = 2,
            TypeForRoomLimit         = Localizer.DoStr("Shelves"),
            DiminishingReturnPercent = 0.5f
        };

    }

    [RequiresSkill(typeof(CarpentrySkill), 5)]
    public partial class ShelfCabinetRecipe : RecipeFamily
    {
        public ShelfCabinetRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "ShelfCabinet",  //noloc
                Localizer.DoStr("Shelf Cabinet"),
                new List<IngredientElement>
                {
                    new IngredientElement("Lumber", 14, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), //noloc
                    new IngredientElement("WoodBoard", 16, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<ShelfCabinetItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 5;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ShelfCabinetRecipe), 2, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Shelf Cabinet"), typeof(ShelfCabinetRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
