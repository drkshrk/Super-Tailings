// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

/* ********************************
 * Steel Heart Eco - Wet Tailing
 *          Recipe
 *      V 0.1 - Alpha Release
 * ******************************** */

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

    //
    //Begin Recipe Section
    //
    public partial class WetToDryTailRecipe : RecipeFamily
    {
        public WetToDryTailRecipe()
        {
            var product = new Recipe(
                "Super Tailings",
                Localizer.DoStr("Super Tailings"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(WetTailingsItem), 5, true),
                },
               new CraftingElement<TailingsItem>(4),
               new CraftingElement<SandItem>(1)
            );
            this.Initialize(Localizer.DoStr("Wet to Dry Tailings"), typeof(WetToDryTailRecipe));
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(200);
            this.ExperienceOnCraft = 10;
            this.CraftMinutes = CreateCraftTimeValue(typeof(WetToDryTailRecipe), this.UILink(), 1.5f, typeof(MiningSkill));
            this.Initialize(Localizer.DoStr("Wet to Dry Tailings"), typeof(WetToDryTailRecipe));
            CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
        }
    }


}
