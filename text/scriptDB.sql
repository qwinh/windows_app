create database library
use library;

-- ============================================
-- LIBRARY MANAGEMENT SYSTEM
-- SQL Server 2022
-- ============================================

-- genres
CREATE TABLE genres (
    id          INT             IDENTITY(1,1)   PRIMARY KEY,
    name        NVARCHAR(100)   NOT NULL        UNIQUE,
    description NVARCHAR(500)   NULL
);

-- authors
CREATE TABLE authors (
    id          INT             IDENTITY(1,1)   PRIMARY KEY,
    name        NVARCHAR(200)   NOT NULL,
    description NVARCHAR(1000)  NULL,
    date_birth  DATE            NULL,
    date_death  DATE            NULL
);

-- books.formal
CREATE TABLE books_formal (
    id           INT             IDENTITY(1,1)   PRIMARY KEY,
    name         NVARCHAR(300)   NOT NULL,
    date_publish DATE            NULL
);

-- books.formal-authors  (junction)
CREATE TABLE books_formal_authors (
    books_formal_id INT NOT NULL    REFERENCES books_formal(id),
    authors_id      INT NOT NULL    REFERENCES authors(id),
    PRIMARY KEY (books_formal_id, authors_id)
);

-- books.formal-genres  (junction)
CREATE TABLE books_formal_genres (
    books_formal_id INT NOT NULL    REFERENCES books_formal(id),
    genres_id       INT NOT NULL    REFERENCES genres(id),
    PRIMARY KEY (books_formal_id, genres_id)
);

-- books.actual  (physical copies)
CREATE TABLE books_actual (
    id              INT             IDENTITY(1,1)   PRIMARY KEY,
    books_formal_id INT             NOT NULL        REFERENCES books_formal(id),
    date_create     DATETIME2       NOT NULL        DEFAULT SYSDATETIME(),
    integrity       TINYINT         NOT NULL        DEFAULT 5
                                    CHECK (integrity BETWEEN 1 AND 5)
);

-- employees
CREATE TABLE employees (
    id          INT             IDENTITY(1,1)   PRIMARY KEY,
    name        NVARCHAR(200)   NOT NULL,
    email       NVARCHAR(254)   NOT NULL        UNIQUE,
    pass        NVARCHAR(256)   NOT NULL,               -- store hashed
    phone       NVARCHAR(20)    NULL,
    address     NVARCHAR(500)   NULL,
    date_create DATETIME2       NOT NULL        DEFAULT SYSDATETIME(),
    status      TINYINT         NOT NULL        DEFAULT 1   -- 1=active, 0=inactive
);

-- readers
CREATE TABLE readers (
    id          INT             IDENTITY(1,1)   PRIMARY KEY,
    name        NVARCHAR(200)   NOT NULL,
    email       NVARCHAR(254)   NULL            UNIQUE,
    phone       NVARCHAR(20)    NULL,
    address     NVARCHAR(500)   NULL,
    date_create DATETIME2       NOT NULL        DEFAULT SYSDATETIME(),
    date_expire DATE            NULL,
    integrity   TINYINT         NOT NULL        DEFAULT 5
                                CHECK (integrity BETWEEN 1 AND 5)
);

-- borrows
CREATE TABLE borrows (
    id              INT         IDENTITY(1,1)   PRIMARY KEY,
    readers_id      INT         NOT NULL        REFERENCES readers(id),
    books_actual_id INT         NOT NULL        REFERENCES books_actual(id),
    employees_id    INT         NOT NULL        REFERENCES employees(id),
    date_create     DATETIME2   NOT NULL        DEFAULT SYSDATETIME(),
    date_expire     DATETIME2   NOT NULL,
    date_return     DATETIME2   NULL            -- NULL = not yet returned
);

-- ============================================
-- INDEXES
-- ============================================

CREATE INDEX IX_books_actual_formal     ON books_actual (books_formal_id);
CREATE INDEX IX_borrows_reader          ON borrows (readers_id);
CREATE INDEX IX_borrows_book            ON borrows (books_actual_id);
CREATE INDEX IX_borrows_employee        ON borrows (employees_id);
CREATE INDEX IX_borrows_date_expire     ON borrows (date_expire) WHERE date_return IS NULL;
CREATE INDEX IX_readers_email           ON readers (email) WHERE email IS NOT NULL;




-- Insert Genres
INSERT INTO genres (name, description) VALUES
    ('Fiction', 'Literary works based on imagination, not facts.'),
    ('Science Fiction', 'Speculative fiction dealing with futuristic concepts, science, and technology.'),
    ('Fantasy', 'Fiction involving magic, supernatural elements, or imaginary worlds.'),
    ('Mystery', 'Fiction dealing with the solution of a crime or puzzle.'),
    ('Biography', 'Account of a person''s life written by someone else.'),
    ('History', 'Study of past events, particularly in human affairs.'),
    ('Non-fiction', 'Informative works based on facts and reality.');

