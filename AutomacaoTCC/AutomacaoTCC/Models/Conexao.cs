﻿using OpenNETCF.MQTT;
using System.Diagnostics;
using System.Threading;
using System;

namespace AutomacaoTCC.Models
{
    public class Conexao
    {
        private const string iplan = "172.20.10.4";
        //private const string iplan = "192.168.1.5";


        public string IpLan {
            get { return iplan; }
            
        }

        public string IpWan { get; set; }
        public bool StatusServidor { get; set; }
        public Vpn Vpn { get; set; }

        


        public static MQTTClient Conectar() {
            MQTTClient client = new MQTTClient(iplan, 1883);
            client.Connect(iplan);
            return client;

        }

        //client.Publish("home/quarto/01", "OFF",QoS.FireAndForget,false);
        public static void Publicar(string dispositivo, string comando) {
            MQTTClient client = Conectar();
            client.Publish(dispositivo, comando, QoS.FireAndForget, false);
        }


        
    }
}