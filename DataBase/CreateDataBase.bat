echo off
sqlcmd -s localhost -E -i ResturantDataBase.sql
Echo .
Echo if no error message appear DB was created
Pause