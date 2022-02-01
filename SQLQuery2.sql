INSERT INTO Ingredients
VALUES
('Eggs'),
('Milk'),
('Sugar'),
('Butter');

INSERT INTO RecipeIngredients
VALUES
(1, 2, '500ml'),
(1, 3, '500g'),
(2, 1, '5'),
(2, 2, '500ml'),
(3, 4, '200g'),
(4, 3, '250g');

select * from RecipeIngredients;

select r.Id, count(ri.IngredientId) as "IngredientsNo"
from Recipes r 
left join RecipeIngredients ri on r.Id = ri.RecipeId
group by r.Id
having count(ri.IngredientId) > 0;
