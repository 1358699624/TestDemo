using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace TestDemo
{
    internal class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {


            string originalString = "0Hello";

            // 如果字符串的首字母是'0'，则去掉它  
            if (originalString.Length > 0 && originalString[0] == '0')
            {
                originalString = originalString.Substring(1);
            }

            Console.WriteLine(originalString); // 输出 "Hello"  

            string start = "2024-07-24";
            string end = "2024-07-25";
            TimeSpan timeSpan =  Convert.ToDateTime(end) - Convert.ToDateTime(start);
            Console.WriteLine(timeSpan.Days);

            //string time = "2019-05-08T11:37:42.5942115Z";
            //// 转成UTC时间
            //DateTime formatStartTime = DateTime.Parse(time);
            //Console.WriteLine(formatStartTime);


            //double doubleValue = 3.141592653589793;
            //float floatValue = (float)doubleValue;
            //Console.WriteLine(doubleValue);
            //Console.WriteLine(floatValue);



            byte[] data = new byte[] { 0x55, 0xAA, 0x00, 0x01, 0x55, 0xBB, 0xFF, 0xFE, 0x55, 0xAA, 0xAB, 0xCD, 0x55, 0xBB, 0xEF, 0x12 };

            List<byte[]> segments = ExtractSegments(data, new byte[] { 0x55, 0xAA }, new byte[] { 0x55, 0xBB });

            foreach (var segment in segments)
            {
                Console.WriteLine($"Segment: {BitConverter.ToString(segment)}");
            }
            Console.ReadLine();



            return;

        }


        static List<byte[]> ExtractSegments(byte[] data, params byte[][] patterns)
        {
            List<byte[]> segments = new List<byte[]>();

            int startIndex = 0;

            while (startIndex < data.Length)
            {
                foreach (var pattern in patterns)
                {
                    if (startIndex + pattern.Length <= data.Length && IsMatch(data, startIndex, pattern))
                    {
                        segments.Add(pattern);
                        startIndex += pattern.Length;
                        break;
                    }
                }

                // 如果当前位置没有匹配任何模式，则向前移动一位  
                if (startIndex == data.Length || !patterns.Any(p => startIndex + p.Length <= data.Length && IsMatch(data, startIndex, p)))
                {
                    startIndex++;
                }
            }

            return segments;
        }

        static bool IsMatch(byte[] data, int startIndex, byte[] pattern)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (data[startIndex + i] != pattern[i])
                {
                    return false;
                }
            }
            return true;
        }
        /**/
        /// <summary>
        /// 将Xml内容字符串转换成DataSet对象
        /// </summary>
        /// <param name="xmlStr">Xml内容字符串</param>
        /// <returns>DataSet对象</returns>
        private static DataSet CXmlToDataSet(string xmlStr)
        {
            if (!string.IsNullOrEmpty(xmlStr))
            {
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    DataSet ds = new DataSet();
                    //读取字符串中的信息
                    StrStream = new StringReader(xmlStr);
                    //获取StrStream中的数据
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据                
                    ds.ReadXml(Xmlrdr);
                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    //释放资源
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            else
            {
                return null;
            }
        }
        private static DataTable GetOperDataByRtID(string xml, string atID)
        {
            DataSet ds = new DataSet();
            TextReader tr = new StringReader(xml);
            ds.ReadXml(tr);
            if (ds.Tables.Count > 0)
            {
                DataRow[] dsOper = ds.Tables["inspectionResult"].Select("inspectionResultList_ID='" + atID + "'");
                DataTable dtoperAt = ds.Tables["inspectionResult"].Clone();
                foreach (DataRow dr in dsOper)
                {
                    dtoperAt.Rows.Add(dr.ItemArray);
                }
                return dtoperAt;
            }
            return null;
        }
        private static DataTable GetOperDataByRtID2(string xml, string atID)
        {
            DataSet ds = new DataSet();
            TextReader tr = new StringReader(xml);
            ds.ReadXml(tr);
            if (ds.Tables.Count > 0)
            {
                DataRow[] dsOper1 = ds.Tables["clinicalProjectList"].Select("inspectionApply_ID='" + atID + "'");
                DataTable dtoperAt1 = ds.Tables["clinicalProjectList"].Clone();
                foreach (DataRow dr in dsOper1)
                {
                    dtoperAt1.Rows.Add(dr.ItemArray);
                }
                if (dtoperAt1.Rows.Count <= 0)
                {
                    return null;
                }
                DataTable dtoperAt2 = null;
                foreach (DataRow item in dtoperAt1.Rows)
                {
                    DataRow[] dsOper2 = ds.Tables["clinicalProject"].Select("clinicalProjectList_id='" + item["clinicalProjectList_id"] + "'");
                    dtoperAt2 = ds.Tables["clinicalProject"].Clone();
                    foreach (DataRow dr in dsOper2)
                    {
                        dtoperAt2.Rows.Add(dr.ItemArray);
                    }
                }
                return dtoperAt2;
            }
            return null;
        }
    }
}
