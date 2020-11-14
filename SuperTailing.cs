// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

/* ********************************
 * Steel Heart Eco - Super Tailing 
 *          World Block
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

    [Serialized, Weight(60)]
    [LocDisplayName("Super Tailings")]
    [MaxStackSize(10)]
    [RequiresTool(typeof(ShovelItem))]
    [Tag("Excavatable", 1)]
    [Ecopedia("Blocks", "Byproducts", true, InPageTooltip.DynamicTooltip)]
    public class SuperTailingItem : BlockItem<TailingsBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Super Tailings"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Waste product from super concentrating ore. When stored improperly the run-off will create pollution; killing nearby plants and seeping into the water supply. Bury deep underground to help neutralize the effect."); } }
        public override bool CanStickToWalls { get { return false; } }
    }
    
    public partial class SuperTailingRecipe : RecipeFamily
    {
        public SuperTailingRecipe()
        {
            var product = new Recipe(
                "Super Tailings",
                Localizer.DoStr("Super Tailings"),
                new IngredientElement[]
                {
               new IngredientElement(typeof(TailingsItem), 5, true),
                },
               new CraftingElement<SuperTailingItem>(1),
               new CraftingElement<SandItem>(3)
            );
            this.Initialize(Localizer.DoStr("Super Tailings"), typeof(SuperTailingRecipe));
            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(200);
            this.ExperienceOnCraft = 10;
            this.CraftMinutes = CreateCraftTimeValue(typeof(SuperTailingRecipe), this.UILink(), 1.5f, typeof(MiningSkill));
            this.Initialize(Localizer.DoStr("Super Tailings"), typeof(SuperTailingRecipe));
            CraftingComponent.AddRecipe(typeof(SensorBasedBeltSorterObject), this);
        }
    }
}
