//	Copyright © 2017, EPSITEC SA, CH-1400 Yverdon-les-Bains, Switzerland
//	Author: Pierre ARNAUD, Maintainer: Pierre ARNAUD

using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace ScriptLab
{
	public static class ScriptCompiler
	{
		public static System.Func<T> Compile<T>(string source, object globals)
		{
			var options = ScriptOptions.Default;
			var script = CSharpScript.Create<T> (source, options: options, globalsType: globals.GetType ());
			var runner = script.CreateDelegate ();
			return () => runner (globals).Result;
		}
	}
}
