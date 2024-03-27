CREATE TABLE `users` (
  `id` integer PRIMARY KEY,
  `username` varchar(255),
  `name` varchar(255),
  `password` varchar(255),
  `degree_id` integer
);

CREATE TABLE `mycourses` (
  `id` integer PRIMARY KEY,
  `user_id` integer,
  `course_id` integer
);

CREATE TABLE `courses` (
  `id` integer PRIMARY KEY,
  `code` varchar(255),
  `name` varchar(255),
  `credit` integer
);

CREATE TABLE `degrees` (
  `id` integer PRIMARY KEY,
  `name` varchar(255)
);

CREATE TABLE `approved_degress` (
  `id` integer PRIMARY KEY,
  `course_id` integer,
  `degree_id` integer
);

CREATE TABLE `events` (
  `id` integer PRIMARY KEY,
  `course_id` integer,
  `name` varchar(255),
  `description` varchar(255)
);

ALTER TABLE `events` ADD FOREIGN KEY (`course_id`) REFERENCES `courses` (`id`);

ALTER TABLE `approved_degress` ADD FOREIGN KEY (`degree_id`) REFERENCES `degrees` (`id`);

ALTER TABLE `approved_degress` ADD FOREIGN KEY (`course_id`) REFERENCES `courses` (`id`);

ALTER TABLE `users` ADD FOREIGN KEY (`degree_id`) REFERENCES `degrees` (`id`);

ALTER TABLE `mycourses` ADD FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

ALTER TABLE `mycourses` ADD FOREIGN KEY (`course_id`) REFERENCES `courses` (`id`);


INSERT INTO users (id, username, name, password, degree_id) VALUES
(1, 'felhasznalo1', 'Teszt Felhasználó 1', 'titkosjelszo1', 1),
(2, 'felhasznalo2', 'Teszt Felhasználó 2', 'titkosjelszo2', 2),
(3, 'felhasznalo3', 'Teszt Felhasználó 3', 'titkosjelszo3', 3),
(4, 'felhasznalo4', 'Teszt Felhasználó 4', 'titkosjelszo4', 1),
(5, 'felhasznalo5', 'Teszt Felhasználó 5', 'titkosjelszo5', 2);

INSERT INTO courses (id, code, name, credit) VALUES
(1, 'INF101', 'Bevezetés az Informatikába', 3),
(2, 'MATH201', 'Lineáris Algebra', 4),
(3, 'PHY301', 'Általános Fizika', 5),
(4, 'CHEM401', 'Kémiai Reakciók Kinetikája', 4),
(5, 'LIT501', 'Világirodalmi Művek Elemzése', 3);

INSERT INTO degrees (id, name) VALUES
(1, 'Informatika'),
(2, 'Matematika'),
(3, 'Fizika'),
(4, 'Kémia'),
(5, 'Irodalom');

INSERT INTO approved_degress (id, course_id, degree_id) VALUES
(1, 1, 1),
(2, 2, 2),
(3, 3, 3),
(4, 4, 4),
(5, 5, 5);

INSERT INTO mycourses (id, user_id, course_id) VALUES
(1, 1, 1),
(2, 2, 2),
(3, 3, 3),
(4, 4, 4),
(5, 5, 5);

INSERT INTO events (id, course_id, name, description) VALUES
(1, 1, 'Algoritmusokról szóló vendégelőadás', 'Különleges előadás kiváló szakértőtől az algoritmusok témájában.'),
(2, 2, 'Matematikai workshop', 'Interaktív műhelymunka az előrehaladott matematikai fogalmak felfedezésére.'),
(3, 3, 'Fizika laboratóriumi foglalkozás', 'Kézzelfogható laboratóriumi foglalkozás az alapvető fizikai kísérletekkel kapcsolatban.'),
(4, 4, 'Kémiatudományi szeminárium', 'Szeminárium a kémiatudomány területén történt legújabb fejleményekről.'),
(5, 5, 'Irodalomolvasás', 'Csoportos olvasás és beszélgetés a klasszikus irodalmi művekről.');
