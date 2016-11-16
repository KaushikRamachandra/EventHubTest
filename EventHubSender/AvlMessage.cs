using System;
using System.ComponentModel.DataAnnotations;

namespace EventHubSender
{
    /// <summary>
    /// See https://github.com/geotracsystems/avlpush-service/blob/develop/AvlPush.Tests/Fakes/StatusMessage.cs
    /// </summary>
    [Serializable]
    public class AvlMessage
    {
        [Required]
        public int DutyCode { get; set; } // 0,
        [Required]
        public int Heading { get; set; }  // 0,
        [Required]
        public bool IsAlert { get; set; }  // false,
        [Required]
        public double Latitude { get; set; }  // 9999,
        [Required]
        public double Longitude { get; set; }  // 9999,
        [Required]
        public string ModemSerialNumber { get; set; }  // 353567042020066",
        [Required]
        public long OdometerReading { get; set; }  // 29,
        /// <summary>
        /// see https://github.com/geotracsystems/avlpush-service/blob/develop/AvlPush.Tests.MessageSender/ReasonCode.cs
        /// </summary>
        [Required]
        public int ReasonCodeIndex { get; set; }  // 160190,
        [Required]
        public int Speed { get; set; }  // 0,
        [Required]
        public string MessageID { get; set; }  // "74ebb4-bb05-472f-987d-a35089f41465",
        [Required]
        public int CustomerID { get; set; }  // 1580,
        [Required]
        public string AssetUnitNumber { get; set; }  // "TEST-HOS",
        [Required]
        public string AssetSerialNumber { get; set; }  // "TESTHOSUNIT0",
        [Required]
        public DateTime MessageTime { get; set; }  // "2015-10-08T16::47.5546492Z"
    }
}
