using System;
using System.Collections.Generic;

namespace HACDN.Objects
{
    public class Table
    {
        //The main intention of this is actually making a DataTable, but I dont want to spend too much time on that if I dont keep up with the project
        public List<Row> Rows { get; set; }

        public Table(string htmlTable)
        {
            Rows = new List<Row>();
            foreach (var htmlRow in htmlTable.Split(new string[] { "<tr>" }, StringSplitOptions.None))
            {
                var row = new Row();
                var columns = new List<string>();
                if (htmlRow.Contains("<th>"))
                {
                    row.isHeader = true;
                    foreach (var htmlColumn in htmlRow.Split(new string[] { "<th>" }, StringSplitOptions.None))
                    {
                        var columnClean = htmlColumn.Replace("</th>", "").Replace("</tr>", "").Replace("\r", "").Replace("\n", "");
                        if (!string.IsNullOrWhiteSpace(columnClean))
                            columns.Add(columnClean);
                    }
                }
                else if (htmlRow.Contains("<td>"))
                {
                    row.isHeader = false;
                    foreach (var htmlColumn in htmlRow.Split(new string[] { "<td>" }, StringSplitOptions.None))
                    {
                        var columnClean = htmlColumn.Replace("</tr>", "").Replace("\r", "").Replace("\n", "");
                        if (!string.IsNullOrWhiteSpace(columnClean))
                            columns.Add(columnClean.Replace("</td>", "")); //Seems counter intuitive to have this here, but hear me out, this is MVP (Minimum Value Product) therefore it just needs to work initially. This is here to avoid not inserting empty spaces into the array.
                    }
                }
                row.Columns = columns;

                if (columns.Count > 1)
                    Rows.Add(row);
            }
        }
    }
}