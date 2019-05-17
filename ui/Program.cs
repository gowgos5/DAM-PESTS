using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace BitsBolts
{
    static class Program
    {
        static Form1 form;
        static MqttClient client;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new Form1();
            
            // MQTT
            // create client instance 
            client = new MqttClient("VERNON-PC");

            // register to message received 
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = "ui";
            client.Connect(clientId);
            // Listen to backend server for processed images.
            client.Subscribe(new string[] { "dam-pests/ui" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { "dam-pests/heat" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

            Application.Run(form);
            client.Disconnect();
        }

        private static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // handle message received
            if (e.Topic == "dam-pests/ui")
            {
                // camera number
                var cam = System.Text.Encoding.Default.GetString(e.Message);
                form.CameraUpdate(cam);
            }
            else
            {
                // format - sensorNum ON/OFF
                string[] sensor = System.Text.Encoding.Default.GetString(e.Message).Split(' ');
                form.SensorUpdate(sensor[0], sensor[1]);
            }
        }

        public static void getCameraFeed(int selectedCamera)
        {
            if (selectedCamera == 16)
            {
                // Publish to cameras for unprocessed images.
                client.Publish("dam-pests/camera", Encoding.UTF8.GetBytes(selectedCamera.ToString()), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            }

            form.ImageUpdate(selectedCamera);
        }
    }
}
