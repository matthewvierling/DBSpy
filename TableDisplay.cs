using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBSpy{

    public class TableDisplay : Panel{

        private List<TreeNode> tablesNode = new List<TreeNode>();
        public TreeView tablesTree = new TreeView();
        private string currentDatabase;
        //function to execute on double click
        private Func<int> functionToCallOnDoubleClick;
        public TableDisplay(string database, List<string> tables, Func<int> method){

            this.functionToCallOnDoubleClick = method;

            this.currentDatabase = database;
            this.CreateTablesNode(tables);
            this.tablesTree.Nodes.Add(new TreeNode(this.currentDatabase, tablesNode.ToArray()));
            this.tablesTree.DoubleClick += new System.EventHandler(this.TableTreeClick);
            this.tablesTree.Dock = DockStyle.Fill;

            //adding tree to container
            this.Controls.Add(this.tablesTree);

            this.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left;

        }

        private void CreateTablesNode(List<string> tables){

            foreach (string table in tables){
                tablesNode.Add(new TreeNode(table));
            }

            return;
        }

        private void TableTreeClick(object sender, EventArgs e){
            int trash = this.functionToCallOnDoubleClick();
        }
    }

}