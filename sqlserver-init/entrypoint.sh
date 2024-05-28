#!/bin/bash
# Start SQL Server in the background
/opt/mssql/bin/sqlservr &

# Wait for SQL Server to start
echo "Waiting for SQL Server to start..."
sleep 20

# Run the initialization script to create databases
echo "Running init script..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -i /init-db.sql

# Keep the container running
wait