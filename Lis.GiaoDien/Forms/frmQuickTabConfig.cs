using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public partial class frmQuickTabConfig : Form
    {
        public List<TabOrderItem> _items;
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

        public frmQuickTabConfig(List<TabOrderItem> items)
        {
            _items = items;
            InitializeComponent();
        }

        private void frmQuickTabConfig_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
        //    dataGridView1.RowPostPaint += Utilities.GridviewRowPostPaint;
            dataGridView1.DataSource = _items;
            dataGridView1.Focus();
        }


        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            if (dragBoxFromMouseDown == Rectangle.Empty || dragBoxFromMouseDown.Contains(e.X, e.Y)) return;
            DragDropEffects dropEffect = dataGridView1.DoDragDrop(dataGridView1.Rows[rowIndexFromMouseDown],
                                                                  DragDropEffects.Move);
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                Size dragSize = SystemInformation.DragSize;
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width/2),
                                                               e.Y - (dragSize.Height/2)),
                                                     dragSize);
            }
            else
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));
                rowIndexOfItemUnderMouseToDrop = dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
                if (e.Effect == DragDropEffects.Move)
                {
                    TabOrderItem rowToMove = _items[rowIndexFromMouseDown];
                    TabOrderItem row = rowToMove.Clone();
                    _items.RemoveAt(rowIndexFromMouseDown);
                    _items.Insert(rowIndexOfItemUnderMouseToDrop, row);
                    dataGridView1.CurrentCell = dataGridView1[1, rowIndexOfItemUnderMouseToDrop];
                    dataGridView1.Refresh();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void frmQuickReorderTestSequence_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
                dataGridView1.CurrentCell = dataGridView1[1, dataGridView1.CurrentRow.Index];
            for (int i = 0; i < _items.Count; i++)
                _items[i].ControlTabIndex = i;
            _items = _items.OrderBy(o => o.ControlTabIndex).ToList();
        }

        private void frmQuickReorderTestSequence_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}