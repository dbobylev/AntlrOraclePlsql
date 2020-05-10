#!/bin/bash
wget -O antlr-4.8-complete.jar 'https://www.antlr.org/download/antlr-4.8-complete.jar'
java -jar antlr-4.8-complete.jar -Dlanguage=CSharp -o "./../src/" -package "AntlrOraclePlsql" PlSqlLexer.g4
java -jar antlr-4.8-complete.jar -Dlanguage=CSharp -o "./../src/" -package "AntlrOraclePlsql" -visitor PlSqlParser.g4
rm ./../src/*.tokens
rm ./../src/*.interp
rm ./*.jar
