using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUtilities
{
    public class ConsoleTable
    {
        private readonly StringBuilder _table;
        private readonly string[] _columnHeadings;
        private readonly ConsoleTableSettings _settings;
        private readonly List<List<string>> _rows;

        public ConsoleTable(IEnumerable<string> columnHeadings, ConsoleTableSettings settings)
        {
            _columnHeadings = columnHeadings.ToArray();
            _settings = settings;
            _table = new StringBuilder();
            _rows = new List<List<string>>();
        }

        public ConsoleTable(IEnumerable<string> columnHeadings)
            : this(columnHeadings, new ConsoleTableSettings())
        {

        }

        public void AddRow(IEnumerable<string> row)
        {
            if (row.Count() < _columnHeadings.Count())
            {
                throw new ArgumentException("The row has less columns than the headings row.");
            }

            _rows.Add(new List<string>(row));
        }

        public void WriteToConsole()
        {
            var columnWidths = GetColumnWidths();

            _table.AppendLine();
            _table.AppendLine();
            _table.AppendLine();
            BuildRow(columnWidths, new string[] { });
            BuildRow(columnWidths, _columnHeadings);
            BuildRow(columnWidths, new string[] { });

            foreach (var row in _rows)
            {
                BuildRow(columnWidths, row.ToArray());
                BuildRow(columnWidths, new string[] { });
            }

            Console.Write(_table.ToString());
        }

        void BuildRow(int[] columnWidths, string[] rowValues)
        {
            string row = string.Empty;
            if (rowValues.Length > 0)
            {
                for (int i = 0; i < columnWidths.Length; i++)
                {
                    row += _settings.FieldDelimiter.ToString()
                        .PadRight(Char.ToString(_settings.FieldDelimiter).Length + _settings.Padding, ' ') +
                           rowValues[i].PadRight(columnWidths[i]) +
                           string.Empty.PadRight(_settings.Padding, ' ');
                    if (i == rowValues.Length - 1)
                    {
                        row += _settings.FieldDelimiter;
                    }
                }
            }
            else
            {
                for (int i = 0; i < columnWidths.Length; i++)
                {
                    row += Char.ToString(_settings.RowDelimiter).PadRight(columnWidths[i] + _settings.Padding * 2, _settings.RowDelimiter) + Char.ToString(_settings.RowDelimiter);
                }
            }
            _table.AppendLine(row);
        }

        int[] GetColumnWidths()
        {
            var columnWidths = new int[_columnHeadings.Count()];

            for (int i = 0; i < _columnHeadings.Length; i++)
            {
                columnWidths[i] = _columnHeadings[i].Length;
            }

            for (int i = 0; i < _rows.Count; i++)
            {
                for (int j = 0; j < _rows[i].Count(); j++)
                {
                    if (columnWidths[j] < _rows.ElementAt(i).ElementAt(j).Length)
                    {
                        columnWidths[j] = _rows[i].ElementAt(j).Length;
                    }
                }
            }
            return columnWidths;
        }
    }
}