using FenixAlliance.ABS.SDK.Resources;

using Microsoft.Extensions.Localization;

using System.Reflection;

namespace FenixAlliance.ABS.SDK.Resources
{
	public class SharedViewLocalizer
	{
		private readonly IStringLocalizer _localizer;

		public SharedViewLocalizer(IStringLocalizerFactory factory)
		{
			var type = typeof(SharedResources);
			var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
			//_localizer = factory.Create(typeof(PortalResources));
			_localizer = factory.Create("PortalResources", assemblyName.Name);
			var strings = _localizer.GetAllStrings();
		}

		public LocalizedString this[string key] => _localizer[key];

		public LocalizedString GetLocalizedString(string key)
		{
			return _localizer[key];
		}
	}
}
