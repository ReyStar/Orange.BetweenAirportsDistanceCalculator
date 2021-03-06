﻿namespace Orange.AirportToAirportDistanceCalculator.Domain.Models
{
    /// <summary>
    /// Geo coordinate
    /// </summary>
    public struct GeoCoordinate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeoCoordinate"/> struct.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public GeoCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public double Longitude { get; set; }
    }
}
