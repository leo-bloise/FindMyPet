CREATE TABLE IF NOT EXISTS "users" (
    id SERIAL PRIMARY KEY,
    telephone VARCHAR(11) NOT NULL UNIQUE,
    name TEXT NOT NULL,
    password TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);