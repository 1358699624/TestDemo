using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    public class ExcelAI
    {
        public static string ToExcelColumn(int columnIndex)
        {
            if (columnIndex < 0) throw new ArgumentOutOfRangeException(nameof(columnIndex), "Column index must be non-negative.");

            var sb = new StringBuilder();

            while (columnIndex >= 0)
            {
                int remainder = columnIndex % 26;
                sb.Insert(0, (char)('A' + remainder));
                columnIndex = (columnIndex - remainder) / 26 - 1;
            }

            return sb.ToString();
        }
    }
}
