﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using Eco.Core.Items;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]
    [LocDisplayName("Fiddleheads")]
    [Weight(10)]
    [Yield(typeof(FiddleheadsItem), typeof(GatheringSkill), new float[] {1f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2.0f})]
    [Crop]
    [Tag("Crop", 1)]
    [Tag("Harvestable", 1)]
    [Tag("Greens", 1)]
    [Tag("Raw Food", 1)]
    [Ecopedia("Food", "Produce", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class FiddleheadsItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Fiddleheads");
        public override LocString DisplayDescription    => Localizer.DoStr("A collection of the furled fronds of young ferns; a unique addition to a meal.");
        
        public override float Calories                  => 5;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 2, Fat = 0, Protein = 1, Vitamins = 5};
    }

}