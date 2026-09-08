USE db_users;
GO

DROP TABLE tbl_users;
GO

CREATE TABLE tbl_users
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL
);
GO

INSERT INTO tbl_users (username, password)
VALUES ('admin', '12345');
GO

SELECT * FROM tbl_users;