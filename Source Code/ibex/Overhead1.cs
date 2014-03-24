using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //used for binaryformatter
using System.Runtime.Serialization; //used for binaryformatter

namespace ibex
{
    public partial class Overhead1 : Form
    {
        BinaryFormatter formatter = new BinaryFormatter(); //taken from serialization
 
        public Overhead1()
        {
            InitializeComponent();
        }

         
        private void Overhead1_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            DataColumn dc = new DataColumn("Col1", System.Type.GetType("System.String"));
            dt1.Columns.Add(dc);
      
            DataTable dt2 = new DataTable();
            DataColumn dc2 = new DataColumn("Col2", System.Type.GetType("System.Int32"));  
            dt2.Columns.Add(dc2);

            DataTable dt3 = new DataTable();
            DataColumn dc3 = new DataColumn("Col1", System.Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("Col2", System.Type.GetType("System.Int32"));
            dt3.Columns.Add(dc3);
            dt3.Columns.Add(dc4);

            DataTable results = new DataTable();
            DataColumn r1 = new DataColumn("strSize", System.Type.GetType("System.Int32"));
            DataColumn r2 = new DataColumn("strRows", System.Type.GetType("System.Int32"));
            DataColumn r3 = new DataColumn("intSize", System.Type.GetType("System.Int32"));
            DataColumn r4 = new DataColumn("intRows", System.Type.GetType("System.Int32"));
            DataColumn r5 = new DataColumn("strIntSize", System.Type.GetType("System.Int32"));
            DataColumn r6 = new DataColumn("strIntRows", System.Type.GetType("System.Int32"));
            results.Columns.Add(r1);
            results.Columns.Add(r2);
            results.Columns.Add(r3);
            results.Columns.Add(r4);
            results.Columns.Add(r5);
            results.Columns.Add(r6);

            for (int i = 0; i <= 1010; i+=10)
            {
                DataRow dr = results.NewRow();
                
                dt1.Clear();

                for (int count = 10; count <= i; count++)
                {
                    DataRow _ravi = dt1.NewRow();
                    _ravi["Col1"] = "Str Test";
                    dt1.Rows.Add(_ravi);
                }
                using (Stream s = new MemoryStream())
                {
                    formatter.Serialize(s, dt1);

                    Console.WriteLine("string size: " + s.Length);
                    dr["strSize"] = s.Length;
                    dr["strRows"] = dt1.Rows.Count;
                }

                dt2.Clear();

                for (int count = 10; count <= i; count++)
                {
                    DataRow _ravi2 = dt2.NewRow();
                    _ravi2 = dt2.NewRow();
                    _ravi2["Col2"] = 0;
                    dt2.Rows.Add(_ravi2);
                }
                using (Stream s = new MemoryStream())
                {

                    formatter.Serialize(s, dt2);

                    Console.WriteLine("int size: " + s.Length);
                    dr["intSize"] = s.Length;
                    dr["intRows"] = dt2.Rows.Count;
                }

                dt3.Clear();

                for (int count = 10; count <= i; count++)
                {
                    DataRow _ravi3 = dt3.NewRow();
                    _ravi3 = dt3.NewRow();
                    _ravi3["Col1"] = "str Test";
                    _ravi3["Col2"] = 0;
                    dt3.Rows.Add(_ravi3);
                }
                using (Stream s = new MemoryStream())
                {

                    formatter.Serialize(s, dt3);

                    Console.WriteLine("string/int size; " + s.Length);
                    dr["strIntSize"] = s.Length;
                    dr["strIntRows"] = dt3.Rows.Count;
                }
                dt1.Dispose();
                dt2.Dispose();
                dt3.Dispose();

                results.Rows.Add(dr);
            }
            gvResults.DataSource = results;
        }

    }
}
