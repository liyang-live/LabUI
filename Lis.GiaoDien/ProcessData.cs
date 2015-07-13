using System;
using System.Collections;
using System.Data;
using VNS.Libs;
using LIS.DAL;

namespace Vietbait.Lablink.TestInformation.UI
{
    public class ProcessData
    {
        public static DataTable NormalResult(DataTable dt, string binhthuong, string sSexName)
        {
            try
            {
                double min = 0;
                double max = 0;
                string normal = null;
                const string low = "Low";
                const string hight = "High";
                const string testResult = "Test_result";
                string normalLevel = "Normal_Level";
                var arrResultWithLetters = new ArrayList();
                arrResultWithLetters.Add("NE");
                arrResultWithLetters.Add("POS");

                if (sSexName.ToUpper() != "NAM")
                {
                    normalLevel = "Normal_LevelW";
                }

                //dt.Columns.Add(binhthuong, System.Type.GetType("System.Int32"))
                if (!dt.Columns.Contains(binhthuong))
                {
                    dt.Columns.Add(binhthuong, typeof (string));
                }


                foreach (DataRow dr in dt.Rows)
                {
                    normal = dr[normalLevel].ToString().Trim();
                    if (string.IsNullOrEmpty(normal))
                        continue;
                    normal = normal.Replace("≤", "<=");
                    normal = normal.Replace("≥", ">=");

                    while (normal.IndexOf(" ") > 0)
                    {
                        normal = normal.Replace(" ", "");
                    }

                    while (normal.IndexOf(",") > 0)
                    {
                        normal = normal.Replace(",", ".");
                    }

                    try
                    {
                        //'truong hop nam trong khonang co can tren va can duoi
                        if (string.IsNullOrEmpty(dr[testResult].ToString()) | string.IsNullOrEmpty(normal))
                        {
                            dr[binhthuong] = "";
                        }
                        else if (Utility.IsNumeric(dr[testResult]))
                        {
                            dr[binhthuong] = "";
                            double tempResult = Convert.ToDouble(dr[testResult]);
                            if (normal.IndexOf("-") > 0)
                            {
                                string[] arrstr = null;
                                arrstr = normal.Split('-');
                                min = Convert.ToDouble(arrstr[0]);
                                max = Convert.ToDouble(arrstr[1]);
                                bool b1 = tempResult >= min;
                                bool b2 = tempResult <= max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                            }
                            else if (normal.IndexOf("<=") >= 0)
                            {
                                min = double.MinValue;
                                max = Convert.ToDouble(normal.Substring(2));
                                bool b1 = tempResult >= min;
                                bool b2 = tempResult <= max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                            }
                            else if (normal.IndexOf(">=") >= 0)
                            {
                                max = double.MaxValue;
                                min = Convert.ToDouble(normal.Substring(2));
                                bool b1 = tempResult >= min;
                                bool b2 = tempResult <= max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                                //'Truong hop chi co can tren
                            }
                            else if (normal.IndexOf("<") >= 0)
                            {
                                min = double.MinValue;
                                max = Convert.ToDouble(normal.Substring(1));
                                bool b1 = tempResult > min;
                                bool b2 = tempResult < max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                                //'Truong hop chi co can tren
                            }
                            else if (normal.IndexOf(">") >= 0)
                            {
                                max = double.MaxValue;
                                min = Convert.ToDouble(normal.Substring(1));
                                bool b1 = tempResult > min;
                                bool b2 = tempResult < max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                            }
                        }
                        else
                        {
                            //'Truong hop cua Negative va positive
                            //'Dim b As Boolean = (dr(testResult).ToString.Trim.ToUpper.IndexOf(arrResultWithLetters(0)) >= 0)
                            bool b1 = dr[testResult].ToString().Trim().ToUpper().IndexOf("DƯƠ") >= 0;
                            bool b2 = dr[testResult].ToString().Trim().ToUpper().IndexOf("DUO") >= 0;
                            bool b3 = dr[testResult].ToString().Trim().ToUpper().IndexOf("POS") >= 0;
                            if (b1 | b2 | b3)
                            {
                                dr[binhthuong] = hight;
                            }
                            else
                            {
                                dr[binhthuong] = "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        dr[binhthuong] = " ";
                        continue;
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        public static void AddRowTableDetail(ref DataTable dtResultDetail, string TestData_ID, int Patient_ID, int Test_ID)
        {
            try
            {
                DataRow dr = dtResultDetail.NewRow();
                DataRow drStandardTest = Utility.GetDataRow(PreloadedLists.StandardTest, LStandardTest.Columns.TestDataId,
                                                            TestData_ID);
                dr[TResultDetail.Columns.TestDetailId] = -1;
                dr[TResultDetail.Columns.ParaName] = drStandardTest[LStandardTest.Columns.DataName];
                dr[TResultDetail.Columns.NormalLevel] = drStandardTest[LStandardTest.Columns.NormalLevel];
                dr[TResultDetail.Columns.NormalLevelW] = drStandardTest[LStandardTest.Columns.NormalLevelW];
                dr[TResultDetail.Columns.DataSequence] = drStandardTest[LStandardTest.Columns.DataSequence];
                dr[TResultDetail.Columns.PrintData] = drStandardTest[LStandardTest.Columns.DataPrint];
                dr[TResultDetail.Columns.MeasureUnit] = drStandardTest[LStandardTest.Columns.MeasureUnit];
                dr[TResultDetail.Columns.TestDataId] = drStandardTest[LStandardTest.Columns.TestDataId];
                dr[TResultDetail.Columns.PatientId] = Patient_ID;
                dr[TResultDetail.Columns.TestTypeId] = drStandardTest[LStandardTest.Columns.TestTypeId]; ;
                dr[TResultDetail.Columns.TestId] = Test_ID;
                dtResultDetail.Rows.Add(dr);
                dtResultDetail.AcceptChanges();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        public static void DelRowTableDetail(ref DataTable dtResultDetail, string TestData_ID, int Test_ID)
        {
            try
            {
                foreach (DataRow row in dtResultDetail.Rows)
                {
                    if (Utility.sDbnull(row["TestData_ID"])==TestData_ID & Utility.Int32Dbnull(row["Test_ID"])==Test_ID)
                        row.Delete();
                }
                dtResultDetail.AcceptChanges();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
    }
}