using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;

namespace Backend_test_PRISM
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			TestParse();
		}

		private void TestParse()
		{
			

        }

		private void b_Previouse_Click(object sender, RoutedEventArgs e)
		{
			SwithPage(-1);
		}

		private void b_Next_Click(object sender, RoutedEventArgs e)
		{
			SwithPage(1);
		}

		private void SwithPage(int value)
		{
			try
			{
				var urlParts = pageUrl.Text.Split('=');
				var page = int.Parse(urlParts[1]);
				if (page + value >= 0)
					pageUrl.Text = string.Format("{0}={1}", urlParts[0], page + value);
			}
			catch { }
		}

		private void b_Parse_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var testCards = new TestCards();
				var cardList = testCards.GetCards(pageUrl.Text);

				var csv = new CsvFile<Card>();
				csv.Write(fileName.Text, cardList);
			}
			catch { }
		}
	}
}
