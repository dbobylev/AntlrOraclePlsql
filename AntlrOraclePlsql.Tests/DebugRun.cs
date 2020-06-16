using Antlr4.Runtime.Tree;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntlrOraclePlsql.Tests
{
    class DebugRun
    {
        [Test]
		[Category("Debug runs")]
		[Ignore("Not a test")]
		public static void PrintTree()
        {
			var sql = ScriptSource.DebugPrint;
			var context = Analyzer.RunUpperCase(sql.Path());
			PrintChilds(context);
		}

		public static void PrintChilds(IParseTree tree, int indent = 0)
		{
			string pad = new string(Enumerable.Range(0, indent).Select(x => ' ').ToArray());
			string TypeName = tree.GetType().Name;
			string txt = string.Empty;
			if (tree is TerminalNodeImpl treeTNI)
				txt = $" : {treeTNI.Symbol.Text}";
			Console.WriteLine($"{pad}{TypeName}{txt}");

			int c = tree.ChildCount;

			for (int i = 0; i < c; i++)
			{
				PrintChilds(tree.GetChild(i), indent + 2);
			}
		}
	}
}
