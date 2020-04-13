/*
	MIT License

	Copyright (c) 2020 Steven Brelsford (Versepelles)

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.
 */

using System.Collections.Generic;
using UnityEngine;
using STRINGS;

namespace FriedLiceloaf
{
	public class FriedLiceloafConfig : IEntityConfig
	{
		public static string Id = "FriedLiceloaf";
		public static string Name = "Fried Liceloaf";
		public static string Description = "Cooking doesn't make this taste any more pleasant, but does release psychoactive compounds that dull the experience.";
		public static string RecipeDescription = "Horrible yet crunchy.";

		public ComplexRecipe Recipe;

		public GameObject CreatePrefab()
		{
			var entity = EntityTemplates.CreateLooseEntity(
				id: Id,
				name: UI.FormatAsLink(Name, Id),
				desc: Description,
				mass: 1f,
				unitMass: false,
				anim: Assets.GetAnim("friedliceloaf_kanim"),
				initialAnim: "object",
				sceneLayer: Grid.SceneLayer.Front,
				collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
				width: 0.8f,
				height: 0.4f,
				isPickupable: true);

			var foodInfo = new EdiblesManager.FoodInfo(
				id: Id,
				caloriesPerUnit: 2200000f,
				quality: TUNING.FOOD.FOOD_QUALITY_MEDIOCRE,
				preserveTemperatue: 255.15f,
				rotTemperature: 277.15f,
				spoilTime: TUNING.FOOD.SPOIL_TIME.DEFAULT,
				can_rot: true);

			var foodEntity = EntityTemplates.ExtendEntityToFood(entity, foodInfo);

			ComplexRecipe.RecipeElement[] ingredients = new[] { new ComplexRecipe.RecipeElement(BasicPlantBarConfig.ID, 1f) };
			ComplexRecipe.RecipeElement[] results = new[] { new ComplexRecipe.RecipeElement(FriedLiceloafConfig.Id, 1f) };
			var recipeId = ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, ingredients, results);
			Recipe = new ComplexRecipe(recipeId, ingredients, results)
			{
				time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME,
				description = RecipeDescription,
				nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
				fabricators = new List<Tag> { CookingStationConfig.ID },
				sortOrder = 2,
			};

			return foodEntity;
		}

		public void OnPrefabInit(GameObject inst)
		{
		}

		public void OnSpawn(GameObject inst)
		{
		}
	}
}