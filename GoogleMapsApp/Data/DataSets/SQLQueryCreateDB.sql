IF DB_ID('map_markers_bd') IS NULL
    CREATE DATABASE map_markers_bd;

GO
USE map_markers_bd;
GO
CREATE TABLE markers
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(20),
    Latitude FLOAT,
    Longitude FLOAT
);
INSERT INTO markers (Name, Latitude, Longitude) 
VALUES 
('unit1', 54.9807660542823, 82.9124450683594),
('unit2', 55.0114888249396, 83.0662536621094),
('unit3', 55.078367232015156, 83.1129455566406),
('unit3', 55.0429749274252, 82.9673767089844);
