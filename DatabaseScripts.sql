CREATE TABLE customers (
    id serial NOT NULL,
    name varchar(80) NOT NULL,
    cpf varchar NOT NULL,
    code varchar(100),
    address varchar,
    phone varchar,
    CONSTRAINT customers_pk PRIMARY KEY (id)
) WITH (OIDS=FALSE);

CREATE TABLE sessions (
    id serial NOT NULL,
    user_id integer NOT NULL,
    token varchar(255) NOT NULL UNIQUE,
    active BOOLEAN NOT NULL DEFAULT true,
    CONSTRAINT sessions_pk PRIMARY KEY (id)
) WITH (OIDS=FALSE);

CREATE TABLE users (
    id serial NOT NULL,
    name varchar NOT NULL UNIQUE,
    password varchar NOT NULL,
    CONSTRAINT users_pk PRIMARY KEY (id)
) WITH (OIDS=FALSE);


ALTER TABLE sessions ADD CONSTRAINT sessions_fk0 FOREIGN KEY (user_id) REFERENCES users(id);

INSERT INTO users (name, password) VALUES ('SISTEMA', 'candidato123');