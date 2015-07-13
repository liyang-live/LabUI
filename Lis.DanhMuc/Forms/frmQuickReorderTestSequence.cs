using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SubSonic;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI
{
    public partial class frmQuickReorderTestSequence : Form
    {
        
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
        public string TestTypeId = "";

        public frmQuickReorderTestSequence()
        {
            InitializeComponent();
        }

        private void frmQuickReorderTestSequence_Load(object sender, EventArgs e)
        {
            dtDataControl = GetTestListByTestTypeId(TestTypeId);
            dataGridView1.AutoGenerateColumns = false;
          //  dataGridView1.RowPostPaint += Utilities.GridviewRowPostPaint;
            dataGridView1.DataSource = dtDataControl;
        }

        private static DataTable GetTestListByTestTypeId(string pTestTypeId)
        {
            var testListByTestTypeId =
                new Select().From(LStandardTest.Schema.Name).Where(LStandardTest.Columns.TestTypeId).IsEqualTo(
                    pTestTypeId).OrderAsc(LStandardTest.Columns.DataSequence).ExecuteDataSet().Tables[0];
            return testListByTestTypeId;
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                    
                    var dropEffect = dataGridView1.DoDragDrop(
                        dataGridView1.Rows[rowIndexFromMouseDown],
                        DragDropEffects.Move);
                }
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                var dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                                        dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
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
                // The mouse locations are relative to the screen, so they must be 
                // converted to client coordinates.
                var clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));

                // Get the row index of the item the mouse is below. 
                rowIndexOfItemUnderMouseToDrop = dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

                // If the drag operation was a move then remove and insert the row.
                if (e.Effect == DragDropEffects.Move)
                {
                    //var rowToMove2 = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                    var rowToMove = dtDataControl.Rows[rowIndexFromMouseDown];
                    var row = dtDataControl.NewRow();
                    for (int i = 0; i < dtDataControl.Columns.Count; i++)
                        row[i] = rowToMove[i];
                    
                    dtDataControl.Rows.RemoveAt(rowIndexFromMouseDown);
                    dtDataControl.Rows.InsertAt(row, rowIndexOfItemUnderMouseToDrop);
                    dataGridView1.CurrentCell = dataGridView1[1, rowIndexOfItemUnderMouseToDrop];
                    dtDataControl.AcceptChanges();
                    Console.WriteLine("OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private DataTable dtDataControl;

        private void frmQuickReorderTestSequence_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < dtDataControl.Rows.Count; i++)
            {
                var item = new LStandardTest(dtDataControl.Rows[i]["TestData_ID"]);
                item.DataSequence = i + 1;
                item.IsNew = false;
                item.Save();
            }
        }

        private void frmQuickReorderTestSequence_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape) Dispose(true);
        }
    }
}