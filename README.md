demo-mvc

Entity Framework Core Tools: Install-Package Microsoft.EntityFrameworkCore.Tools

Pomelo MySQL provider for Entity Framework: Install-Package Pomelo.EntityFrameworkCore.MySql2

dotnet ef dbcontext scaffold "server=localhost;port=3306;database=demo-mvc;uid=root;password=pwd" "Pomelo.EntityFrameworkCore.MySql"  --context DemoMVCDbContext --context-dir Context  --output-dir Models --use-database-names --force --project demo-mvc

Swagger Gen Doc:  Install-Package Swashbuckle.AspNetCore


CREATE DATABASE db_demo;

CREATE TABLE `user` (
  `user_id` varchar(36) NOT NULL,
  `is_enable` tinyint(1) NOT NULL,
  `date_create` datetime NOT NULL,
  `date_update` datetime DEFAULT NULL,
  `username` varchar(255) NOT NULL,
  `pwd` varchar(255) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `phone_number` varchar(50) DEFAULT NULL,
  `role_id` varchar(30) NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `user_id_UNIQUE` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
