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

    [RequiresSkill(typeof(MiningSkill), 4)]
    public partial class CrushedBasaltRecipe : RecipeFamily
    {
        public CrushedBasaltRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "CrushedBasalt",  //noloc
                Localizer.DoStr("Crushed Basalt"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(BasaltItem), 12, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CrushedBasaltItem>(3)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(MiningSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CrushedBasaltRecipe), 1.5f, typeof(MiningSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Crushed Basalt"), typeof(CrushedBasaltRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ArrastraObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [Solid, Wall, Diggable]
    public partial class CrushedBasaltBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(CrushedBasaltItem); } }
    }

    [Serialized]
    [LocDisplayName("Crushed Basalt")]
    [MaxStackSize(10)]
    [Weight(30000)]
    [StartsDiscovered]
    [Ecopedia("Blocks", "Processed Rock", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("CrushedRock", 1)]
    [Tag("Excavatable", 1)]
    [RequiresTool(typeof(ShovelItem))]
    public partial class CrushedBasaltItem :
 
    BlockItem<CrushedBasaltBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Crushed Basalt"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Basalt rocks that have been crushed into a fine gravel."); } }

        public override bool CanStickToWalls { get { return false; } }
    }

}
