using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using VNS.Libs;
using LIS.DAL;
using SubSonic;

namespace Vietbait.Lablink.TestInformation.UI
{

    public class ControlUtilities
    {
        public ControlUtilities()
        {
            FormName = "";
            Control = new Control();
        }

        public string FormName { get; set; }
        public Control Control { get; set; }

        private static string[] arrControl_Name = new string[] { };
        private static string[] arrAllowed_Control_Name = new string[] { };
        private string currentUserName = Utility.sDbnull(globalVariables.UserName, "-1");
        private DataTable dtFormControl;
        private DataTable dtUserControlRelation;

        public void SetChildWindowsFormProperties()
        {
            try
            {
                if (currentUserName == "ADMIN" || currentUserName == "LIS_ADMIN") return;
                dtFormControl = new Select().From(LFormControl.Schema.Name).Where(LFormControl.Columns.FormName).IsEqualTo(FormName).
                    ExecuteDataSet().Tables[0];
                dtUserControlRelation = new Select("*").From(LUserFormControl.Schema.Name).
                    LeftOuterJoin(LFormControl.ControlIdColumn, LUserFormControl.ControlIdColumn).
                    Where(LUserFormControl.UserNameColumn.QualifiedName).IsEqualTo(currentUserName).
                    And(LFormControl.Columns.FormName).IsEqualTo(FormName).
                    ExecuteDataSet().Tables[0];

                arrControl_Name = (from dr in dtFormControl.AsEnumerable()
                                   where string.IsNullOrEmpty(Utility.sDbnull(dr.Field<object>(LFormControl.Columns.ControlTypeName)))
                                   select dr.Field<string>(LFormControl.Columns.ControlName)).ToArray();
                arrAllowed_Control_Name = (from dr in dtUserControlRelation.AsEnumerable()
                                           select dr.Field<string>(LFormControl.Columns.ControlName)).ToArray();

                PerformInductionMethod(Control);
            }
            catch (Exception)
            {

            }
        }

        public void PerformInductionMethod(Control control)
        {
            try
            {
                //if (control == null) return;
                if (!UserHasAccess(control.Name))
                {
                    control.Dispose();
                    return;

                }

                var arrControlHasType = (from dr in dtFormControl.AsEnumerable()
                          where dr.Field<string>(LFormControl.Columns.FormName).Equals(FormName) &
                                dr.Field<string>(LFormControl.Columns.ControlName).Equals(control.Name) &
                                !string.IsNullOrEmpty(Utility.sDbnull(dr.Field<object>(LFormControl.Columns.ControlTypeName)))
                          select dr).ToList();

                string[] arrItem_Name = new string[] { };
                if (control.Name == "tabTestInfo")
                {
                    Console.WriteLine(control.Name);
                }
                if (arrControlHasType.Count <= 0)
                {
                    //arrItem_Name = (from ctrl in control.Controls.Cast<Control>() select ctrl.Name).ToArray();
                    var arrControl = (from ctrl in control.Controls.Cast<Control>() select ctrl).ToList();
                    //List<Control> listControlName = new List<string>();
                    //foreach (Control ctrl in control.Controls)
                    //{
                    //    listControlName.Add(ctrl.Name);
                    //}
                    foreach (Control ctrl in arrControl)
                    {
                        
                        PerformInductionMethod(ctrl);
                    }
                    return;
                }


                switch (Utility.sDbnull(arrControlHasType[0][LFormControl.Columns.ControlTypeName]).ToUpper())
                {
                    case "WIN.TOOLSTRIP":
                        ToolStrip toolStrip = (ToolStrip)control;
                        arrItem_Name = (from item in toolStrip.Items.Cast<ToolStripItem>()
                                            where !UserHasAccess(item.Name)
                                            select item.Name).ToArray();
                        foreach (string item_Name in arrItem_Name)
                        {
                            toolStrip.Items[item_Name].Dispose();
                        }
                        break;
                    case "WIN.CONTEXTMENUSTRIP":
                        if (!arrAllowed_Control_Name.Contains(control.Name))
                            arrItem_Name = (from item in control.ContextMenuStrip.Items.Cast<ToolStripItem>() 
                                            where item !=null
                                            select item.Name).ToArray();

                        //else arrItem_Name = (from item in control.ContextMenuStrip.Items.Cast<ToolStripItem>()
                                                             
                        //                     where arrControl_Name.Contains(item.Name) & !arrAllowed_Control_Name.Contains(item.Name)
                        //                     select item.Name).ToArray();
                        foreach (string item_Name in arrItem_Name)
                        {
                            control.ContextMenuStrip.Items[item_Name].Enabled = false;
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private bool UserHasAccess(string Ctrl_Name)
        {
            if (arrControl_Name.Contains(Ctrl_Name) & !arrAllowed_Control_Name.Contains(Ctrl_Name))
            {

                //var count = (from dr in dtUserControlRelation.AsEnumerable()
                //             where dr.Field<string>("Control_Name").Equals(Ctrl_Name)
                                 //(string.IsNullOrEmpty(Property_Name) |
                                 //(dr.Field<object>(LFormControl.Columns.PropertyName) != null
                                 //& Utility.sDbnull(dr.Field<string>(LFormControl.Columns.PropertyName)).ToUpper() == Utility.sDbnull(Property_Name)))
                //             select dr).Count();
                //if (count <= 0) return false;
                return false;
            }
            return true;

        }
    }

    public class ResetTabKey
    {
        public Control[] ArrControl { get; set; }

        public void Implement()
        {
            try
            {
                if (ArrControl == null) return;
                if (ArrControl.Count() < 2) return;
                for (int index = 0; index < ArrControl.Count(); index++)
                {
                    ArrControl[index].PreviewKeyDown += TabControlOnPreviewKeyDown;
                    ArrControl[index].KeyDown += TabControlOnKeyDown;
                }
            }
            catch (Exception)
            {
            }
        }

        private void TabControlOnKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Tab)
                    e.Handled = false;
            }
            catch (Exception)
            {
            }
        }

        private void TabControlOnPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Tab) return;
                int i;
                for (i = 0; i < ArrControl.Count(); i++)
                {
                    if ((Control)sender == ArrControl[i])
                        break;
                }
                if (e.Shift)
                {
                    if (i > 0)
                    {
                        ArrControl[i - 1].Focus();
                        e.IsInputKey = true;
                    }
                }
                else if (i < ArrControl.Count() - 1)
                {
                    ArrControl[i + 1].Focus();
                    e.IsInputKey = true; 
                }
                
            }
            catch (Exception)
            {
            }
        }
    }
}