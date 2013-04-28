#region Copyright � 2005 Victor Boctor
//
// Futureware.FxCop.NUnit is copyrighted to Victor Boctor
//
// This program is distributed under the terms and conditions of the GPL
// See LICENSE file for details.
//
// For commercial applications to link with or modify MantisConnect, they require the
// purchase of a MantisConnect commerical license.
//
#endregion

using System;
using System.Diagnostics;
using System.Globalization;

using Microsoft.Cci;
using Microsoft.Tools.FxCop.Sdk;
using Microsoft.Tools.FxCop.Sdk.Introspection;

namespace Futureware.FxCop.NUnit
{
    public sealed class TestFixturesShouldBePublicRule : BaseNUnitRule
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public TestFixturesShouldBePublicRule() : 
            base( "TestFixturesShouldBePublic" )
        {
        }

		public override ProblemCollection Check(TypeNode type)
		{
			if ( IsTestFixture( type.GetRuntimeType() ) && 
				 !type.IsVisibleOutsideAssembly )
			{
				Resolution resolution = GetResolution( type.Name.Name );
				Problem problem = new Problem( resolution );
				base.Problems.Add( problem );
				return base.Problems;
			}

			return base.Check (type);
		}

	}
}
