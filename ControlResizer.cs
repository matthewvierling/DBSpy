using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBSpy{

    public class ControlResizer : TableLayoutPanel{

        private Control controlToResize;
        private ContainerControl rightSideDragBox = new ContainerControl();
        private ContainerControl bottomSideDragBox = new ContainerControl();

        public ControlResizer(Control controlToResize):base(){

            this.controlToResize = controlToResize;
            this.AutoSize = true;
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            //this.Dock = DockStyle.Fill;

            this.InitializeDragBoxes();

            //adding items to table control
            this.Controls.Add(this.controlToResize, 1, 1);
            this.Controls.Add(this.rightSideDragBox, 2, 1);
            this.Controls.Add(this.bottomSideDragBox, 1, 2);

            //this.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left;

        }

        private void InitializeDragBoxes(){
            this.UpdateDragboxSize();

            //right
            this.rightSideDragBox.Cursor = Cursors.SizeWE;
            //need to add mouse event for click drag here

            //bottom
            this.bottomSideDragBox.Cursor = Cursors.SizeNS;
            //need to add mouse event for click drag here
        }

        private void UpdateDragboxSize(){
            //right
            this.rightSideDragBox.Size = new Size(2, this.controlToResize.Height);
            this.rightSideDragBox.BackColor = Color.Black;

            this.rightSideDragBox.Anchor = AnchorStyles.Left;
            this.rightSideDragBox.Anchor = AnchorStyles.Top;
            this.rightSideDragBox.Anchor = AnchorStyles.Bottom;

            //bottom
            this.bottomSideDragBox.Size = new Size(this.controlToResize.Width, 2);
            this.bottomSideDragBox.BackColor = Color.Black;

            this.bottomSideDragBox.Anchor = AnchorStyles.Top;
            this.bottomSideDragBox.Anchor = AnchorStyles.Left;
            this.bottomSideDragBox.Anchor = AnchorStyles.Right;
        }

    }

}