-- // * PROFILE

-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );


-- // * PROFILES

-- CREATE TABLE posts
-- (
--     id INT NOT NULL AUTO_INCREMENT,
--     creatorId VARCHAR(255) NOT NULL,
--     title VARCHAR(255) NOT NULL,
--     body VARCHAR(255) NOT NULL,
--     img VARCHAR (255),
--     views INT DEFAULT 0,
--     shares INT DEFAULT 0,
--     saves INT DEFAULT 0,

--     PRIMARY KEY (id),

--     FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
-- );

-- // * COMMENTS

-- CREATE TABLE comments
-- (
--     id INT NOT NULL AUTO_INCREMENT,
--     creatorId VARCHAR(255) NOT NULL,
--     body VARCHAR(255) NOT NULL,
--     likes INT DEFAULT 0,
--     postId INT NOT NULL,


--     PRIMARY KEY (id),

--     FOREIGN KEY (creatorId)
--     REFERENCES profiles (id),

--     FOREIGN KEY (postId)
--     REFERENCES posts (id)
-- );


-- SELECT * FROM posts;
-- SELECT * FROM profiles;
-- SELECT * FROM comments;


-- INSERT INTO posts
-- (title, body, img, views, shares, saves, creatorId)
-- VALUES
-- ("Test Post", "this is the test Body")