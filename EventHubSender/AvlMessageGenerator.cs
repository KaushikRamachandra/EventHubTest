using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHubSender
{
    public class AvlMessageGenerator
    {
        List<Tuple<string, string>> units = new List<Tuple<string, string>>();
        List<Tuple<double, double>> coordinates = new List<Tuple<double, double>>();

        public AvlMessageGenerator()
        {
            this.InitAssetInfo();
            this.InitCoordinates();
        }

        private void InitAssetInfo()
        {
            this.units.Add(new Tuple<string, string>("1N4AL2AP5CN540427", "UNIT311"));
            this.units.Add(new Tuple<string, string>("1LNHM82V57Y617903", "Unit312"));
            this.units.Add(new Tuple<string, string>("GEOTRACQADM001", "GeoQA_DM"));
            this.units.Add(new Tuple<string, string>("GEOTRACQAIRD001", "GeoQA_IRD"));
            this.units.Add(new Tuple<string, string>("CHRISPD4PTAC", "Chris-PD42"));
        }

        private void InitCoordinates()
        {
            this.coordinates.Add(new Tuple<double, double>(51.000356, -114.070442));
            this.coordinates.Add(new Tuple<double, double>(51.000565, -114.071483));
            this.coordinates.Add(new Tuple<double, double>(51.001328, -114.070120));
            this.coordinates.Add(new Tuple<double, double>(51.001314, -114.067974));
            this.coordinates.Add(new Tuple<double, double>(51.001307, -114.064562));
            this.coordinates.Add(new Tuple<double, double>(51.001354, -114.060903));
            this.coordinates.Add(new Tuple<double, double>(51.001388, -114.058907));
            this.coordinates.Add(new Tuple<double, double>(51.001388, -114.058907));
            this.coordinates.Add(new Tuple<double, double>(51.001361, -114.051244));
            this.coordinates.Add(new Tuple<double, double>(50.999842, -114.048948));
            this.coordinates.Add(new Tuple<double, double>(50.998465, -114.049506));
            this.coordinates.Add(new Tuple<double, double>(50.995210, -114.053830));
            this.coordinates.Add(new Tuple<double, double>(50.993988, -114.057692));
            this.coordinates.Add(new Tuple<double, double>(50.994305, -114.069290));
            this.coordinates.Add(new Tuple<double, double>(50.994454, -114.076221));
            this.coordinates.Add(new Tuple<double, double>(50.994704, -114.081821));
            this.coordinates.Add(new Tuple<double, double>(50.995413, -114.083044));
            this.coordinates.Add(new Tuple<double, double>(50.998914, -114.083205));
            this.coordinates.Add(new Tuple<double, double>(51.000946, -114.082347));
            this.coordinates.Add(new Tuple<double, double>(51.001378, -114.077734));
            this.coordinates.Add(new Tuple<double, double>(51.001331, -114.073990));
            this.coordinates.Add(new Tuple<double, double>(51.001324, -114.070857));
            this.coordinates.Add(new Tuple<double, double>(51.000554, -114.069612));
            this.coordinates.Add(new Tuple<double, double>(51.000049, -114.070132));
        }

        public AvlMessage Generate(int randomUnit, int randomCoordinate)
        {
            AvlMessage message = new AvlMessage();
            message.AssetSerialNumber = this.units[randomUnit].Item1;
            message.AssetUnitNumber = this.units[randomUnit].Item2;
            message.CustomerID = 1580;
            message.DutyCode = -1;
            message.Heading = 1;
            message.IsAlert = false;
            message.Latitude = this.coordinates[randomCoordinate].Item1;
            message.Longitude = this.coordinates[randomCoordinate].Item2;
            message.MessageID = Guid.NewGuid().ToString();
            message.MessageTime = DateTime.UtcNow;
            message.ModemSerialNumber = "096test9999";
            message.OdometerReading = 60000 + randomCoordinate;
            message.ReasonCodeIndex = 1;
            message.Speed = randomUnit * 10;
            
            return message;
        }
    }
}
