﻿/*
 *  Copyright (c) 2014-2015, Facebook, Inc.
 *  All rights reserved.
 *
 *  This source code is licensed under the BSD-style license found in the
 *  LICENSE file in the root directory of this source tree. An additional grant 
 *  of patent rights can be found in the PATENTS file in the same directory.
 */

using Cassette.BundleProcessing;
using Cassette.Scripts;
using React;

namespace Cassette.React
{
	/// <summary>
	/// Handles processing of script bundles in Cassette. Adds a <see cref="BabelCompiler" />
	/// for all .js and .jsx files.
	/// </summary>
	public class BabelBundleProcessor : IBundleProcessor<ScriptBundle>
	{
		private readonly CassetteSettings _settings;
		private readonly IReactEnvironment _environment;

		/// <summary>
		/// Initializes a new instance of the <see cref="BabelBundleProcessor"/> class.
		/// </summary>
		/// <param name="settings">Cassette settings.</param>
		/// <param name="environment">The ReactJS.NET environment</param>
		public BabelBundleProcessor(CassetteSettings settings, IReactEnvironment environment)
		{
			_settings = settings;
			_environment = environment;
		}

		/// <summary>
		/// Processes the specified bundle. Adds a <see cref="BabelCompiler"/> for all files.
		/// </summary>
		/// <param name="bundle">The bundle.</param>
		public void Process(ScriptBundle bundle)
		{
			foreach (var asset in bundle.Assets)
			{
				asset.AddAssetTransformer(
					new CompileAsset(new BabelCompiler(_environment), _settings.SourceDirectory)
				);
			}
		}
	}
}
