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
using System.IO.Ports;
using System.Threading;

namespace Bittner_WPF1
{   
    
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SerialPort myport;
        public MainWindow()
        {
            

            InitializeComponent();
            


            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {

                txb_port.Text = s; 

            }
            myport = new SerialPort();
            myport.BaudRate = 9600;
           
            myport.PortName = txb_port.Text;
            myport.Open();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myport.Close();
            Close();
        }

    

      

        private void btn_odeslat_Click(object sender, RoutedEventArgs e)
        {
            string data_ry = txb_odeslat.Text;


            myport.Write(data_ry);
            // myport.Close();

            txb_start.Text = "Odesláno !!!";


            string data_rx;

           

            data_rx = myport.ReadLine();

            txb_prijem.Text = data_rx;





        }

        private void Button_Click_Clear_send(object sender, RoutedEventArgs e)
        {
            txb_odeslat.Text = " ";
            
        }


        private void txb_start_Loaded(object sender, RoutedEventArgs e)
        {
            if (myport.IsOpen == true)
            {
                txb_start.Text = "Connection OK ..." +
                    " Port is open ..." +
                    " Ready for work.";
               
            }
            else
                txb_start.Text = "Error for fix" +
                    "call: 776647871";
        }
    }
}

