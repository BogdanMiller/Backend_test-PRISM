using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace Backend_test_PRISM
{
	public class Card
	{
		public string Property0 { get; set; }
		public string Property1 { get; set; }
		public string Property2 { get; set; }
		public string Property3 { get; set; }
		public string Property4 { get; set; }
		public string Property5 { get; set; }
		public string Property6 { get; set; }
		public string Property7 { get; set; }
		public string Property8 { get; set; }
		public string Property9 { get; set; }

		public Card(string html, string url)
		{
			var parser = new HtmlParser();
			var document = parser.ParseDocument(html);

			ParseCard(document);
			Property9 = url;
		}

		private void ParseCard(IHtmlDocument doc)
		{
			// Get td node list
			var td = doc.QuerySelectorAll("td");

			Property0 = FindValueByName(td, CardPropertyNames.HtmlKey[0]);
			Property1 = FindValueByName(td, CardPropertyNames.HtmlKey[1]);
			Property2 = FindValueByName(td, CardPropertyNames.HtmlKey[2]);
			Property3 = FindValueByName(td, CardPropertyNames.HtmlKey[3]);
			Property4 = FindValueByName(td, CardPropertyNames.HtmlKey[4]);
			Property5 = FindValueByName(td, CardPropertyNames.HtmlKey[5]);
			Property6 = FindValueByName(td, CardPropertyNames.HtmlKey[6]);
			Property7 = FindValueByName(td, CardPropertyNames.HtmlKey[7]);
			Property8 = FindValueByName(td, CardPropertyNames.HtmlKey[8]);
		}

		private string FindValueByName(IHtmlCollection<IElement> td, string name)
		{
			for (int i = 0; i < td.Length; i++)
			{
				if (td[i].InnerHtml == name)
				{
					var targetElement = td[i + 1];
					if (targetElement.ChildElementCount == 0)
					{
						return targetElement.InnerHtml;
					}
					else
					{
						return targetElement.TextContent;
					}
				}
			}
			return null;
		}
	}
}
