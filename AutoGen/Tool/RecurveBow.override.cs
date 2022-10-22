﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Shared.Math;
    using Eco.Core.Controller;


    [RequiresSkill(typeof(SmeltingSkill), 2)]
    public partial class RecurveBowRecipe : RecipeFamily
    {
        public RecurveBowRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "RecurveBow",  //noloc
                Localizer.DoStr("Recurve Bow"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(IronBarItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                    new IngredientElement(typeof(CelluloseFiberItem), 10, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                    new IngredientElement("Lumber", 5, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<RecurveBowItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RecurveBowRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Recurve Bow"), typeof(RecurveBowRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Recurve Bow")]
    [Tier(3)]
    [RepairRequiresSkill(typeof(SmeltingSkill), 0)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Tag("Iron Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class RecurveBowItem : BowItem
    {
                                                                                                                                                                                                                                           // Static values
        private static IDynamicValue caloriesBurn           = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(RecurveBowItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(10, typeof(HuntingSkill), typeof(RecurveBowItem)));
        private static IDynamicValue damage                 = new MultiDynamicValue(MultiDynamicOps.Sum, new TalentModifiedValue(typeof(RecurveBowItem), typeof(HuntingPowerShotTalent), 0), CreateDamageValue(1.2f, typeof(HuntingSkill), typeof(RecurveBowItem)));
        private static IDynamicValue exp                    = new ConstantValue(1);
        private static IDynamicValue tier                   = new ConstantValue(3);
        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(4, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
         

        // Tool overrides

        public override LocString DisplayDescription    => Localizer.DoStr("A recurve bow that shoots faster and more powerful than a traditional wooden bow. Requires arrows to fire.");
        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override IDynamicValue Damage            => damage;
        public override Type ExperienceSkill            => typeof(HuntingSkill);
        public override IDynamicValue ExperienceRate    => exp;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 1000f;
        public override Item RepairItem                 => Item.Get<IronBarItem>();
        public override int FullRepairAmount            => 4;
    }
}