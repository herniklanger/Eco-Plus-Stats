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
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Core.Controller;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>

    [RequiresSkill(typeof(CompositesSkill), 1)]
    [ForceCreateView]
    public partial class CompositeSpruceLumberRecipe : Recipe
    {
        public CompositeSpruceLumberRecipe()
        {
            this.Init(
                "CompositeSpruceLumber",  //noloc
                Localizer.DoStr("Composite Spruce Lumber"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(SpruceLogItem), 1, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)),
                    new IngredientElement(typeof(PlasticItem), 1, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)),
                    new IngredientElement(typeof(EpoxyItem), 1, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)),
                    new IngredientElement("Lumber", 1, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CompositeSpruceLumberItem>(),
                    new CraftingElement<GarbageItem>(0.3f)
                });
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(AdvancedCarpentryTableObject), typeof(CompositeLumberRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Constructed]
    [BlockTier(4)]
    [RequiresSkill(typeof(CompositesSkill), 1)]
    public partial class CompositeSpruceLumberBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CompositeSpruceLumberItem); } }
    }

    [Serialized]
    [LocDisplayName("Composite Spruce Lumber")]
    [MaxStackSize(20)]
    [Weight(10000)]
    [Ecopedia("Blocks", "Building Materials", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("CompositeLumber", 1)]
    [Tag("Constructable", 1)]
    [Tier(4)]
    public partial class CompositeSpruceLumberItem :
 
    BlockItem<CompositeSpruceLumberBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Composite Spruce Lumber"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A composite lumber made from a combination of wood and plastic."); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(CompositeSpruceLumberStacked1Block),
            typeof(CompositeSpruceLumberStacked2Block),
            typeof(CompositeSpruceLumberStacked3Block),
            typeof(CompositeSpruceLumberStacked4Block)
        };
        
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class CompositeSpruceLumberStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class CompositeSpruceLumberStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class CompositeSpruceLumberStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class CompositeSpruceLumberStacked4Block : PickupableBlock { } //Only a wall if it's all 4 CompositeSpruceLumber
}