-- Insert Authors
INSERT INTO authors (name, description, date_birth, date_death) VALUES
    ('Isaac Asimov', 'Prolific American writer and biochemist, best known for science fiction and popular science books.', '1920-01-02', '1992-04-06'),
    ('Arthur C. Clarke', 'British science fiction writer, futurist, and inventor.', '1917-12-16', '2008-03-19'),
    ('J.R.R. Tolkien', 'English writer, poet, and philologist, author of The Hobbit and The Lord of the Rings.', '1892-01-03', '1973-09-02'),
    ('Agatha Christie', 'English writer known for her 66 detective novels and 14 short story collections.', '1890-09-15', '1976-01-12'),
    ('Yuval Noah Harari', 'Israeli historian and professor, author of Sapiens: A Brief History of Humankind.', '1976-02-24', NULL),
    ('George Orwell', 'English novelist, essayist, and critic, famous for Nineteen Eighty-Four and Animal Farm.', '1903-06-25', '1950-01-21'),
    ('J.K. Rowling', 'British author, best known for the Harry Potter fantasy series.', '1965-07-31', NULL);

-- Insert Formal Books
INSERT INTO books_formal (name, date_publish) VALUES
    ('Foundation', '1951-06-01'),
    ('2001: A Space Odyssey', '1968-07-01'),
    ('The Hobbit', '1937-09-21'),
    ('Murder on the Orient Express', '1934-01-01'),
    ('Sapiens: A Brief History of Humankind', '2011-02-04'),
    ('Nineteen Eighty-Four', '1949-06-08'),
    ('Harry Potter and the Philosopher''s Stone', '1997-06-26'),
    ('The Lord of the Rings', '1954-07-29'),
    ('I, Robot', '1950-12-02'),
    ('The Murder of Roger Ackroyd', '1926-06-19');

-- Link Books to Authors (books_formal_authors)
-- Foundation (id=1) -> Isaac Asimov (id=1)
INSERT INTO books_formal_authors (books_formal_id, authors_id) VALUES (1, 1);
-- 2001 (id=2) -> Arthur C. Clarke (id=2)
INSERT INTO books_formal_authors (books_formal_id, authors_id) VALUES (2, 2);
-- The Hobbit (id=3) -> J.R.R. Tolkien (id=3)
INSERT INTO books_formal_authors (books_formal_id, authors_id) VALUES (3, 3);
-- Murder on the Orient Express (id=4) -> Agatha Christie (id=4)
INSERT INTO books_formal_authors (books_formal_id, authors_id) VALUES (4, 4);
-- Sapiens (id=5) -> Yuval Noah Harari (id=5)
INSERT INTO books_formal_authors (books_formal_id, authors_id) VALUES (5, 5);
-- Nineteen Eighty-Four (id=6) -> George Orwell (id=6)
INSERT INTO books_formal_authors (books_formal_id, authors_id) VALUES (6, 6);
-- Harry Potter (id=7) -> J.K. Rowling (id=7)
INSERT INTO books_formal_authors (books_formal_id, authors_id) VALUES (7, 7);
-- The Lord of the Rings (id=8) -> J.R.R. Tolkien (id=3)
INSERT INTO books_formal_authors (books_formal_id, authors_id) VALUES (8, 3);
-- I, Robot (id=9) -> Isaac Asimov (id=1)
INSERT INTO books_formal_authors (books_formal_id, authors_id) VALUES (9, 1);
-- The Murder of Roger Ackroyd (id=10) -> Agatha Christie (id=4)
INSERT INTO books_formal_authors (books_formal_id, authors_id) VALUES (10, 4);

-- Link Books to Genres (books_formal_genres)
-- Foundation: Science Fiction (id=2)
INSERT INTO books_formal_genres (books_formal_id, genres_id) VALUES (1, 2);
-- 2001: Science Fiction (id=2)
INSERT INTO books_formal_genres (books_formal_id, genres_id) VALUES (2, 2);
-- The Hobbit: Fantasy (id=3), Fiction (id=1)
INSERT INTO books_formal_genres (books_formal_id, genres_id) VALUES (3, 3), (3, 1);
-- Murder on the Orient Express: Mystery (id=4), Fiction (id=1)
INSERT INTO books_formal_genres (books_formal_id, genres_id) VALUES (4, 4), (4, 1);
-- Sapiens: History (id=6), Non-fiction (id=7)
INSERT INTO books_formal_genres (books_formal_id, genres_id) VALUES (5, 6), (5, 7);
-- Nineteen Eighty-Four: Fiction (id=1), Science Fiction (id=2)
INSERT INTO books_formal_genres (books_formal_id, genres_id) VALUES (6, 1), (6, 2);
-- Harry Potter: Fantasy (id=3), Fiction (id=1)
INSERT INTO books_formal_genres (books_formal_id, genres_id) VALUES (7, 3), (7, 1);
-- The Lord of the Rings: Fantasy (id=3), Fiction (id=1)
INSERT INTO books_formal_genres (books_formal_id, genres_id) VALUES (8, 3), (8, 1);
-- I, Robot: Science Fiction (id=2)
INSERT INTO books_formal_genres (books_formal_id, genres_id) VALUES (9, 2);
-- The Murder of Roger Ackroyd: Mystery (id=4), Fiction (id=1)
INSERT INTO books_formal_genres (books_formal_id, genres_id) VALUES (10, 4), (10, 1);

