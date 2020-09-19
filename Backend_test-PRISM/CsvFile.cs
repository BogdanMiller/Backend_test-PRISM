using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Backend_test_PRISM
{
	class CsvFile<T>
	{
		public void Write(string path, List<T> data)
		{
			path = string.Format("{0}.csv", path);
			using (var writer = new StreamWriter(path))
			using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
			{
				csv.WriteRecords(data);
			}
		}
	}
}
