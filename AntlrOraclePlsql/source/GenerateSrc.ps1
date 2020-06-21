$LETTERS_ORIGINAL = 'fragment SIMPLE_LETTER  : [A-Z];'
$LETTERS_EXTENDED = 'fragment SIMPLE_LETTER  : [A-ZА-Я];'
$LEXERCLASSNAME_OLD1 = 'PlSqlLexer('
$LEXERCLASSNAME_OLD2 = 'PlSqlLexer '
$LEXERCLASSNAME_NEW1 = 'PlSqlLexerCharsExtend('
$LEXERCLASSNAME_NEW2 = 'PlSqlLexerCharsExtend '

Write-Host Download antlr-4.8-complete.jar if not exists
if(![System.IO.File]::Exists(".\antlr-4.8-complete.jar"))
{
  Invoke-WebRequest https://www.antlr.org/download/antlr-4.8-complete.jar -OutFile .\antlr-4.8-complete.jar
}

Write-Host Update SIMPLE_LETTER in grammar
(Get-Content .\PlSqlLexer.g4).replace($LETTERS_ORIGINAL, $LETTERS_EXTENDED) | Set-Content .\PlSqlLexer.g4

Write-Host Compile Extended Lexer grammar
java -jar .\antlr-4.8-complete.jar -encoding utf-8 -Dlanguage=CSharp -o ..\src\ -package AntlrOraclePlsql .\PlSqlLexer.g4

Write-Host Update classname in new file
(Get-Content ..\src\PlSqlLexer.cs).replace($LEXERCLASSNAME_OLD1, $LEXERCLASSNAME_NEW1) | Set-Content ..\src\PlSqlLexer.cs
(Get-Content ..\src\PlSqlLexer.cs).replace($LEXERCLASSNAME_OLD2, $LEXERCLASSNAME_NEW2) | Set-Content ..\src\PlSqlLexer.cs

Write-Host Rename extended PlSqlLexer
if([System.IO.File]::Exists("..\src\PlSqlLexerCharsExtend.cs"))
{
  del ..\src\PlSqlLexerCharsExtend.cs
}
Rename-Item -Path '..\src\PlSqlLexer.cs' -NewName 'PlSqlLexerCharsExtend.cs' -Force 

Write-Host Rollback SIMPLE_LETTER in grammar
(Get-Content .\PlSqlLexer.g4).replace($LETTERS_EXTENDED, $LETTERS_ORIGINAL) | Set-Content .\PlSqlLexer.g4

Write-Host Compile Original Lexer grammar
java -jar .\antlr-4.8-complete.jar -encoding utf-8 -Dlanguage=CSharp -o ..\src\ -package AntlrOraclePlsql .\PlSqlLexer.g4

Write-Host Compile Parser
java -jar .\antlr-4.8-complete.jar -encoding utf-8 -Dlanguage=CSharp -o ..\src\ -package AntlrOraclePlsql -visitor .\PlSqlParser.g4

Write-Host Drop temp files
del ..\src\*.tokens
del ..\src\*.interp
# *.jar

Read-Host -Prompt "Press Enter to exit"