-- Insert Physical Copies (books_actual) - 2 to 3 copies per book
-- For Foundation (id=1)
INSERT INTO books_actual (books_formal_id, integrity) VALUES (1, 5), (1, 4), (1, 5);
-- For 2001 (id=2)
INSERT INTO books_actual (books_formal_id, integrity) VALUES (2, 5), (2, 5);
-- For The Hobbit (id=3)
INSERT INTO books_actual (books_formal_id, integrity) VALUES (3, 4), (3, 3), (3, 5);
-- For Murder on the Orient Express (id=4)
INSERT INTO books_actual (books_formal_id, integrity) VALUES (4, 5), (4, 5);
-- For Sapiens (id=5)
INSERT INTO books_actual (books_formal_id, integrity) VALUES (5, 5), (5, 4), (5, 5);
-- For Nineteen Eighty-Four (id=6)
INSERT INTO books_actual (books_formal_id, integrity) VALUES (6, 3), (6, 4);
-- For Harry Potter (id=7)
INSERT INTO books_actual (books_formal_id, integrity) VALUES (7, 5), (7, 5), (7, 5);
-- For The Lord of the Rings (id=8)
INSERT INTO books_actual (books_formal_id, integrity) VALUES (8, 5), (8, 4);
-- For I, Robot (id=9)
INSERT INTO books_actual (books_formal_id, integrity) VALUES (9, 5), (9, 5);
-- For The Murder of Roger Ackroyd (id=10)
INSERT INTO books_actual (books_formal_id, integrity) VALUES (10, 5), (10, 4);

-- Insert Employees (passwords are placeholders – in real system these would be hashed)
INSERT INTO employees (name, email, pass, phone, address, status) VALUES
    ('John Smith', 'john.smith@library.com', '$2a$10$hashedpasswordexample1', '+1-555-0100', '123 Main St, Anytown, USA', 1),
    ('Jane Doe', 'jane.doe@library.com', '$2a$10$hashedpasswordexample2', '+1-555-0101', '456 Oak Ave, Anytown, USA', 1),
    ('Robert Johnson', 'robert.johnson@library.com', '$2a$10$hashedpasswordexample3', '+1-555-0102', '789 Pine Rd, Anytown, USA', 1),
    ('Emily Davis', 'emily.davis@library.com', '$2a$10$hashedpasswordexample4', '+1-555-0103', '321 Elm St, Anytown, USA', 1);

-- Insert Readers
INSERT INTO readers (name, email, phone, address, date_expire, integrity) VALUES
    ('Alice Brown', 'alice.brown@email.com', '+1-555-0200', '111 Cedar Ln, Anytown, USA', DATEADD(YEAR, 1, GETDATE()), 5),
    ('Bob White', 'bob.white@email.com', '+1-555-0201', '222 Birch Dr, Anytown, USA', DATEADD(YEAR, 1, GETDATE()), 4),
    ('Carol Green', 'carol.green@email.com', '+1-555-0202', '333 Maple Ave, Anytown, USA', DATEADD(YEAR, 1, GETDATE()), 5),
    ('David Black', 'david.black@email.com', '+1-555-0203', '444 Spruce Ct, Anytown, USA', DATEADD(YEAR, 1, GETDATE()), 3),
    ('Eva Grey', 'eva.grey@email.com', '+1-555-0204', '555 Willow Way, Anytown, USA', DATEADD(YEAR, 1, GETDATE()), 5),
    ('Frank Miller', 'frank.miller@email.com', '+1-555-0205', '666 Poplar St, Anytown, USA', DATEADD(YEAR, 1, GETDATE()), 5),
    ('Grace Lee', 'grace.lee@email.com', '+1-555-0206', '777 Ash Blvd, Anytown, USA', DATEADD(YEAR, 1, GETDATE()), 4);

