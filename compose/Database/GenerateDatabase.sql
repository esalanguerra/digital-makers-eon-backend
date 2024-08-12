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
CREATE DATABASE sotero_eon
    WITH OWNER = admin
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1;

CREATE DATABASE sotero_eon_dev
    WITH OWNER = admin
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1;

CREATE DATABASE sotero_eon_bckp
    WITH OWNER = admin
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1;
