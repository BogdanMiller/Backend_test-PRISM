using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Backend_test_PRISM
{
	public class TestCards
	{
		private string baseUrl = @"https://inspections.gov.ua";
		private string cardLinkClass = @"table_action_btn icon-details";

		private const string testCaseUrl = @"/inspection/all-unplanned?planning_period_id=2";

		public List<Card> GetCards(string page = testCaseUrl)
		{
			List<Card> cards = new List<Card>();

			var cardUrlList = GetCardsUrl(page);

			foreach (var cardUrl in cardUrlList)
			{
				var card = ParseCard(cardUrl);
				cards.Add(card);
			}
			return cards;
		}

		private IEnumerable<string> GetCardsUrl(string page)
		{
			List<string> hrefTags = new List<string>();

			var html = GetHtml(string.Format("{0}{1}", baseUrl, page));

			var parser = new HtmlParser();
			var document = parser.ParseDocument(html);
			
			var cards = from node in document.QuerySelectorAll("a")
						where node.ClassName == cardLinkClass
						select node.GetAttribute("href");

			return cards.ToList();
		}

		private Card ParseCard(string cardUrl)
		{
			var url = string.Format("{0}{1}", baseUrl, cardUrl);
			var html = GetHtml(url);
			Card card = new Card(html, url);
			return card;
		}

		private string GetHtml(string url)
		{
			WebRequest request = WebRequest.Create(url);
			using (WebResponse response = request.GetResponse())
			using (Stream stream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(stream))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
