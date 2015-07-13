using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using Lis.GiaoDien.Class;

namespace Lis.GiaoDien
{
    class BetterTextbox : TextBox
    {
        #region // khoi dung
        private ListBox lb1 = new ListBox ();
        private bool IsAddedLB = false;
        private List<clsHanhChinh> dsdvhanhchinh;
        private List<clsNgheNghiep> dsnghenghiep;
        private List<clsChucVu> dsChucVu;
        private List<clsTenPhongBan> dsPhongBan;
        public BetterTextbox()
        {
            Initialize();
            lb1.Visible = false;
        }
        public void SentDsNgheNghiep(List<clsNgheNghiep> dsnghenghiep)
        {
            this.dsnghenghiep = dsnghenghiep;
        }
        public void donvihc(List<clsHanhChinh> dsdvhc)
        {
            this.dsdvhanhchinh = dsdvhc;
        }
        public void ChucVu(List<clsChucVu> dsChucVu)
        {
            this.dsChucVu = dsChucVu;
        }
        public void PhongBan(List<clsTenPhongBan> dsPhongBan)
        {
            this.dsPhongBan = dsPhongBan;
        }
       
        private void Initialize()
        {
            this.TextChanged += This_TextChanged;
            Leave += This_Leave;
            KeyDown += This_KeyDown;

            lb1.VisibleChanged += lb1_VisibleChanged;
            lb1.MouseMove += lb1_MouseMove;
            lb1.MouseDown += lb1_MouseDown;
        }
        #endregion

        #region // khu Event ListBox
        private void lb1_VisibleChanged(object sender, EventArgs e)
        {
             if (!lb1.Visible)
             {
                 lb1.Items.Clear();
             }
        }
        private void lb1_MouseMove(object sender, MouseEventArgs e)
        {
            if (lb1.Items.Count > 0)
            {
                int x = lb1.IndexFromPoint(e.Location);
                if (x >= 0)
                {
                    lb1.SelectedIndex = x;
                }
            }
        }

        private void lb1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (lb1.SelectedIndex > -1)
            {
                Text = lb1.SelectedItem.ToString();
                lb1.Visible = false;
                Focus();
                Select(Text.Length, 0);
            }
        }
        private void ShowLisBox()
        {
            if (!IsAddedLB)
            {
                Parent.Controls.Add(lb1);
                lb1.Left = Left;
                lb1.Top = Top + Height;

                IsAddedLB = true;
            }
            if (lb1.Items.Count >0 )
            {
                lb1.Size = new Size(this.Size.Width, Math.Min((lb1.Items.Count + 1) * lb1.ItemHeight, 150));
                lb1.Visible = true;
                lb1.SelectedIndex = 0;
                lb1.BringToFront();
            }
        }
        #endregion

        #region // khu event TextBox
        private void This_TextChanged(object sender, EventArgs e)
        {
            lb1.Visible = false;
            string StrToSearch = UnUnicodeText(Text);
            if (StrToSearch.Length > 0)
            {
                if (dsdvhanhchinh != null)
                {
                    foreach (var v in dsdvhanhchinh)
                    {
                        if (UnUnicodeText(v.TenTenDonVi).Contains(StrToSearch))
                        {
                            lb1.Items.Add(v.TenTenDonVi);
                        }
                    }
                    ShowLisBox();
                }
                if (dsnghenghiep != null)
                {
                    foreach (var v in dsnghenghiep)
                    {
                        if (UnUnicodeText(v.TenNgheNghiep).Contains(StrToSearch))
                        {
                            lb1.Items.Add(v.TenNgheNghiep);
                        }
                    }
                    ShowLisBox();
                }
                if (dsPhongBan != null)
                {
                    foreach (var v in dsPhongBan)
                    {
                        if (UnUnicodeText(v.TenPhongBan).Contains(StrToSearch))
                        {
                            lb1.Items.Add(v.TenPhongBan);
                        }
                    }
                    ShowLisBox();
                }
                if (dsChucVu != null)
                {
                    foreach (var v in dsChucVu)
                    {
                        if (UnUnicodeText(v.TenChucVu).Contains(StrToSearch))
                        {
                            lb1.Items.Add(v.TenChucVu);
                        }
                    }
                    ShowLisBox();
                }
            }

        }
        private void This_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && lb1.Visible)
            {
                int indez = lb1.SelectedIndex;
                indez += 1;
                lb1.SelectedIndex = Math.Min(indez, lb1.Items.Count - 1);
                Select(Text.Length, 0);
            }
            if (e.KeyCode == Keys.Up && lb1.Visible)
            {
                int indez = lb1.SelectedIndex;
                indez -= 1;
                lb1.SelectedIndex = Math.Max(indez, 0);
                Select(Text.Length, 0);
            }
            if (e.KeyCode == Keys.Enter && lb1.Visible)
            {
                if (lb1.SelectedIndex > -1)
                {
                    Text = lb1.SelectedItem.ToString();
                    lb1.Visible = false;
                    Select(Text.Length, 0);
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                if (Focused)
                {
                    if (lb1.SelectedIndex > -1)
                    {
                        Text = lb1.SelectedItem.ToString();
                        lb1.Visible = false;
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void This_Leave(object sender, EventArgs e)
        {
            if (!lb1.Focused)
            {
                lb1.Visible = false;
            }
        }
        
        public static string UnUnicodeText(string s)
        {
            s = s.ToLower();
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            s = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            s = s.Replace(" ", "");
            s = s.Replace("\n", "");
            s = s.Replace("\t", "");
            s = s.Replace("\r", "");
            return s;
        }
        #endregion
    }
}
