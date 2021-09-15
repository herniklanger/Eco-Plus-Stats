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
    [LocDisplayName("Palm Seed")]
    [Weight(50)]
    [StartsDiscovered]
    public partial class PalmSeedItem : SeedItem
    {
        static PalmSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow a palm tree."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Palm"); } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [LocDisplayName("Palm Seed Pack")]
    [Category("Hidden")]
    [Weight(50)]
    public partial class PalmSeedPackItem : SeedPackItem
    {
        static PalmSeedPackItem() { }

        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow a palm tree."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Palm"); } }
    }

}
