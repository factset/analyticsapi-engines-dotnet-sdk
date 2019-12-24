using System;
using System.Collections.Generic;
using System.Linq;
using FactSet.Protobuf.Stach;
using FactSet.Protobuf.Stach.Table;

namespace FactSet.AnalyticsAPI.Engines.Example.Examples
{
    public static class StachExtensions
    {
        public static void GenerateCSV(this Package package)
        {
            foreach (var table in package.ConvertToTableFormat())
            {
                System.IO.File.WriteAllText($"{Guid.NewGuid():N}.csv", table.ToString());
            }
        }

        public static List<Table> ConvertToTableFormat(this Package package)
        {
            var tables = new List<Table>();
            foreach (var primaryTableId in package.PrimaryTableIds)
            {
                tables.Add(GenerateTable(package, primaryTableId));
            }

            return tables;
        }

        private static Table GenerateTable(Package package, string primaryTableId)
        {
            var primaryTable = package.Tables[primaryTableId];
            var headerId = primaryTable.Definition.HeaderTableId;
            var headerTable = package.Tables[headerId];
            var columnIds = primaryTable.Definition.Columns.Select(c => c.Id).ToList();
            var headerColumnIds = headerTable.Definition.Columns.Select(c => c.Id).ToList();
            var dimensionColumnsCount = primaryTable.Definition.Columns.Count(c => c.IsDimension);
            var rowCount = primaryTable.Data.Rows.Count;
            var headerRowCount = headerTable.Data.Rows.Count;

            var table = new Table
            {
                Rows = new List<Row>()
            };
            // Constructs the column headers by considering dimension columns and header rows
            foreach (var columnId in headerColumnIds)
            {
                var headerRow = new Row { Cells = new List<string>() };
                for (int j = 0; j < dimensionColumnsCount; j++)
                {
                    headerRow.Cells.Add("");
                }

                for (int i = 0; i < headerRowCount; i++)
                {
                    headerRow.Cells.Add(Convert.ToString(headerTable.Data.Columns[columnId]
                        .GetValueHelper(headerTable.Definition.Columns.First(c => c.Id == columnId).Type, i)));
                }
                table.Rows.Add(headerRow);
            }
            // Constructs the column data
            for (int i = 0; i < rowCount; i++)
            {
                var dataRow = new Row { Cells = new List<string>() };
                foreach (var columnId in columnIds)
                {
                    dataRow.Cells.Add(Convert.ToString(primaryTable.Data.Columns[columnId]
                        .GetValueHelper(primaryTable.Definition.Columns.First(c => c.Id == columnId).Type, i)));
                }
                table.Rows.Add(dataRow);
            }

            return table;
        }
    }

    public static class SeriesDataHelper
    {
        public static object GetValueHelper(this SeriesData seriesData, DataType dataType, int index)
        {
            switch (dataType)
            {
                case DataType.Bool:
                    {
                        return seriesData.BoolArray?.Values?[index];
                    }
                case DataType.Double:
                    {
                        return seriesData.DoubleArray?.Values?[index];
                    }
                case DataType.Duration:
                    {
                        var v = seriesData.DurationArray?.Values?[index];
                        return v?.ToTimeSpan();
                    }
                case DataType.Float:
                    {
                        return seriesData.FloatArray?.Values?[index];
                    }
                case DataType.Int32:
                    {
                        return seriesData.Int32Array?.Values?[index];
                    }
                case DataType.Int64:
                    {
                        return seriesData.Int64Array?.Values?[index];
                    }
                case DataType.String:
                    {
                        return seriesData.StringArray?.Values?[index];
                    }
                case DataType.Timestamp:
                    {
                        var v = seriesData.TimestampArray?.Values?[index];
                        return v?.ToDateTime();
                    }
                default:
                    throw new NotImplementedException($"{dataType} is not implemented");
            }
        }
    }

    public class Table
    {
        public List<Row> Rows { get; set; }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Rows);
        }
    }

    public class Row
    {
        public List<string> Cells { get; set; }

        public override string ToString()
        {
            return string.Join(",", Cells.Select(c => c.Replace(",", "")));
        }
    }
}
