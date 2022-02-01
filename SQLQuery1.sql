INSERT INTO Products 
VALUES ('Donuts', 'A classic delicious', '2022-01-07', '2022-01-10', 5);

INSERT INTO Products 
VALUES ('Pancakes', 'An American delight', '2022-01-10', '2022-01-13', 7);

INSERT INTO Products 
VALUES ('Tebirkes', 'A Danish pastry with poppy seeds', '2022-01-05', '2022-01-09', 4);

INSERT INTO Products 
VALUES ('Kanelbullar', 'Swedish Cinnamon Buns', '2022-01-03', '2022-01-06', 4);

INSERT INTO Clients
VALUES ('Abby', 'Kennedy', '+1 202-918-2132'),
('Felix', 'Cooper', '+1 582-333-4876'),
('Lucy', 'Dawson', '+1 205-750-7614'),
('Jessie', 'Moore', '+1 223-780-9673');

INSERT INTO Orders
VALUES (75, 1), 
(50, 2),
(22, 3),
(34, 4);

INSERT INTO OrderProducts
VALUES
(1, 4),
(2, 5),
(1, 1),
(3, 6);

INSERT INTO OrderProducts
VALUES
(3, 5);

INSERT INTO OrderProducts
VALUES
(2, 1);

INSERT INTO Recipes
VALUES
(60, 200, 1),
(45, 180, 4),
(70, 220, 5),
(60, 195, 6);



SELECT * 
FROM Products;
