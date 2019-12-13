using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBSpy{

    public class ControlResizer : TableLayoutPanel{

        private Control controlToResize;
        private ContainerControl rightSideDragBox = new ContainerControl();
        private ContainerControl bottomSideDragBox = new ContainerControl();
        private bool rightSideDragboxClickDown = false;
        private bool bottomSideDragboxClickDown = false;
        private Point startPoint;

        public ControlResizer(Control controlToResize):base(){

            this.controlToResize = controlToResize;
            this.AutoSize = true;
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

            this.InitializeDragBoxes();

            //adding items to table control
            this.Controls.Add(this.controlToResize, 1, 1);
            this.Controls.Add(this.rightSideDragBox, 2, 1);
            this.Controls.Add(this.bottomSideDragBox, 1, 2);

        }

        private void InitializeDragBoxes(){
            this.UpdateDragboxSize();

            //right
            this.rightSideDragBox.Cursor = Cursors.SizeWE;
            this.rightSideDragBox.MouseDown += new MouseEventHandler(this.RightSideDragboxMouseDown);
            this.rightSideDragBox.MouseUp += new MouseEventHandler(this.RightSideDragboxMouseUp);
            this.rightSideDragBox.MouseMove += new MouseEventHandler(this.MouseMoving);

            //bottom
            this.bottomSideDragBox.Cursor = Cursors.SizeNS;
            this.bottomSideDragBox.MouseDown += new MouseEventHandler(this.BottomSideDragboxMouseDown);
            this.bottomSideDragBox.MouseUp += new MouseEventHandler(this.BottomSideDragboxMouseUp);
            this.bottomSideDragBox.MouseMove += new MouseEventHandler(this.MouseMoving);
            
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

        private void RightSideDragboxMouseDown(object sender, MouseEventArgs e){
            this.rightSideDragboxClickDown = true;
            this.startPoint = new Point(e.X, e.Y);
        }

        private void RightSideDragboxMouseUp(object sender, MouseEventArgs e){
            this.rightSideDragboxClickDown = false;
        }

        private void BottomSideDragboxMouseDown(object sender, MouseEventArgs e){
            this.bottomSideDragboxClickDown = true;
            this.startPoint = new Point(e.X, e.Y);
        }

        private void BottomSideDragboxMouseUp(object sender, MouseEventArgs e){
            this.bottomSideDragboxClickDown = false;
        }

        private void MouseMoving(object sender, MouseEventArgs e){
            if(this.rightSideDragboxClickDown){
                //resize right
                this.controlToResize.Size = new Size(this.controlToResize.Width + (e.X - this.startPoint.X),this.controlToResize.Height);
            }else if(this.bottomSideDragboxClickDown){
                //resize down
                this.controlToResize.Size = new Size(this.controlToResize.Width, this.controlToResize.Height + (e.Y - this.startPoint.Y));
            }
            this.UpdateDragboxSize();
        }

    }

}