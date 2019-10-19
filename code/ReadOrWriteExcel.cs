using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Text.RegularExpressions;
using Aspose.Cells;
namespace ExcelHelp
{
    public class ReadOrWriteExcel
    {
        Workbook book = null;
      
        public ReadOrWriteExcel(string filepath)
        {
        book = new Workbook(filepath);
        }
       
        public DataTable BeginRead(string begin, string end, string sheetname) //  根据 起始位置，截止位置，表名     读取数据
        {
            string[] strarr = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ" };

             Worksheet sheet = null;
        Regex reg1 = new Regex(@"[A-Z]+");
        Regex reg2 = new Regex(@"[0-9]+");
        DataTable dt=new DataTable();
        DataRow dr = null;  
        int firstRow = 0, firstColumn = 0;
        int i1=0,i2=0;
        string tempvalue = "";
        try
        {
            for (int i = 0; i < strarr.Length; i++)
            {
                if (strarr[i] == reg1.Match(begin).ToString())
                {
                    i1 = i;
                    firstColumn = i;
                    break;
                }
            }
            for (int i = 0; i < strarr.Length; i++)
            {
                if (strarr[i] == reg1.Match(end).ToString())
                {
                    i2 = i;
                    break;
                }
            }
            int columncount = 0, rowcount = 0;
            columncount = i2 - i1 + 1;

            if (reg2.Match(end).ToString() != "")
                rowcount = Convert.ToInt32(reg2.Match(end).ToString()) - Convert.ToInt32(reg2.Match(begin).ToString()) + 1;
            firstRow = Convert.ToInt32(reg2.Match(begin).ToString()) - 1;
           
                sheet = book.Worksheets[sheetname];

                if (sheet == null)

                    sheet = book.Worksheets[0];
            
            
            //for (int k = 1; k <= columncount; k++)
            //{
            //    dt.Columns.Add("Column" + k, typeof(System.String));
            //}
            if (rowcount == 0)
            {
                //try
                //{

                if (sheet.Cells.MaxDataRow > 0)
                {
                    //dt = sheet.Cells.ExportDataTable(firstRow, firstColumn, sheet.Cells.MaxDataRow - 9, columncount);
                    //}
                    //catch {
                    //dt = new DataTable();
                    for (int k1 = 1; k1 <= columncount; k1++)
                    {
                        dt.Columns.Add("Column" + k1, typeof(System.String));
                    }
                    int index1 = 0;
                    for (int k = firstRow; k < firstRow + (sheet.Cells.MaxDataRow+1); k++)
                    {
                        dr = dt.NewRow();
                        index1 = 0;
                        for (int l = firstColumn; l < columncount + firstColumn; l++)
                        {
                            index1++;
                            if (sheet.Cells[k, l].Value != null)
                            {
                                tempvalue = sheet.Cells[k, l].Value.ToString().Trim().Replace("\n", "");
                                tempvalue = tempvalue.Replace("\r", "");
                                tempvalue = tempvalue.Replace("\0", "");
                                dr["Column" + index1] = tempvalue;
                            }
                            else
                                //tempvalue = sheet.Cells[k, l].Value;
                            dr["Column" + index1] = sheet.Cells[k, l].Value;
                        }
                        dt.Rows.Add(dr);
                    }
                }
                //}
            }
            else
            {
                //try
                //{
                //    dt = sheet.Cells.ExportDataTable(firstRow, firstColumn, rowcount, columncount);
                //}
                //catch
                //{
                    //dt = new DataTable();
                    for (int k1 = 1; k1 <= columncount; k1++)
                    {
                        dt.Columns.Add("Column" + k1, typeof(System.String));
                    }
                    int index1 = 0;
                    for (int k = firstRow; k < firstRow + rowcount; k++)
                    {
                        dr = dt.NewRow();
                        index1 = 0;
                        for (int l = firstColumn; l < columncount + firstColumn; l++)
                        {
                            index1++;
                            //dr["Column" + index1] = sheet.Cells[k, l].Value;

                            if (sheet.Cells[k, l].Value != null)
                            {
                                tempvalue = sheet.Cells[k, l].Value.ToString().Trim().Replace("\n", "");
                                tempvalue = tempvalue.Replace("\r", "");
                                tempvalue = tempvalue.Replace("\0", "");
                                dr["Column" + index1] = tempvalue;
                            }
                            else
                                //tempvalue = sheet.Cells[k, l].Value;
                                dr["Column" + index1] = sheet.Cells[k, l].Value;

                        }
                        dt.Rows.Add(dr);
                    }
                //}
            }
            int endindex = -1;
            int flag=0;
            //从最后一行开始找没有数据的行
            if (dt != null)
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {

                    flag = 0;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i].IsNull(j) || dt.Rows[i][j].ToString().Trim() == "")
                        {
                            flag++;
                        }
                    }
                    if (flag != dt.Columns.Count)//找到有数据的行就停止循环
                    {

                        break;
                    }
                    else
                    {
                        endindex = i;
                    }
                }

