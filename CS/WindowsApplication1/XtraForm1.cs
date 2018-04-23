using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WindowsApplication1 {
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm {
        public XtraForm1(object dataSource) {
            InitializeComponent();
            textEdit1.DataBindings.Add("EditValue", dataSource, "Field");
        }

        private void simpleButton1_Click(object sender, EventArgs e) {

        }
    }
}