using System.Collections.Generic;

namespace Backend_test_PRISM
{
	public static class CardPropertyNames
	{
		public static List<string> HtmlKey = new List<string>();
		public static List<string> InspectionProperty = new List<string>();

		static CardPropertyNames()
		{
			HtmlKey.Add(@"Ідентифікаційний код юридичної особи або реєстраційний номер облікової картки платника податків фізичної особи - підприємця (серія (за наявності) та номер паспорта*)");
			HtmlKey.Add(@"Контролюючий орган");
			HtmlKey.Add(@"Сфера контролю");
			HtmlKey.Add(@"Номер акту");
			HtmlKey.Add(@"Статус");
			HtmlKey.Add(@"Ступінь ризику");
			HtmlKey.Add(@"Тип перевірки");
			HtmlKey.Add(@"Заходи впливу та санкції");
			HtmlKey.Add(@"Дати");

			InspectionProperty.Add(@"Ідентифікаційний код юридичної особи");
			InspectionProperty.Add(@"Контролюючий орган");
			InspectionProperty.Add(@"Сфера контролю");
			InspectionProperty.Add(@"Перевірка №");
			InspectionProperty.Add(@"Статус перевірки");
			InspectionProperty.Add(@"Ступінь ризику");
			InspectionProperty.Add(@"Тип перевірки");
			InspectionProperty.Add(@"Санкції (грн.)");
			InspectionProperty.Add(@"Дати проведення");
			InspectionProperty.Add(@"Посилання на картку з результатами");
		}
	}
}
