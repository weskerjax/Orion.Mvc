using Orion.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Orion.Mvc.UI
{

	/// <summary></summary>
	public interface IBreadcrumbProvider
	{
		/// <summary></summary>
		IList<IBreadcrumb> GetPathList(string currentUrl);
	}



	/// <summary></summary>
	public class BreadcrumbProvider : IBreadcrumbProvider
	{

		internal class BreadcrumbNode : IBreadcrumb
		{
			public string Name { get; set; }
			public string Url { get; set; }
			public string Icon { get; set; }
			public string Pattern { get; set; }
			public IList<BreadcrumbNode> ChildNodes { get; set; }
			public BreadcrumbNode Parent { get; set; }
		}


		/*===========================================*/

		private IList<BreadcrumbNode> _nodeList;
		private BreadcrumbNode _root;

		/// <summary></summary>
		public BreadcrumbProvider(string configPath)
		{
			var doc = XDocument.Load(configPath);
			_nodeList = new List<BreadcrumbNode>();
			_root = mappingToNode(doc.Root);
		}



		private string attr(XElement el, XName name)
		{
			string value = (string)el.Attribute(name);
			return String.IsNullOrWhiteSpace(value) ? null : value;
		}


		private BreadcrumbNode mappingToNode(XElement el, BreadcrumbNode parent = null)
		{
			var node = new BreadcrumbNode
			{
				Name    = attr(el,"name"),
				Url     = attr(el, "url"),
				Icon    = attr(el, "icon"),
				Pattern = attr(el, "pattern"),
				Parent  = parent,
			};
			node.ChildNodes = el.Elements("node").Select(x => mappingToNode(x, node)).ToList();

			_nodeList.Add(node);
			return node;
		}



		private BreadcrumbNode findNode(string basePath)
		{
			if (!basePath.HasText()) { return _root; }
			basePath = basePath.ToLower();

			foreach (var node in _nodeList)
			{
				if (node.Pattern.HasText())
				{
					if (basePath.IsMatch(node.Pattern)) { return node; }
				}
				else if (node.Url.HasText())
				{
					string url = node.Url.TrimStart('~').ToLower();
					if (basePath.Contains(url)) { return node; }
				}
			}
			return _root;
		}



		/// <summary></summary>
		public IList<IBreadcrumb> GetPathList(string currentUrl)
		{
			var node = findNode(currentUrl);
			var result = new List<IBreadcrumb>();

			do
			{
				result.Add(node);
				node = node.Parent;
			} while (node != null);
			
			result.Reverse();
			return result;
		}

	}

}
