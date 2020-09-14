using SQLiteComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteProject1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SQLite sql = new SQLite(Environment.CurrentDirectory,"default");
            while (!sql.OpenDataBase())
            {
                while(!sql.CreateDataBase());
                if (sql.OpenDataBase())
                {
                    /****************************************************************************/
                    if (sql.ExecuteSQL("CREATE TABLE 'MEMBERS' ('age' int,'name' VARCHAR(50));"))
                    {
                        Console.WriteLine("SQL Execute  Success");
                    }
                    else
                    {
                        Console.WriteLine("SQL Execute Failed");
                    }
                }
                else
                {
                    Console.WriteLine("SQL Open Failed");
                }
            }
            sql.ExecuteSQL("INSERT INTO MEMBERS VALUES(25, \"최진우\"), (25, \"한국기술교육대학교\")");
            sql.ExecuteSQL("SELECT * FROM MEMBERS;");
            /* list[index][field]  */
            /* list[int][string]  */
            List<Dictionary<string, object>> list = sql.GetData();
            foreach(var item in list)
            {
                foreach(var key in item.Keys)
                {
                    Console.Write(key + " " + item[key] + ", ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
