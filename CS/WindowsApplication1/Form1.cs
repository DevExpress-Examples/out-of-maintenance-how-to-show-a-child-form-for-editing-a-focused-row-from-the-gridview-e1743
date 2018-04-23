using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            list = new BindingList<MyObject>();
            
            for (int i = 0; i < 10; i++) {
                list.Add(new MyObject(i.ToString()));
            }
            
            gridControl1.DataSource = list;

        }


        BindingList<MyObject> list;

        private void simpleButton1_Click(object sender, EventArgs e) {
			using(XtraForm1 f = new XtraForm1(list)) {
				f.BindingContext = this.BindingContext;
				if(f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
					CurrencyManager cm = (CurrencyManager)this.BindingContext[list];
					cm.EndCurrentEdit();
				}
			}
        }

    }

    public class MyObject: INotifyPropertyChanged {
        public MyObject(string str) {
            field = str;
        }
        private string field;
        public string Field {
            get { return field; }
            set {
                field = value;
                NotifyPropertyChanged("Field");
            }
        }


        #region INotifyPropertyChanged Members

        private void NotifyPropertyChanged(String info) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}