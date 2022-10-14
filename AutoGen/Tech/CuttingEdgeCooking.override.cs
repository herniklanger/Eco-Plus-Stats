﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Items;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;
    using Eco.Core.Controller;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [Serialized]
    [LocDisplayName("Cutting Edge Cooking")]
    [Ecopedia("Professions", "Chef", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [RequiresSkill(typeof(ChefSkill), 0), Tag("Chef Specialty"), Tier(5)]
    [Tag("Specialty")]
    [Tag("Teachable")]
    public partial class CuttingEdgeCookingSkill : Skill
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Cutting edge cooking works with ingredients that don't quite sound like food but can potentially provide high calorie and nutrition. Levels up by crafting related recipes."); } }

        public override void OnLevelUp(User user)
        {
            user.Skillset.AddExperience(typeof(SelfImprovementSkill), 20, Localizer.DoStr("for leveling up another specialization."));
        }


        public static MultiplicativeStrategy MultiplicativeStrategy =
            new MultiplicativeStrategy(new float[] { 
                1,
                1 - 0.2f,
                1 - 0.25f,
                1 - 0.3f,
                1 - 0.35f,
                1 - 0.4f,
                1 - 0.45f,
                1 - 0.5f,
            });
        public override MultiplicativeStrategy MultiStrategy => MultiplicativeStrategy;

        public static AdditiveStrategy AdditiveStrategy =
            new AdditiveStrategy(new float[] { 
                0,
                0.5f,
                0.55f,
                0.6f,
                0.65f,
                0.7f,
                0.75f,
                0.8f,
            });
        public override AdditiveStrategy AddStrategy => AdditiveStrategy;
        public override int MaxLevel { get { return 7; } }
        public override int Tier { get { return 5; } }
    }

    [Serialized]
    [LocDisplayName("Cutting Edge Cooking Skill Book")]
    [Category("Hidden"), Tag("NotInBrowser")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CuttingEdgeCookingSkillBook : SkillBook<CuttingEdgeCookingSkill, CuttingEdgeCookingSkillScroll> {}

    [Serialized]
    [LocDisplayName("Cutting Edge Cooking Skill Scroll")]
    [Category("Hidden"), Tag("NotInBrowser")]
    public partial class CuttingEdgeCookingSkillScroll : SkillScroll<CuttingEdgeCookingSkill, CuttingEdgeCookingSkillBook> {}


    [RequiresSkill(typeof(AdvancedCookingSkill), 1)]
    public partial class CuttingEdgeCookingSkillBookRecipe : RecipeFamily
    {
        public CuttingEdgeCookingSkillBookRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "CuttingEdgeCooking",  //noloc
                Localizer.DoStr("Cutting Edge Cooking Skill Book"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CulinaryResearchPaperAdvancedItem), 20, typeof(AdvancedCookingSkill)),
                    new IngredientElement(typeof(CulinaryResearchPaperModernItem), 20, typeof(AdvancedCookingSkill)),
                    new IngredientElement(typeof(MetallurgyResearchPaperModernItem), 10, typeof(AdvancedCookingSkill)),
                    new IngredientElement(typeof(AgricultureResearchPaperModernItem), 10, typeof(AdvancedCookingSkill)),
                    new IngredientElement("Basic Research", 30, typeof(AdvancedCookingSkill)), //noloc
                    new IngredientElement("Advanced Research", 10, typeof(AdvancedCookingSkill)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CuttingEdgeCookingSkillBook>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.LaborInCalories = CreateLaborInCaloriesValue(6000, typeof(AdvancedCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CuttingEdgeCookingSkillBookRecipe), 60, typeof(AdvancedCookingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Cutting Edge Cooking Skill Book"), typeof(CuttingEdgeCookingSkillBookRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CapitolObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