-- Insert Borrows (mix of returned and active)
-- We'll use specific dates for consistency
-- Assumptions:
--   books_actual ids: 1-3 (Foundation), 4-5 (2001), 6-8 (Hobbit), 9-10 (Orient Express), 11-13 (Sapiens),
--                     14-15 (1984), 16-18 (Harry Potter), 19-20 (LOTR), 21-22 (I, Robot), 23-24 (Roger Ackroyd)
--   employees ids: 1-4
--   readers ids: 1-7

-- Borrow 1: Alice Brown (reader 1) borrows Foundation copy 1 (book_actual 1) on 2023-01-15, due 2023-01-29, returned 2023-01-28
INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
VALUES (1, 1, 1, '2023-01-15 10:30:00', '2023-01-29 10:30:00', '2023-01-28 14:20:00');

-- Borrow 2: Bob White (reader 2) borrows 2001 copy 1 (book_actual 4) on 2023-02-01, due 2023-02-15, returned 2023-02-14
INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
VALUES (2, 4, 2, '2023-02-01 09:15:00', '2023-02-15 09:15:00', '2023-02-14 16:45:00');

-- Borrow 3: Carol Green (reader 3) borrows The Hobbit copy 1 (book_actual 6) on 2023-03-10, due 2023-03-24, not returned yet
INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
VALUES (3, 6, 3, '2023-03-10 14:00:00', '2023-03-24 14:00:00', NULL);

-- Borrow 4: David Black (reader 4) borrows Murder on the Orient Express copy 1 (book_actual 9) on 2023-04-05, due 2023-04-19, returned 2023-04-18
INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
VALUES (4, 9, 1, '2023-04-05 11:20:00', '2023-04-19 11:20:00', '2023-04-18 10:10:00');

-- Borrow 5: Eva Grey (reader 5) borrows Sapiens copy 1 (book_actual 11) on 2023-05-12, due 2023-05-26, returned 2023-05-25
INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
VALUES (5, 11, 4, '2023-05-12 13:45:00', '2023-05-26 13:45:00', '2023-05-25 12:30:00');

-- Borrow 6: Frank Miller (reader 6) borrows Nineteen Eighty-Four copy 1 (book_actual 14) on 2023-06-20, due 2023-07-04, not returned
INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
VALUES (6, 14, 2, '2023-06-20 16:00:00', '2023-07-04 16:00:00', NULL);

-- Borrow 7: Grace Lee (reader 7) borrows Harry Potter copy 1 (book_actual 16) on 2023-07-18, due 2023-08-01, returned 2023-07-30
INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
VALUES (7, 16, 3, '2023-07-18 10:00:00', '2023-08-01 10:00:00', '2023-07-30 15:15:00');

-- Borrow 8: Alice Brown (reader 1) borrows The Lord of the Rings copy 1 (book_actual 19) on 2023-08-25, due 2023-09-08, not returned
INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
VALUES (1, 19, 1, '2023-08-25 09:30:00', '2023-09-08 09:30:00', NULL);

-- Borrow 9: Bob White (reader 2) borrows I, Robot copy 1 (book_actual 21) on 2023-09-14, due 2023-09-28, returned 2023-09-27
INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
VALUES (2, 21, 4, '2023-09-14 12:00:00', '2023-09-28 12:00:00', '2023-09-27 17:20:00');

-- Borrow 10: Carol Green (reader 3) borrows The Murder of Roger Ackroyd copy 1 (book_actual 23) on 2023-10-01, due 2023-10-15, not returned
INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
VALUES (3, 23, 2, '2023-10-01 11:00:00', '2023-10-15 11:00:00', NULL);

-- Borrow 11: David Black (reader 4) borrows Foundation copy 2 (book_actual 2) on 2023-10-20, due 2023-11-03, returned 2023-11-02
INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
VALUES (4, 2, 3, '2023-10-20 15:30:00', '2023-11-03 15:30:00', '2023-11-02 14:10:00');

-- Borrow 12: Eva Grey (reader 5) borrows 2001 copy 2 (book_actual 5) on 2023-11-15, due 2023-11-29, not returned
INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
VALUES (5, 5, 1, '2023-11-15 10:45:00', '2023-11-29 10:45:00', NULL);

-- Borrow 13: Frank Miller (reader 6) borrows The Hobbit copy 2 (book_actual 7) on 2023-12-05, due 2023-12-19, not returned (overdue example)
INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
VALUES (6, 7, 4, '2023-12-05 14:20:00', '2023-12-19 14:20:00', NULL);

-- Borrow 14: Grace Lee (reader 7) borrows Sapiens copy 2 (book_actual 12) on 2023-12-10, due 2023-12-24, not returned
INSERT INTO borrows (readers_id, books_actual_id, employees_id, date_create, date_expire, date_return)
VALUES (7, 12, 2, '2023-12-10 09:00:00', '2023-12-24 09:00:00', NULL);

-- ============================================
-- END OF SEED DATA
-- ============================================