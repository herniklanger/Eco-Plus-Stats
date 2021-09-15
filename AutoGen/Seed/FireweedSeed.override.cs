﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Items.SearchAndSelect;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Players;
    using System.ComponentModel;

    [Serialized]
    [LocDisplayName("Fireweed Seed")]
    [Weight(50)]
    [StartsDiscovered]
    [Tag("Crop Seed", 1)]
    public partial class FireweedSeedItem : SeedItem
    {
        static FireweedSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow fireweed."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Fireweed"); } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [LocDisplayName("Fireweed Seed Pack")]
    [Category("Hidden")]
    [Weight(50)]
    public partial class FireweedSeedPackItem : SeedPackItem
    {
        static FireweedSeedPackItem() { }

        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow fireweed."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Fireweed"); } }
    }


    [RequiresSkill(typeof(FarmingSkill), 1)]
    public partial class FireweedSeedRecipe : RecipeFamily
    {
        public FireweedSeedRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "FireweedSeed",  //noloc
                Localizer.DoStr("Fireweed Seed"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(FireweedShootsItem), 1, typeof(FarmingSkill), typeof(FarmingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<FireweedSeedItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.LaborInCalories = CreateLaborInCaloriesValue(40, typeof(FarmingSkill));
            this.CraftMinutes = CreateCraftTimeValue(1);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Fireweed Seed"), typeof(FireweedSeedRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
