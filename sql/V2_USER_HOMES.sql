CREATE TABLE IF NOT EXISTS homes (
    id SERIAL PRIMARY KEY,
    user_id INTEGER NOT NULL REFERENCES users(id),
    location GEOMETRY(Point, 4326)
);