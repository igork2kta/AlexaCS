using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput.Native;

namespace FauxmoCS
{
    public sealed class DeviceCreator
    {
        public string nome, tipo;
        public string? comando, argumento, tecla, tecla2, tecla3;

        public DeviceCreator(string nome, string tipo, string? comando, string? argumento, string? tecla, string? tecla2, string? tecla3)
        {
            this.nome = nome;
            this.tipo = tipo;
            this.comando = comando;
            this.argumento = argumento;
            this.tecla = tecla;
            this.tecla2 = tecla2;
            this.tecla3 = tecla3;
        }

        /*
        public static List<Device> CreateDeviceList(List<DeviceCreator> creatorList)
        {
            List<Device> deviceList = new();
            
            byte index = 1;
            foreach(DeviceCreator creator in creatorList)
            {
                if (creator.tipo == "COMANDO" && creator.comando != null && creator.argumento != null)
                    deviceList.Add(new CommandDevice(creator.nome, index, new ProcessStartInfo(creator.comando, creator.argumento)));
                
                else if (creator.tipo == "TECLA" && creator.tecla != null)
                    deviceList.Add(new KeyDevice(creator.nome, index, GetEnumValue<VirtualKeyCode>(creator.tecla),
                                        GetEnumValue<VirtualKeyCode>(creator.tecla2), GetEnumValue<VirtualKeyCode>(creator.tecla3)));

                else if (creator.tipo == "VOLUME" && creator.tecla != null)
                    deviceList.Add(new VolumeDevice(creator.nome, index));

                index++;
            }
            return deviceList;
        }
        */

        public static Device[] CreateDeviceList(List<DeviceCreator> creatorList)
        {
            Device[] deviceList = new Device[creatorList.Count];
 
            for (byte i = 0; i < creatorList.Count;i++)
            {
                if (creatorList[i].tipo == "COMANDO" && creatorList[i].comando != null && creatorList[i].argumento != null)
                    deviceList[i] = new CommandDevice(creatorList[i].nome, Convert.ToByte(i + 1), new ProcessStartInfo(creatorList[i].comando, creatorList[i].argumento));

                else if (creatorList[i].tipo == "TECLA" && creatorList[i].tecla != null)
                    deviceList[i] = new KeyDevice(creatorList[i].nome, Convert.ToByte(i + 1), GetEnumValue<VirtualKeyCode>(creatorList[i].tecla),
                                        GetEnumValue<VirtualKeyCode>(creatorList[i].tecla2), GetEnumValue<VirtualKeyCode>(creatorList[i].tecla3));

                else if (creatorList[i].tipo == "VOLUME" && creatorList[i].tecla != null)
                    deviceList[i] = (new VolumeDevice(creatorList[i].nome, Convert.ToByte(i + 1)));
            }
            return deviceList;
        }


        public static T GetEnumValue<T>(string str) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }
            T val = ((T[])Enum.GetValues(typeof(T)))[0];
            if (!string.IsNullOrEmpty(str))
            {
                foreach (T enumValue in (T[])Enum.GetValues(typeof(T)))
                {
                    if (enumValue.ToString().ToUpper().Equals(str.ToUpper()))
                    {
                        val = enumValue;
                        break;
                    }
                }
            }
            return val;
        }
    }
}
