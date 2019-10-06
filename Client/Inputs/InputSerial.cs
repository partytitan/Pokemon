using Microsoft.Xna.Framework.Input;
using System;
using System.IO.Ports;

namespace Client.Inputs
{
    internal class InputSerial : Input
    {
        private static SerialPort serialPort =  new SerialPort("COM4")
        {
            BaudRate = 9600,
            Parity = Parity.None,
            StopBits = StopBits.One,
            DataBits = 8,
            Handshake = Handshake.None
        };
        private GameLogic.Common.Inputs SerialState = GameLogic.Common.Inputs.None;
        private GameLogic.Common.Inputs lastSerialState;
        private Keys lastKey;

        public InputSerial()
        {

            // Subscribe to the DataReceived event.
            InputSerial.serialPort.DataReceived += SerialPortDataReceived;

            if (!InputSerial.serialPort.IsOpen)
            {
                InputSerial.serialPort.Open();
            }
            // Now open the port.
        }
        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = (SerialPort)sender;

            // Read the data that's in the serial buffer.
            var serialdata = serialPort.ReadLine();
            serialdata = serialdata.Remove(serialdata.Length - 1);
            Enum.TryParse(serialdata, out SerialState);

        }
        protected override void CheckInput(double gameTime)
        {
            if (SerialState == lastSerialState && lastKey != Keys.None)
            {
                SendNewInput(GameLogic.Common.Inputs.None);
            }

            CheckKeyState(Keys.Left, GameLogic.Common.Inputs.Left);
            CheckKeyState(Keys.Up, GameLogic.Common.Inputs.Up);
            CheckKeyState(Keys.Right, GameLogic.Common.Inputs.Right);
            CheckKeyState(Keys.Down, GameLogic.Common.Inputs.Down);
            CheckKeyState(Keys.A, GameLogic.Common.Inputs.A);

            lastSerialState = SerialState;
        }

        private void CheckKeyState(Keys key, GameLogic.Common.Inputs sendInput)
        {
            if (lastSerialState == sendInput)
            {
                SendNewInput(sendInput);
                lastKey = key;
            }
        }
    }
}