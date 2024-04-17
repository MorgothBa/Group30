CREATE DATABASE Moodle_project
GO 
USE Moodle_project
GO

CREATE TABLE users(
  id INT PRIMARY KEY,
  username VARCHAR(255),
  name VARCHAR(255),
  password VARCHAR(255),
  degree_id INT
);

CREATE TABLE courses(
  id INT PRIMARY KEY,
  code VARCHAR(255),
  name VARCHAR(255),
  credit INT
);

CREATE TABLE degrees(
  id INT PRIMARY KEY,
  name VARCHAR(255)
);


CREATE TABLE mycourses(
  id INT PRIMARY KEY,
  user_id INT,
  course_id INT,
  FOREIGN KEY (user_id) REFERENCES users(id),
  FOREIGN KEY (course_id) REFERENCES courses(id)
);



CREATE TABLE approved_degress(
  id INT PRIMARY KEY,
  course_id INT,
  degree_id INT,
  FOREIGN KEY (course_id) REFERENCES courses(id),
  FOREIGN KEY (degree_id) REFERENCES degrees(id)
);

CREATE TABLE events(
  id INT PRIMARY KEY,
  course_id INT,
  name VARCHAR(255),
  description VARCHAR(255),
  FOREIGN KEY (course_id) REFERENCES courses(id)
);

CREATE TABLE departments(
  id INT PRIMARY KEY,
  name VARCHAR(255),
  course_id INT,
  FOREIGN KEY (course_id) REFERENCES courses(id)
);

INSERT INTO users(id, username, name, password, degree_id) VALUES
(1, 'Mik Mak', 'user1', 'jelszo1', 1),
(2, 'Pak Pik', 'user2', 'jelszo2', 2),
(3, 'Lop Lip', 'user3', 'jelszo3', 1),
(4, 'John Doe', 'user4', 'password4', 2),
(5, 'Jane Smith', 'user5', 'password5', 3),
(6, 'Alice Wonderland', 'user6', 'password6', 1),
(7, 'Bob Builder', 'user7', 'password7', 2),
(8, 'Eva Green', 'user8', 'password8', 1),
(9, 'Max Mustermann', 'user9', 'password9', 3),
(10, 'Laura Brown', 'user10', 'password10', 1),
(11, 'David Johnson', 'user111', 'password111', 2);

INSERT INTO courses(id, code, name, credit) VALUES
(1, 'INF101', 'Bevezetés az Informatikába', 3),
(2, 'MAG201', 'Magyar Irodalom', 3),
(3, 'FIZ301', 'Haladó Matematika', 4),
(4, 'HIS401', 'Történelem', 3),
(5, 'BIO501', 'Biológia', 4),
(6, 'ENG601', 'Angol Nyelv', 3),
(7, 'ART701', 'Képzőművészet', 2),
(8, 'CHE801', 'Kémia', 4),
(9, 'PHYS901', 'Fizika', 4),
(10, 'GEO101', 'Földrajz', 3),
(11, 'ECO201', 'Gazdaságtan', 3);

INSERT INTO degrees(id, name) VALUES
(1, 'Informatika'),
(2, 'Irodalom'),
(3, 'Matematika'),
(4, 'Történelem'),
(5, 'Biológia'),
(6, 'Angol Nyelv'),
(7, 'Képzőművészet'),
(8, 'Kémia'),
(9, 'Fizika'),
(10, 'Földrajz'),
(11, 'Gazdaságtan');

INSERT INTO mycourses(id, user_id, course_id) VALUES
(1, 1, 1),
(2, 2, 2),
(3, 1, 3),
(4, 3, 4),
(5, 4, 5),
(6, 5, 6),
(7, 6, 7),
(8, 7, 8),
(9, 8, 9),
(10, 9, 10),
(11, 10, 11);

INSERT INTO approved_degress(id, course_id, degree_id) VALUES
(1, 1, 1),
(2, 2, 2),
(3, 3, 1),
(4, 4, 4),
(5, 5, 5),
(6, 6, 6),
(7, 7, 7),
(8, 8, 8),
(9, 9, 9),
(10, 10, 10),
(11, 11, 11);

INSERT INTO events(id, course_id, name, description) VALUES
(1, 1, 'Bevezető előadás', 'Az adatbázisok alapjai előadás'),
(2, 2, 'Gyakorlati feladatok', 'SQL lekérdezések megoldása'),
(3, 3, 'Vizsga', 'Az adatbázisok vizsgája'),
(4, 4, 'Előadás', 'A reneszánsz művészet jellemzői'),
(5, 5, 'Laboratóriumi gyakorlat', 'Kémiai kísérletek végrehajtása'),
(6, 6, 'Demonstráció', 'Newton törvényeinek bemutatása'),
(7, 7, 'Terepgyakorlat', 'Folyók és hegységek vizsgálata'),
(8, 8, 'Gazdasági elemzés', 'Különböző piaci struktúrák vizsgálata'),
(9, 9, 'Laboratóriumi mérés', 'Hőmérséklet és nyomás mérése'),
(10, 10, 'Földrajzi expedíció', 'Expedíció a trópusi esőerdőbe'),
(11, 11, 'Kerekasztal-beszélgetés', 'Környezeti kihívások megbeszélése');

INSERT INTO departments(id, name, course_id) VALUES
(1, 'Informatikai Tanszék', 1),
(2, 'Irodalom Tanszék', 2),
(3, 'Matematikai Tanszék', 3),
(4, 'Történelem Tanszék', 4),
(5, 'Biológiai Tanszék', 5),
(6, 'Angol Nyelv Tanszék', 6),
(7, 'Képzőművészet Tanszék', 7),
(8, 'Kémia Tanszék', 8),
(9, 'Fizika Tanszék', 9),
(10, 'Földrajz Tanszék', 10),
(11, 'Gazdaságtan Tanszék', 11);
