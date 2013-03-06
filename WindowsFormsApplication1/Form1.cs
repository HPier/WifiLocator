using NativeWifi;


using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();
        
        public Form1()
        {
            InitializeComponent();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            lstNetworks.Columns.Add("Nome",100);
            lstNetworks.Columns.Add("Crittografia", 100);
            lstNetworks.Columns.Add("Potenza", 100);
            lstNetworks.Columns.Add("dot11BssType", 100);
            lstNetworks.Columns.Add("dot11DefaultAuthAlgorithm", 100);
            lstNetworks.Columns.Add("dot11DefaultCipherAlgorithm", 100);
            lstNetworks.Columns.Add("flag", 100);
            lstNetworks.Columns.Add("GetHashCode", 100);
            lstNetworks.Columns.Add("GetType", 100);
            lstNetworks.Columns.Add("morePhyTypes", 100);
            lstNetworks.Columns.Add("networkConnectable", 100);
            lstNetworks.Columns.Add("numberOfBssids", 100);
            lstNetworks.Columns.Add("profileName", 100);
            lstNetworks.Columns.Add("securityEnabled", 100);
            lstNetworks.Columns.Add("wlanNotConnectableReason", 100);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            lstNetworks.Items.Clear();

            WlanClient client = new WlanClient();
            String testo1 = "--->Cattura fatta in: " + posizione.Text + " in data " + System.DateTime.Now.ToString() + "\r\n";
            if (posizione.Text == "")
            {
                MessageBox.Show("inserisci il posto per proseguire");
                return;
            }
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
              
                Wlan.WlanBssEntry[] wlanBssEntries = wlanIface.GetNetworkBssList();
                foreach (Wlan.WlanBssEntry wlanBssEntry in wlanBssEntries)
                {


                    
                    byte[] macAddr = wlanBssEntry.dot11Bssid;
                    var macAddrLen = (uint)macAddr.Length;
                    var str = new string[(int)macAddrLen];
                    for (int i = 0; i < macAddrLen; i++)
                    {
                        str[i] = macAddr[i].ToString("x2");
                    }
                    string mac = string.Join("", str);
                    mac = " wlanBssEntry: " + wlanBssEntry.dot11Ssid.ToString() + " dot11BssPhyType: " + wlanBssEntry.dot11BssType.ToString() + " dot11BssPhyType: " + wlanBssEntry.dot11BssPhyType.ToString() + " frequenza khz " + wlanBssEntry.chCenterFrequency.ToString() + " capabilityInformation " + wlanBssEntry.capabilityInformation.ToString() + " beaconPeriod: " + wlanBssEntry.beaconPeriod.ToString() + " MAC: " + mac + "\r\n";
                     
                    System.IO.File.AppendAllText("catture.txt",mac);
                   // MessageBox.Show(mac);
                }

                //MessageBox.Show("fine");


                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    Wlan.Dot11Ssid ssid = network.dot11Ssid;
                    string networkName = Encoding.ASCII.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
                    //ListViewItem item = new ListViewItem(networkName);
                    //item.SubItems.Add(network.dot11DefaultCipherAlgorithm.ToString());
                    //item.SubItems.Add(network.wlanSignalQuality + "%");
                    //item.SubItems.Add(network.dot11BssType.ToString());
                    //item.SubItems.Add(network.dot11DefaultAuthAlgorithm.ToString());
                    //item.SubItems.Add(network.dot11DefaultCipherAlgorithm.ToString());
                    //item.SubItems.Add(network.flags.ToString());
                    //item.SubItems.Add(network.GetHashCode().ToString());
                    //item.SubItems.Add(network.GetType().ToString());
                    //item.SubItems.Add(network.morePhyTypes.ToString());
                    //item.SubItems.Add(network.networkConnectable.ToString());
                    //item.SubItems.Add(network.numberOfBssids.ToString());
                    //item.SubItems.Add(network.profileName.ToString());
                    //item.SubItems.Add(network.securityEnabled.ToString());
                    //item.SubItems.Add(network.wlanNotConnectableReason.ToString());

                    string testo = testo1 + "  nome rete: " + networkName + " potenza segnale: " + network.wlanSignalQuality + "% HashCode:" + network.GetHashCode().ToString() + " Bssid: "+ network.numberOfBssids.ToString() + "\r\n";
                    testo1 = "   ";
                    System.IO.File.AppendAllText("catture.txt", testo);

                           

                    //lstNetworks.Items.Add(item);
                }
                client.chiudi();
            }
             
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}