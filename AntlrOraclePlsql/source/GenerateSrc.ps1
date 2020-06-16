if(![System.IO.File]::Exists(".\antlr-4.8-complete.jar"))
{
  Invoke-WebRequest https://www.antlr.org/download/antlr-4.8-complete.jar -OutFile .\antlr-4.8-complete.jar
}
java -jar .\antlr-4.8-complete.jar -Dlanguage=CSharp -o ..\src\ -package AntlrOraclePlsql .\PlSqlLexer.g4
java -jar .\antlr-4.8-complete.jar -Dlanguage=CSharp -o ..\src\ -package AntlrOraclePlsql -visitor .\PlSqlParser.g4
del ..\src\*.tokens
del ..\src\*.interp
#del *.jar