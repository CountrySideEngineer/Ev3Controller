using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Ev3Controller.ViewModel
{
    using Model;
    using System.IO.Ports;

    public class ComPortViewModel
    {
        #region Public read-only static fields
        public static ComPortViewModel Create(string name, string device)
        {
            return new ComPortViewModel(new ComPort(name, device));
        }

        /// <summary>
        /// Create list of available COM port.
        /// </summary>
        /// <returns>List of available COM port.</returns>
        public static IEnumerable<ComPortViewModel> Create()
        {
            var deviceNameList = new System.Collections.ArrayList();
            var check = new System.Text.RegularExpressions.Regex("(COM[1-9][0-9]?[0-9]?)");

            ManagementClass mcPnPEntity = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection manageObjCol = mcPnPEntity.GetInstances();
            string[] ports = SerialPort.GetPortNames();
            foreach (ManagementObject manageObj in manageObjCol)
            {
                var namePropertyValue = manageObj.GetPropertyValue("Name");
                if (null == namePropertyValue)
                {
                    continue;
                }
                string name = namePropertyValue.ToString();
                /*
                 * Create the port data from the port name obraninted in advance matches
                 * with that of device.
                 */
                foreach (string portName in ports)
                {
                    if (check.IsMatch(name) && name.Contains(portName))
                    {
                        yield return Create(portName, name);
                    }
                }
            }
        }
        #endregion

        #region Constructors and the Finalizer
        /// <summary>
        /// Constructor.
        /// The COM port is specified by argument, ComPort object.
        /// </summary>
        /// <param name="ComPort">ComPort object.</param>
        public ComPortViewModel(ComPort ComPort)
        {
            this.ComPort = ComPort;
            this.PortName = this.ComPort.Name;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Serial COM port object.
        /// </summary>
        public ComPort ComPort { get; protected set; }

        /// <summary>
        /// Serial port name.
        /// </summary>
        public string PortName { get; protected set; }
        #endregion

        #region Other methods and private properties in calling order
        /// <summary>
        /// Compare ComPortViewModel object specified by argument with self. 
        /// </summary>
        /// <param name="ViewModel">ViewModel object to compare.</param>
        /// <returns>If matches, returns true, otherwise returns false.</returns>
        public bool Equals(ComPortViewModel ViewModel)
        {
            try
            {
                if (this.ComPort.Equals(ViewModel.ComPort) &&
                    this.PortName.Equals(ViewModel.PortName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion
    }
}
