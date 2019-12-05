using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBSpy{

    public class DataDisplay : Panel{

        DataGridView gridTable = new DataGridView();

        public DataDisplay(){

            this.gridTable.Dock = DockStyle.Fill;

            //adding grid table to container
            this.Controls.Add(gridTable);

            //this.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left;
            this.Dock = DockStyle.Fill;
        }

        public void UpdateDataTable(DataTable table){
            //binding data to the grid view
            this.gridTable.DataSource = new BindingSource(table, null);
        }


    }
}
