CREATE TABLE products
(
    Id INT PRIMARY KEY IDENTITY,
    Name varchar(255)
);

CREATE TABLE categories
(
    Id INT PRIMARY KEY IDENTITY,
    Name varchar(255)
);

CREATE TABLE productToCategory
(
    ProductId  INT,
    CategoryId INT,

    CONSTRAINT PK_ProductsInCategories PRIMARY KEY (ProductId, CategoryId),
    CONSTRAINT FK_ProductId FOREIGN KEY (ProductId) REFERENCES products (Id),
    CONSTRAINT FK_CategoryId FOREIGN KEY (CategoryId) REFERENCES categories (Id)
);

INSERT INTO products 
VALUES ('Bread'), ('Milk'), ('Cottege cheese'), ('Protein bar'), ('Pastille'), ('Cookie'), ('Dog food');

INSERT INTO categories
VALUES ('Bakery'), ('Dairy'), ('Sports nutrition'), ('Snacks'), ('Sweets');

INSERT INTO productToCategory
VALUES (1,1), (2,2), (3,2), (4,3), (4,4), (5,4), (5,5), (6,5);

SELECT p.Name, c.Name
FROM products p
    LEFT JOIN productToCategory pc ON p.Id = pc.productId
    LEFT JOIN categories c ON c.Id = pc.categoryId;
