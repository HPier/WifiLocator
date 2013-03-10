using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NativeWifi;

namespace WindowsFormsApplication1
{
    class NetworkDetection
    {
        // Valore soglia al di sopra si inizia a penalizzare la stima
        private static int threshold = 5;

        private float estimation;
        Wlan.WlanAvailableNetwork toAnalyze; // Network to be analyzed
        Wlan.WlanAvailableNetwork RecordedNetwork; // Network recorded

        // This method will compute the probability that the network is listened in the same way as recorded, comparing differences between
        // recorded parameters and listened ones.
        // The return value is a float between 0 and 1;
        private float estimationNetwork(Wlan.WlanAvailableNetwork toAnalyze, Wlan.WlanAvailableNetwork RecordedNetwork)
        {
            float localEstimation = 0;
            if (checkCompatibilitySignal(toAnalyze.wlanSignalQuality, RecordedNetwork.wlanSignalQuality))
            {
                return 1;
            }
            else return 0.5F;
            //che = toAnalyze.wlanSignalQuality - RecordedNetwork.wlanSignalQuality;
            //Wlan.WlanAvailableNetwork.dot11BssType type = toAnalyze.dot11BssType;
            //uint QuaityDifference = toAnalyze.wlanSignalQuality - RecordedNetwork.wlanSignalQuality;
            //uint QuaityDifference = toAnalyze.wlanSignalQuality - RecordedNetwork.wlanSignalQuality;
        }

        public float Estimation(List<Wlan.WlanAvailableNetwork> toAnalyze, List<Wlan.WlanAvailableNetwork> RecordedNetwork)
        {
            List<float> estimations = new List<float>();
            float finalEstimation = 0;
            var i = 0;
            // Non è ottimizzato, è solo semplice            
            foreach (Wlan.WlanAvailableNetwork network in RecordedNetwork)
            {
                foreach (Wlan.WlanAvailableNetwork network1 in toAnalyze)
                {
                    if (network1.dot11BssType.CompareTo(network.dot11BssType) == 0)
                    {
                        estimations[i] = estimationNetwork(network, network1);
                        i++;
                        RecordedNetwork.Remove(network);
                        toAnalyze.Remove(network1);
                    }
                }

                if (RecordedNetwork.Count != 0)
                {
                    // Reti rilevate di norma non sono state rilevate questa volta!!!
                }

                if (toAnalyze.Count != 0)
                {
                    // reti in più rilevate questa volta
                }
            }
            return finalEstimation;
        }

        // Adesso comincerei ad utilizzare dei booleani poi possiamo passare a qualcosa di più raffinato
        private static bool checkCompatibilitySignal(uint signalstrenght, uint othersignal)
        {
            var mismatch = Math.Abs(signalstrenght - othersignal);
            if (mismatch < NetworkDetection.threshold)
            {
                return true; // La misurazione fatta è compatibile
            }
            return false; // La misurazione non è compatibile
        }

        //private static int comparae(Wlan.WlanAvailableNetwork one, Wlan.WlanAvailableNetwork other)
        //{
        //    return one. .CompareTo(other.);
        //}
        public static string macToString(byte[] macAddr)
        {
            var macAddrLen = (uint)macAddr.Length;
            var str = new string[(int)macAddrLen];
            for (int i = 0; i < macAddrLen; i++)
            {
                str[i] = macAddr[i].ToString("x2");
            }
            string mac = string.Join("", str);
            return mac;
        }

    }
}
