#!/bin/bash
# This script bootstraps the database
export ACCEPT_EULA='Y'
set -e

# Accept end user agreement & proceed after 30 seconds giving the database time to start up completely.
/opt/mssql/bin/sqlservr --accept-eula & sleep 30

echo "Start: Executing Create Database"
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "YourStrong!Passw0rd" -C -Q  "CREATE DATABASE TeamMapper;"
echo "End: Executing Create Database"

echo "Database Initialization Completed Successfully."

# Keep container running
tail -f /dev/null
