using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace F1DataFunctions
{
    internal class CsvReader
    {
        public async Task<DataTable> LoadCsvToDataTableAsync(string csvFile)
        {
            using var csvReader = new StreamReader(csvFile);

            List<string> headers = ExtractValuesFromRowText(await csvReader.ReadLineAsync(), ',', '"');
            var dataTable = new DataTable();

            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }

            string rowText;
            while ((rowText = await csvReader.ReadLineAsync()) != null)
            {
                DataRow row = dataTable.NewRow();
                List<string> fieldValues = ExtractValuesFromRowText(rowText, ',', '"');

                for (int i = 0; i < fieldValues.Count; i++)
                {
                    string field = fieldValues[i];
                    if (field == @"\N")
                        row[i] = DBNull.Value;
                    else
                        row[i] = field.Trim('"');
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private static List<string> ExtractValuesFromRowText(string rowText, char separator, char delimiter)
        {
            bool isInQuote = false;
            var fieldBuilder = new StringBuilder();
            var fieldValues = new List<string>();
            foreach (char c in rowText)
            {
                if (c == delimiter)
                {
                    isInQuote = !isInQuote;
                }
                else if (!isInQuote && c == separator)
                {
                    fieldValues.Add(fieldBuilder.ToString());
                    fieldBuilder = new StringBuilder();
                }
                else
                {
                    fieldBuilder.Append(c);
                }
            }
            fieldValues.Add(fieldBuilder.ToString());
            return fieldValues;
        }
    }
}
