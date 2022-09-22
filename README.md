To be able to work with the NoSQL database, MongoDB needs to be installed.
To generate the NoSQL database, run "./mgodatagen -f config.json" in the terminal in the location of the mgodatagen.exe file.
This will create database "netflix" with tables "profile", "subscription", and "user". Each table will have 1 million randomly generated entries

Folder "orm" contains a python project that works with a python ORM library for a person.sql database. Change the connection information to the database you're using for the sql file.
It requires the PonyORM package and pymysql package.