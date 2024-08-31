 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedIndex.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         }

        private void button2_Click(object sender, EventArgs e)
        {
            string templatePath = @"E:\00src\testdemo\WindowsFormsApp1\ExceLWork\设备设施数量及定期维护情况登记表.xlsx";
            string outputPath = $@"E:\00src\testdemo\WindowsFormsApp1\ExceLWork\设备设施数量及定期维护情况登记表-{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
            Workbook workbook = new Workbook(templatePath);
            Worksheet worksheet = workbook.Worksheets[0];
            Cells cells = worksheet.Cells;
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                for (int j = 0; j < dtable.Columns.Count; j++) 
                {
                    // 使用辅助函数生成 Excel 列引用  
                    string columnRef = ExcelAI.ToExcelColumn(j);
                    // 构建完整的单元格引用，如 "A1", "B2", ...  
                    string cellRef = columnRef + (i + 5).ToString();

                    // 从 DataTable 获取当前单元格的值，并将其放入 Excel 单元格中  
                    cells[cellRef].PutValue(dtable.Rows[i][j].ToString());

                    if (i!=0)
                    {
                        var contentStyle = cells[4 + i, j].GetStyle();


                        worksheet.Cells[cellRef].SetStyle(contentStyle);

                    }
                    // 假设我们想要加粗并居中第一行的文本  

                    //Style style = worksheet.Cells[i, j].GetStyle();
                    //style.Font.IsBold = true;
                    //style.HorizontalAlignment = TextAlignmentType.Center;
                    //style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                    //style.Borders[BorderType.TopBorder].Color = Color.Black;
                    //style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
                    //style.Borders[BorderType.BottomBorder].Color = Color.Black;
                    //style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                    //style.Borders[BorderType.LeftBorder].Color = Color.Black;
                    //style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                    //style.Borders[BorderType.RightBorder].Color = Color.Black;

                    // 应用样式  
                }
            }


            workbook.Save(outputPath);

            //打印EXCEL 
            SpireHelper spireHelper = new SpireHelper();

            spireHelper.DAYIN(outputPath);
        }

      
        DataTable dtable = new DataTable("Rock");

        private void button1_Click(object sender, EventArgs e)
        {
            //set columns names
            dtable.Columns.Add("Blood1", typeof(System.String));
            dtable.Columns.Add("Blood2", typeof(System.String));
            dtable.Columns.Add("Blood3", typeof(System.String));
            dtable.Columns.Add("Dity1", typeof(System.String));
            dtable.Columns.Add("Dity2", typeof(System.String));
            dtable.Columns.Add("Dity3", typeof(System.String));
            dtable.Columns.Add("QiXieCount", typeof(System.String));
            dtable.Columns.Add("Handle1", typeof(System.String));
            dtable.Columns.Add("Handle2", typeof(System.String));
            dtable.Columns.Add("Handle3", typeof(System.String));
            dtable.Columns.Add("Handle4", typeof(System.String));

            //Add Rows
            DataRow drow = dtable.NewRow();
            drow["Blood1"] = "5";
            drow["Blood2"] = "2";
            drow["Blood3"] = "3";

            drow["Dity1"] = "2";
            drow["Dity2"] = "1";
            drow["Dity3"] = "1";

            drow["QiXieCount"] = "5";

            drow["Handle1"] = "√";
            drow["Handle2"] = "√";
            drow["Handle3"] = "√";
            drow["Handle4"] = "√";

            dtable.Rows.Add(drow);

            drow = dtable.NewRow();
            drow["Blood1"] = "5";
            drow["Blood2"] = "2";
            drow["Blood3"] = "3";

            drow["Dity1"] = "2";
            drow["Dity2"] = "1";
            drow["Dity3"] = "1";

            drow["QiXieCount"] = "5";

            drow["Handle1"] = "√";
            drow["Handle2"] = "√";
            drow["Handle3"] = "√";
            drow["Handle4"] = "√";
            dtable.Rows.Add(drow);

            drow = dtable.NewRow();
            drow["Blood1"] = "5";
            drow["Blood2"] = "2";
            drow["Blood3"] = "3";

            drow["Dity1"] = "2";
            drow["Dity2"] = "1";
            drow["Dity3"] = "1";

            drow["QiXieCount"] = "5";

            drow["Handle1"] = "√";
            drow["Handle2"] = "√";
            drow["Handle3"] = "√";
            drow["Handle4"] = "√";
            dtable.Rows.Add(drow);

            drow = dtable.NewRow();
            drow["Blood1"] = "5";
            drow["Blood2"] = "2";
            drow["Blood3"] = "3";

            drow["Dity1"] = "2";
            drow["Dity2"] = "1";
            drow["Dity3"] = "1";

            drow["QiXieCount"] = "5";

            drow["Handle1"] = "√";
            drow["Handle2"] = "√";
            drow["Handle3"] = "√";
            drow["Handle4"] = "√";
            dtable.Rows.Add(drow);

            multiColHeaderDgv2.DataSource = dtable;


        }
    }
}
