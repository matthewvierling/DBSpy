using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBSpy{

    public class TableDisplay : Panel{

        private List<TreeNode> tablesNode = new List<TreeNode>();
        private TreeView tablesTree = new TreeView();
        private string currentDatabase;
        public TableDisplay(string database, List<string> tables){

            this.currentDatabase = database;
            this.CreateTablesNode(tables);
            this.tablesTree.Nodes.Add(new TreeNode(this.currentDatabase, tablesNode.ToArray()));
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
    }

}