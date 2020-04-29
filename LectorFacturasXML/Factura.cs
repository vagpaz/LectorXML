using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using LectorFacturasXML.Clases;

namespace LectorFacturasXML
{
    public partial class Factura : Form
    {
        private readonly MyExcel _xl = new MyExcel();
        private string _strExcelFile;
        public Factura()
        {
            InitializeComponent();
        }

        private static IEnumerable<string> ObtieneFiles(string carpeta)
        {
            string[] files = Directory.GetFiles(carpeta, "*.xml");
            return files;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<string> archivos = ObtieneFiles(txtDirectory.Text);
            foreach (string s in archivos)
            {
                var xFactura = new XmlDocument();
                //La ruta del documento XML permite rutas relativas
                //respecto del ejecutable!
                xFactura.Load(s);
                _strExcelFile = txtExcelFile.Text;
                int position = s.LastIndexOf("\\", System.StringComparison.Ordinal);
                string newName = cargar(xFactura);
                string complexName = s.Substring(0, position + 1) + newName;
                int i = 0;
                while (File.Exists(complexName + ".xml"))
                {
                    i++;
                    complexName = s.Substring(0, position + 1) + newName + "(" + i + ")";
                }
                File.Move(s, complexName + ".xml");
            }
            MessageBox.Show("Proceso finalizado");
        }

        private string cargar(XmlDocument xArchivo)
        {
            var fact = new Comprobante();
            foreach (var nodo in xArchivo.Cast<XmlNode>().Where(nodo => nodo.HasChildNodes && nodo.Name.ToUpper().Contains("COMPROBANTE")))
            {
                fact.Cargar(nodo.Attributes);
                fact.CargarNodos(nodo);
            }
            _xl.DataSource = _strExcelFile;
            return _xl.GuardarEnExcel(fact);
        }

        private string seleccionaCarpeta()
        {
            var x = new FolderBrowserDialog();
            return x.ShowDialog() == DialogResult.OK ? x.SelectedPath : "";
        }

        private static string SeleccionarArchivo()
        {
            FileDialog x = new OpenFileDialog
            {
                DefaultExt = "xls",
                Filter = @"Excel files (*.xls)|*.xls|All files (*.*)|*.*",
                AddExtension = true,CheckFileExists = false, CheckPathExists = true
            };
            return x.ShowDialog() == DialogResult.OK ? x.FileName : "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtExcelFile.Text = SeleccionarArchivo();
        }

        private void btnDirectory_Click(object sender, EventArgs e)
        {
            txtDirectory.Text = seleccionaCarpeta();
        }
    }
}