                if (endindex != -1)
                    for (int i = dt.Rows.Count - 1; i >= endindex; i--)
                    {
                        dt.Rows[i].Delete();
                    }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
                return dt;
           
        }



        public void BeginWrite(DataTable dt, string sheetname, string beginposition)
        {
            Worksheet sheet = null;
            try
            {
                  string[] strarr = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU" ,"AV","AW","AX","AY","AZ","BA","BB","BC","BD","BE","BF","BG","BH","BI","BJ","BK","BL","BM","BN"};
        
        
        Regex reg1 = new Regex(@"[A-Z]+");
        Regex reg2 = new Regex(@"[0-9]+");
      
        int firstRow = 0, firstColumn = 0;
        int i1=0,i2=0;
      
            for (int i = 0; i < strarr.Length; i++)
            {
                if (strarr[i] == reg1.Match(beginposition).ToString())
                {
                    i1 = i;
                    firstColumn = i;
                    break;
                }
            }
            for (int i = 0; i < strarr.Length; i++)
            {
                if (strarr[i] == reg1.Match(beginposition).ToString())
                {
                    i2 = i;
                    break;
                }
            }
             firstRow = Convert.ToInt32(reg2.Match(beginposition).ToString()) - 1;
                sheet = book.Worksheets[sheetname];
                //sheet.Unprotect("9ijnbGT%$esz");
                //sheet.Cells.ImportDataTable(dt, false, beginposition);
                if (dt != null)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        for (int k = 0; k < dt.Columns.Count; k++)
                        {
                            //sheet.Cells[j + firstRow, k + firstColumn].PutValue(dt.Rows[j][k]);
                            try
                            {
                                if (dt.Rows[j][k].ToString().Trim() != "")
                                {
                                    if (IsNumber(dt.Rows[j][k].ToString().Trim()))
                                    {
                                        if (dt.Rows[j][k].ToString().Trim().Substring(0, 1) == "0")
                                        {
                                            if (dt.Rows[j][k].ToString().Trim().Length >= 2)
                                            {
                                                if (dt.Rows[j][k].ToString().Trim().Substring(0, 2) == "0.")
                                                sheet.Cells[j + firstRow, k + firstColumn].Value = Convert.ToDecimal(dt.Rows[j][k].ToString().Trim());
                                                else
                                                    sheet.Cells[j + firstRow, k + firstColumn].Value = dt.Rows[j][k];

                                            }
                                            else
                                                sheet.Cells[j + firstRow, k + firstColumn].Value = Convert.ToDecimal(dt.Rows[j][k].ToString().Trim());

                                           

                                        }
                                        else
                                        {
                                            sheet.Cells[j + firstRow, k + firstColumn].Value = Convert.ToDecimal(dt.Rows[j][k].ToString().Trim());
                                        }
                                    }
                                    else
                                        sheet.Cells[j + firstRow, k + firstColumn].Value = dt.Rows[j][k];

                                }
                                
                            }
                            catch
                            {
                                sheet.Cells[j + firstRow, k + firstColumn].Value = dt.Rows[j][k];
                            }
                        }
                    }
                }
                //book.Save(savepath);
                book.SaveToStream();
              
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DataWrite_SetSheetStyle(DataTable dt, DataTable dt_yjmc, string sheetname)
        {
            Worksheet sheet = null;
            sheet = book.Worksheets[sheetname];
            Cells cells = sheet.Cells;//单元格
            Style style1 = cells.GetCellStyle(5, 6);//获取单元格样式
            style1.HorizontalAlignment = TextAlignmentType.Center;
            style1.IsTextWrapped = true;//单元格内容自动换行

            Style style2 = cells.GetCellStyle(5, 6);//获取单元格样式
            style2.HorizontalAlignment = TextAlignmentType.Center;
            style2.IsTextWrapped = true;//单元格内容自动换行
            //style2.ForegroundColor = System.Drawing.Color.FromArgb(0xFFFFAA);//设置背景色
            style2.ForegroundColor = System.Drawing.Color.FromArgb(0xFFFFAA);//设置背景色
            style2.Pattern = BackgroundType.Solid;

            Style style3 = cells.GetCellStyle(5, 6);//获取单元格样式
            style3.HorizontalAlignment = TextAlignmentType.Center;
            style3.IsTextWrapped = true;//单元格内容自动换行
            style3.ForegroundColor = System.Drawing.Color.FromArgb(0xFFC1E0);//设置背景色
            style3.Pattern = BackgroundType.Solid;
            //cells[1, 1].SetStyle(style1);//设置单元格样式


            int startrownindex = 5, startcellindex = 4;
            int addrows=0;

            DataRow[] drs = null;
            double c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0;
            double c1_hj = 0, c2_hj = 0, c3_hj = 0, c4_hj = 0, c5_hj = 0, c6_hj = 0, c7_hj = 0, c8_hj = 0;
            for (int i = 0; i < dt_yjmc.Rows.Count; i++)
            {
                drs = dt.Select("YJMC='" + dt_yjmc.Rows[i]["YJMC"] + "'");

                c1 = 0;
                c2 = 0;
                c3 = 0;
                c4 = 0;
                c5 = 0;
                c6 = 0;
                c7 = 0;
                c8 = 0;
                for (int j = 0; j < drs.Length; j++)
                {

                    if (j == 0)
                    {
                            
                            cells.Merge(startrownindex+addrows, startcellindex, drs.Length, 1);//合并单元格
                            cells[startrownindex + addrows, startcellindex].Value = drs[0][0].ToString().Trim();

                            for (int jj = 0; jj < drs.Length; jj++)
                            {
                                cells[startrownindex + addrows+jj, startcellindex].SetStyle(style1);
                            }
                       
                        
                    }
                       
                      
                        
                    for (int k = 1; k < dt.Columns.Count; k++)
                    {
                        cells[startrownindex + addrows + j, startcellindex + k].Value = drs[j][k].ToString().Trim();
                        //cells[startrownindex + addrows + j, startcellindex + k].PutValue(drs[j][k].ToString().Trim());
                        cells[startrownindex + addrows + j, startcellindex + k].SetStyle(style1);
                      
                       
                       
                      
                    }
                    cells.SetRowHeight(startrownindex + addrows + j, 29.25);//设置行高

                    c1 = c1 + double.Parse(drs[j][2].ToString().Trim());
                    c2 = c2 + double.Parse(drs[j][3].ToString().Trim());
                    c3 = c3 + double.Parse(drs[j][4].ToString().Trim());
                    c4 = c4 + double.Parse(drs[j][5].ToString().Trim());
                    c5 = c5 + double.Parse(drs[j][6].ToString().Trim());
                    c6 = c6 + double.Parse(drs[j][7].ToString().Trim());
                    c7 = c7 + double.Parse(drs[j][8].ToString().Trim());
                    c8 = c8 + double.Parse(drs[j][9].ToString().Trim());
                }

                    cells.Merge(startrownindex + drs.Length + addrows, startcellindex, 1, 2);//合并单元格
                    cells[startrownindex + drs.Length + addrows, startcellindex].Value = "小计";
                    cells[startrownindex + drs.Length + addrows, startcellindex + 2].Value = c1;
                    cells[startrownindex + drs.Length + addrows, startcellindex + 3].Value = c2;
                    cells[startrownindex + drs.Length + addrows, startcellindex + 4].Value = c3;
                    cells[startrownindex + drs.Length + addrows, startcellindex + 5].Value = c4;
                    cells[startrownindex + drs.Length + addrows, startcellindex + 6].Value = c5;
                    cells[startrownindex + drs.Length + addrows, startcellindex + 7].Value = c6;
                    cells[startrownindex + drs.Length + addrows, startcellindex + 8].Value = c7;
                    cells[startrownindex + drs.Length + addrows, startcellindex + 9].Value = c8;

                    cells.SetRowHeight(startrownindex + drs.Length + addrows, 29.25);//设置行高
                    cells[startrownindex + drs.Length + addrows, startcellindex].SetStyle(style2);
                    cells[startrownindex + drs.Length + addrows, startcellindex + 1].SetStyle(style2);
                    cells[startrownindex + drs.Length + addrows, startcellindex + 2].SetStyle(style2);
                    cells[startrownindex + drs.Length + addrows, startcellindex + 3].SetStyle(style2);
                    cells[startrownindex + drs.Length + addrows, startcellindex + 4].SetStyle(style2);
                    cells[startrownindex + drs.Length + addrows, startcellindex + 5].SetStyle(style2);
                    cells[startrownindex + drs.Length + addrows, startcellindex + 6].SetStyle(style2);
                    cells[startrownindex + drs.Length + addrows, startcellindex + 7].SetStyle(style2);
                    cells[startrownindex + drs.Length + addrows, startcellindex + 8].SetStyle(style2);
                    cells[startrownindex + drs.Length + addrows, startcellindex + 9].SetStyle(style2);
                
              
                c1_hj = c1_hj + c1;
                c2_hj = c2_hj + c2;
                c3_hj = c3_hj + c3;
                c4_hj = c4_hj + c4;
                c5_hj = c5_hj + c5;
                c6_hj = c6_hj + c6;
                c7_hj = c7_hj + c7;
                c8_hj = c8_hj + c8;
                startrownindex = startrownindex + drs.Length;
                addrows = addrows + 1;


            }

            cells.Merge(startrownindex  + addrows, startcellindex, 1, 2);//合并单元格
            cells[startrownindex  + addrows, startcellindex].Value = "合计";
            cells[startrownindex + addrows, startcellindex + 2].Value = c1_hj;
            cells[startrownindex + addrows, startcellindex + 3].Value = c2_hj;
            cells[startrownindex + addrows, startcellindex + 4].Value = c3_hj;
            cells[startrownindex + addrows, startcellindex + 5].Value = c4_hj;
            cells[startrownindex + addrows, startcellindex + 6].Value = c5_hj;
            cells[startrownindex + addrows, startcellindex + 7].Value = c6_hj;
            cells[startrownindex + addrows, startcellindex + 8].Value = c7_hj;
            cells[startrownindex + addrows, startcellindex + 9].Value = c8_hj;

            cells.SetRowHeight(startrownindex  + addrows, 29.25);//设置行高
            cells[startrownindex + addrows, startcellindex].SetStyle(style3);
            cells[startrownindex + addrows, startcellindex + 1].SetStyle(style3);
            cells[startrownindex + addrows, startcellindex + 2].SetStyle(style3);
            cells[startrownindex + addrows, startcellindex + 3].SetStyle(style3);
            cells[startrownindex + addrows, startcellindex + 4].SetStyle(style3);
            cells[startrownindex + addrows, startcellindex + 5].SetStyle(style3);
            cells[startrownindex + addrows, startcellindex + 6].SetStyle(style3);
            cells[startrownindex + addrows, startcellindex + 7].SetStyle(style3);
            cells[startrownindex + addrows, startcellindex + 8].SetStyle(style3);
            cells[startrownindex + addrows, startcellindex + 9].SetStyle(style3);
            //sb.Append("<tr class=\"odd1\">");
            //sb.Append("<td colspan=\"2\">合计</td><td>" + c1_hj + "</td><td>" + c2_hj + "</td><td>" + c3_hj + "</td><td>" + c4_hj + "</td><td>" + c5_hj + "</td><td>" + c6_hj + "</td><td>" + c7_hj + "</td><td>" + c8_hj + "</td><td></td>");
            //sb.Append("</tr>");
            //sb.Append("</table>");
        }


        public void DataWrite_SetSheetStyle(DataTable dt, string sheetname,string zrbm,string fzr)
        {
            double c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0;
            Worksheet sheet = null;
            sheet = book.Worksheets[sheetname];
            Cells cells = sheet.Cells;//单元格
            Style style1 = cells.GetCellStyle(4,1);//获取单元格样式
            style1.HorizontalAlignment = TextAlignmentType.Center;
            style1.IsTextWrapped = true;//单元格内容自动换行

            Style style2 = cells.GetCellStyle(0, 16);//获取单元格样式
            style2.HorizontalAlignment = TextAlignmentType.Right;
            style2.IsTextWrapped = true;//单元格内容自动换行

            int startrownindex = 4, startcellindex = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cells.SetRowHeight(4 + i, 29.25);//设置行高
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    cells[startrownindex + i, j + startcellindex].Value = dt.Rows[i][j].ToString().Trim();
                    cells[startrownindex + i, j + startcellindex].SetStyle(style1);
                   
                }
                c1 = c1 + double.Parse(dt.Rows[i]["ZZRYFY"].ToString().Trim());
                c2 = c2 + double.Parse(dt.Rows[i]["TXRYFY"].ToString().Trim());
                c3 = c3 + double.Parse(dt.Rows[i]["QTRYFY"].ToString().Trim());
                c4 = c4 + double.Parse(dt.Rows[i]["FLF"].ToString().Trim());
                c5 = c5 + double.Parse(dt.Rows[i]["SBHCF"].ToString().Trim());
                c6 = c6 + double.Parse(dt.Rows[i]["YWF"].ToString().Trim());
                c7 = c7 + double.Parse(dt.Rows[i]["QT"].ToString().Trim());
                c8 = c8 + double.Parse(dt.Rows[i]["YSJE"].ToString().Trim());
            }
            cells.SetRowHeight(startrownindex + dt.Rows.Count, 29.25);//设置行高
            cells.Merge(startrownindex + dt.Rows.Count, startcellindex, 1, 5);//合并单元格
            cells[startrownindex + dt.Rows.Count,0].Value = "合计：";
            cells[startrownindex + dt.Rows.Count, 5].Value = c1;
            cells[startrownindex + dt.Rows.Count, 6].Value = c2;
            cells[startrownindex + dt.Rows.Count, 7].Value = c3;
            cells[startrownindex + dt.Rows.Count, 8].Value = c4;
            cells[startrownindex + dt.Rows.Count, 9].Value = c5;
            cells[startrownindex + dt.Rows.Count, 10].Value = c6;
            cells[startrownindex + dt.Rows.Count, 11].Value = c7;
            cells[startrownindex + dt.Rows.Count, 12].Value = c8;

            cells[startrownindex + dt.Rows.Count, 0].SetStyle(style1);
            cells[startrownindex + dt.Rows.Count, 1].SetStyle(style1);
            cells[startrownindex + dt.Rows.Count, 2].SetStyle(style1);
            cells[startrownindex + dt.Rows.Count, 3].SetStyle(style1);
            cells[startrownindex + dt.Rows.Count, 4].SetStyle(style1);
            cells[startrownindex + dt.Rows.Count, 5].SetStyle(style1);
            cells[startrownindex + dt.Rows.Count, 6].SetStyle(style1);
            cells[startrownindex + dt.Rows.Count, 7].SetStyle(style1);
            cells[startrownindex + dt.Rows.Count, 8].SetStyle(style1);
            cells[startrownindex + dt.Rows.Count, 9].SetStyle(style1);
            cells[startrownindex + dt.Rows.Count, 10].SetStyle(style1);
            cells[startrownindex + dt.Rows.Count, 11].SetStyle(style1);
            cells[startrownindex + dt.Rows.Count, 12].SetStyle(style1);


            cells[startrownindex + dt.Rows.Count + 1, 9].Value = "责任部门：";
            cells[startrownindex + dt.Rows.Count + 1, 9].SetStyle(style2);
            cells[startrownindex + dt.Rows.Count + 1, 10].Value =zrbm;
            cells[startrownindex + dt.Rows.Count + 1, 11].Value = "负责人：";
            cells[startrownindex + dt.Rows.Count + 1, 11].SetStyle(style2);
            cells[startrownindex + dt.Rows.Count + 1, 12].Value = fzr;
            cells[startrownindex + dt.Rows.Count + 2, 11].Value = "日期：";
            cells[startrownindex + dt.Rows.Count + 2, 11].SetStyle(style2);
        }


        public void SavePath(string savepath)
        {
            try
            {
                book.Save(savepath);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public  bool IsNumber(string strNumber)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
            return r.IsMatch(strNumber);
        }  
    }


    
}
