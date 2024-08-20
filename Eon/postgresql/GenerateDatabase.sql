-- .NET SQL Dump
-- version 1.4
-- .Net Version: 4.0.30319.42000
-- https://www.pgadmin.org/docs/pgadmin4/development/import_export_data.html
-- Host: localhost:5432
-- Generation Time: 2024-08-09 12:00:00
-- Server version: 14
-- Database: `sotero_eon`

-- Timezone São Paulo
SET timezone = 'America/Sao_Paulo';

-- Create the databases if they don't exist
CREATE DATABASE digital_makers
    WITH OWNER = digitalmakers
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1;

CREATE DATABASE digital_makers_dev
    WITH OWNER = digitalmakers
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1;

CREATE DATABASE digital_makers_bckp
    WITH OWNER = digitalmakers
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1;

CREATE DATABASE digital_makers_whatsapp
    WITH OWNER = digitalmakers
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1;
