using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BitMiracle.Docotic.Pdf;
using System.IO;

namespace ExtractInformationFromPDFToCsv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnConvert.Visibility = System.Windows.Visibility.Hidden;
            Lbl_VPDF.Visibility = System.Windows.Visibility.Hidden;
            


        }

        static readonly string textFile = @"C:\Temp\FinalResultPDF.txt";
        static readonly string pathFR = @"C:\Temp\FinalResult.csv";
        static readonly string I = "Patient Name";
        static readonly string II = "Age and Gender";
        static readonly string V = "Specimen Type";
        static readonly string VI = "Test Done";
        static readonly string VII = "IRON DEFICIENCY PROFILE";
        static readonly string VIII = "IRON - Ferrozine";
        static readonly string IX = "TOTAL IRON BINDING CAPACITY ( TIBC ) - Calculated";
        static readonly string X = "% TRANSFERRIN SATURATION - Calculated";
        static readonly string XI = "Observed Value";
        static readonly string XII = "Cholesterol - Oxidase,Easterase,Peroxidase";
        static readonly string XIII = "Triglyceride - EnzymaƟc Endpoint";
        static readonly string XIV = "HDL Cholesterol - Direct Measure-PEG";
        static readonly string XV = "LDL Cholesterol - Calculated";
        static readonly string XVI = "VLDL Cholesterol - Calculated";
        static readonly string XVII = "Total Cholesterol / HDL Cholesterol RaƟo - Calculated";
        static readonly string XVIII = "LDL / HDL Cholesterol RaƟo - Calculated";
        static readonly string XIX = "LIVER FUNCTION TEST";
        static readonly string XX = "Aspartate Transaminase (SGOT) - UV Without P5P";
        static readonly string XXI = "IFCC";
        static readonly string XXII = "Alanine Transaminase (SGPT) - UV Without P5P IFCC";
        static readonly string XXIII = "Total Bilirubin - Diazonium Ion";
        static readonly string XXIV = "Direct Bilirubin - DiazoƟzaƟon";
        static readonly string XXV = "Indirect Bilirubin - Calculated";
        static readonly string XXVI = "Alkaline Phosphatase - PNPP,AMP Buīer";
        static readonly string XXVII = "Total Protein - Biuret";
        static readonly string XXVIII = "Albumin - Bromocresol Green (BCG)";
        static readonly string XXIX = "Globulin - Calculated";
        static readonly string XXX = "A/G RaƟo - Calculated";
        static readonly string XXXI = "Gamma Glutamyl Transferase (GGT) - G-glutamyl";
        static readonly string XXXII = "carboxy nitroanilide";
        static readonly string XXXIII = "RENAL / KIDNEY FUNCTION TEST";
        static readonly string XXXIV = "Urea - Urease- UV";
        static readonly string XXXV = "BUN - Calculated";
        static readonly string XXXVI = "CreaƟnine - Jaīe";
        static readonly string XXXVII = "Calcium - Bapta";
        static readonly string XXXVIII = "Uric Acid - Uricase,UV";
        static readonly string XXXIX = "Phosphorous - Phosphomolybdate-UV";
        static readonly string XL = "SERUM ELECTROLYTES";
        static readonly string XLI = "Sodium - ISE Indirect";
        static readonly string XLII = "Potassium - ISE Indirect";
        static readonly string XLIII = "Chloride - ISE Indirect";
        static readonly string XLIV = "THYROID PROFILE";
        static readonly string XLV = "TOTAL TRIIDOTHYRONINE ( T3 ) ";
        static readonly string XLVI = "TOTAL THYROXINE ( T4 )";
        static readonly string XLVII = "ULTRASENSITIVE THYROID STIMULATING HORMONE ( TSH )";
        static readonly string XLVIII = "VITAMIN B12";
        static readonly string XLIX = "Vitamin B12 Serum - ECLIA";
        static readonly string L = "FASTING BLOOD SUGAR";
        static readonly string LI = "FasƟng Blood Sugar ( FBS ) - Hexokinase";
        static readonly string LII = "COMPLETE BLOOD COUNT";
        static readonly string LIII = "Total Leucocyte Count";
        static readonly string LIV = "Neutrophils";
        static readonly string LV = "Lymphocytes";
        static readonly string LVI = "Monocytes";
        static readonly string LVII = "Eosinophils";
        static readonly string LVIII = "Basophils";
        static readonly string LIX = "Absolute Neutrophil Count";
        static readonly string LX = "Absolute Lymphocyte Count";
        static readonly string LXI = "Absolute Monocyte Count";
        static readonly string LXII = "Absolute Eosinophil Count";
        static readonly string LXIII = "Absolute Basophil Count";
        static readonly string LXIV = "RBCs";
        static readonly string LXV = "Haemoglobin";
        static readonly string LXVI = "HEMATOCRIT(P.C.V.)";
        static readonly string LXVII = "M.C.V.";
        static readonly string LXVIII = "M.C.H.";
        static readonly string LXIX = "M.C.H.C";
        static readonly string LXX = "RED CELL DISTRIBUTION WIDTH-CV (RDW-CV)";
        static readonly string LXXI = "RED CELL DISTRIBUTION WIDTH-SD (RDW-SD)";
        static readonly string LXXII = "Platelet count";
        static readonly string LXXIII = "M.P.V.";
        static readonly string LXXIV = "PLATELET DISTRIBUTION WIDTH (PDW)";
        static readonly string LXXV = "PLATELETCRIT (PCT)";
        static readonly string LXXVI = "GLYCOSYLATED HAEMOGLOBIM PROFILE";
        static readonly string LXXVII = "GLYCOSYLATED HAEMOGLOBIN (HBA1C)";
        static readonly string LXXVIII = "Mean Blood Glucose";

        List<string> data = new List<string>();
        List<string> finalResult = new List<string>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                FileNameTextBox.Text = openFileDlg.FileName;
                string Extension = FileNameTextBox.Text.Substring(FileNameTextBox.Text.Length-4, 4);
                
                
                if (Extension != ".pdf")
                {
                    MessageBox.Show("I can´t read this type of file","File wrong", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    using (var pdf = new PdfDocument(openFileDlg.FileName))
                    {
                        string formattedText = pdf.GetTextWithFormatting(); // or use pdf.Pages[i].GetTextWithFormatting()
                        //Console.WriteLine(formattedText);
                        //TextBlock1.Text = formattedText;
                        
                        ViewPDF.Navigate(FileNameTextBox.Text);

                        if (File.Exists(textFile))
                        {
                            File.Delete(textFile);
                        }

                        using (StreamWriter sw = File.CreateText(textFile))
                        {
                            sw.Write(formattedText);
                        }

                        btnConvert.Visibility = System.Windows.Visibility.Visible;
                        Lbl_VPDF.Visibility = System.Windows.Visibility.Visible;
                    }
                }
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            // Read a text file line by line.  
            string[] lines = File.ReadAllLines(textFile);
            List<string> listText = new List<string>();

            foreach (string line in lines)
            {
                data.Add(line);
            }


                    foreach (var x in data)
                    {
                        string s = x;

                        if (s.Contains(I)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (s.Contains(II)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(V)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(VI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(VII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(VIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(IX)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(X)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XIV)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XV)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XVI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XVII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XVIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XIX)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XX)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXIV)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXV)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXVI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXVII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXVIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXIX)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXX)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXXI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXXII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXXIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXXIV)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXXV)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXXVI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXXVII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXXVIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XXXIX)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XL)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XLI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XLII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XLIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XLIV)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XLV)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XLVI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XLVII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XLVIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(XLIX)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(L)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LIV)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LV)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LVI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LVII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LVIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LIX)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LX)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXIV)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXV)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXVI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXVII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXVIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXIX)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXX)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXXI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXXII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXXIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXXIV)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXXV)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXXVI)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXXVII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                        if (x.Contains(LXXVIII)) { if (!finalResult.Contains(s)) { finalResult.Add(x); } }
                    }


            MessageBox.Show("Proceso terminado");

            if (File.Exists(pathFR))
            {
                File.Delete(pathFR);
            }

            if (!File.Exists(pathFR))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(pathFR))
                {
                    

                    foreach (var i in finalResult)
                    {
                        sw.WriteLine("{0}",i);
                    }
                }

                ViewCSV.Navigate(pathFR);
            }

            

            
        }
    }
}
