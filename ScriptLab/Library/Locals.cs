//	Copyright © 2017, EPSITEC SA, CH-1400 Yverdon-les-Bains, Switzerland
//	Author: Pierre ARNAUD, Maintainer: Pierre ARNAUD

using System.Threading.Tasks;

namespace ScriptLab
{
	public class Locals
	{
		public Locals()
		{
			this.UniversalConstant = 42m;
		}

		public decimal UniversalConstant { get; }

		public Task<decimal> GetValueAsync(string name) => Task.FromResult (this.UniversalConstant);
	}
}
