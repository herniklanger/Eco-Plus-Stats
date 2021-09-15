﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]
    [LocDisplayName("Campfire Stew")]
    [Category("Hidden")]
    [Weight(500)]
    public partial class CampfireStewItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A thick stew chock-full of meat, camas, and corn. A suprisingly good combination.");
        
        public override float Calories                  => 1200;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 5, Fat = 9, Protein = 10, Vitamins = 4};
    }

}