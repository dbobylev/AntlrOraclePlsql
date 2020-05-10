## An ANTLR 4.8 grammar for PL/SQL (11g) as dotnet library

### Getting started

Use the **Analyzer** class to get the tree root of parsed PL/SQL source file. Create your own application to recognize the parsed tree.
+ [Start with C#](https://github.com/antlr/antlr4/blob/master/doc/csharp-target.md)
+ [ANTLR 4 Documentation](https://github.com/antlr/antlr4/blob/master/doc/index.md)

### Usage, important note

As SQL grammar are normally not case sensitive but this grammar implementation is, you must use a custom [character stream](https://github.com/antlr/antlr4/blob/master/runtime/Java/src/org/antlr/v4/runtime/CharStream.java) that converts all characters to uppercase before sending them to the lexer.
You could find more information [here](https://github.com/antlr/antlr4/blob/master/doc/case-insensitive-lexing.md#custom-character-streams-approach) with implementations for various target languages.

### Grammer and C# source

The C# source was generated from \*.g4 grammer files with ANTLR 4.8 tool. 
Original PL/SQL grammar can be found [here](https://github.com/antlr/grammars-v4/tree/master/sql/plsql). Current used version of this grammer is 19-JAN-2020 (PL/SQL 11g)
If you want to rebuild CSharp source run `GenerateSrc.ps1` or `GenerateSrc.sh`

More information about build for C# can be found [here](https://github.com/antlr/antlr4/tree/master/runtime/CSharp)
