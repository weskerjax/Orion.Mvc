using Orion.API.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Orion.Mvc.UI
{

	/// <summary></summary>
	public interface IMenuProvider
	{
		/// <summary></summary>
		IList<MenuItem> GetList(IPrincipal user, string currentUrl);

		/// <summary></summary>
		IList<MenuItem> GetAllowList(IPrincipal user, string currentUrl);
	}


	/// <summary></summary>
	public class MenuProvider : IMenuProvider
	{
		private IList<MenuItem> _menuList;


		/// <summary></summary>
		public MenuProvider(string configPath)
		{
			var doc = XDocument.Load(configPath);


			/* 用 XSD 驗證 */
			Stream xsdStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Orion.Mvc.UI.menus.xsd");
			var schemas = new XmlSchemaSet();
			schemas.Add("", XmlReader.Create(xsdStream));
			doc.Validate(schemas, (o, e) => { throw new XmlException(e.Message); });


			_menuList = doc.Root.Elements("menu").Select(menu => new MenuItem
			{
				Name    = attr(menu, "name"),
				Url     = attr(menu, "url"),
				Target  = attr(menu, "target"),
				ACT     = attr(menu, "act"),
				Icon    = attr(menu, "icon"),
				Pattern = attr(menu, "pattern"),

				UseFirstSubUrl = "true".Equals(attr(menu, "useFirstSubUrl")),

				SubItems = menu.Elements("sub").Select(sub => new MenuSubItem
				{
					Name    = attr(sub, "name"),
					Url     = attr(sub, "url"),
					Target  = attr(sub, "target"),
					ACT     = attr(sub, "act"),
					Icon    = attr(sub, "icon"),
					Pattern = attr(sub, "pattern"),
				}).ToList(),
			}).ToList();
		}



		private string attr(XElement el, XName name) 
		{
			string value = (string)el.Attribute(name);
			return value.HasText() ? value : null;
		}



		private bool isContainsPath(string basePath, MenuSubItem item)
		{
			if (!item.Url.HasText() || !basePath.HasText()) { return false; }

			if (item.Pattern.HasText()) { return basePath.IsMatch(item.Pattern); }

			string path = item.Url.TrimStart('~').ToLower();
			return basePath.ToLower().Contains(path); 
		}




		/// <summary></summary>
		public IList<MenuItem> GetList(IPrincipal user, string currentUrl)
		{
			var result = new List<MenuItem>();

			foreach (var item in _menuList)
			{
				var subItems = item.SubItems ?? new List<MenuSubItem>();

				/* 過濾並複製子選單 */
				subItems = subItems
					.Select(x => x.Clone())
					.Each(x => x.IsActive = isContainsPath(currentUrl, x))
					.Each(x => x.CanAccess = (x.ACT == null || user.IsInRole(x.ACT)))
					.ToList();

				var main = item.Clone();
				main.SubItems = subItems;
				main.IsActive = subItems.Any(x => x.IsActive) || isContainsPath(currentUrl, main);
				main.CanAccess = (main.ACT == null || user.IsInRole(main.ACT));

				if (item.UseFirstSubUrl && subItems.Count > 0)
				{
					var sub = subItems.First();
					main.Url = sub.Url;
					main.Pattern = sub.Pattern;
					main.CanAccess = sub.CanAccess;
				}

				result.Add(main);
			}

			return result;
		}



		/// <summary></summary>
		public IList<MenuItem> GetAllowList(IPrincipal user, string currentUrl)
		{
			var result = GetList(user, currentUrl)
				.Where(x => x.CanAccess)
				.Each(x => x.SubItems = x.SubItems.Where(y => y.CanAccess).ToList())
				.Where(x => x.Url.HasText() || x.SubItems.Count > 0)
				.ToList();

			return result;
		}



	}


}
