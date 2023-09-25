#nullable enable
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Domain;
using Domain.Repositories;

namespace Data.Repositories
{
    public class MapMarkerRepository : IMapMarkerRepository
    {

        private SqlConnection _sqlConnection;
        
        public bool IsConnectionOpen()
        {
            return _sqlConnection != null && _sqlConnection.State == ConnectionState.Open;
        }

        public async Task OpenAsync()
        {
            if (_globalRepositoryInstance != null)
            {
                await _globalRepositoryInstance._sqlConnection.OpenAsync();
            }
        }
        
        public void Open()
        {
            if (_globalRepositoryInstance is null)
            {
                throw new ArgumentNullException("");
            }
            _globalRepositoryInstance._sqlConnection.Open();
        }

        public void Close()
        {
            _sqlConnection.Close();
        }

        private static MapMarkerRepository? _globalRepositoryInstance;

        private MapMarkerRepository(string bdConnectionConfiguration)
        {
            _sqlConnection = new SqlConnection(bdConnectionConfiguration);
        }
        
        public static MapMarkerRepository GetInstance(string bdConnectionConfiguration)
        {
            return _globalRepositoryInstance ??= new MapMarkerRepository(bdConnectionConfiguration);
        }
        
        public void Update(MapMarker newEntity)
        {
            if (!IsConnectionOpen())
            {
                return;
            }
            using (var command = new SqlCommand(
                       "UPDATE markers SET Latitude = @Latitude, Longitude = @Longitude WHERE id = @id",
                       _sqlConnection)
                  )
            {
                command.Parameters.Add("@Latitude", SqlDbType.Float).Value = newEntity.Latitude;
                command.Parameters.Add("@Longitude", SqlDbType.Float).Value = newEntity.Longitude;
                command.Parameters.Add("@id", SqlDbType.Int).Value = newEntity.Id;

                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
        }

        public IEnumerable<MapMarker> Read()
        {
            var units = new List<MapMarker>();
            
            if (!IsConnectionOpen())
            {
                return units;
            }
            
            var command = new SqlCommand("SELECT * FROM markers", _sqlConnection);
            var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                units.Add(new MapMarker(
                    reader.GetInt32(0), 
                    reader.GetString(1),
                    reader.GetDouble(2),
                    reader.GetDouble(3))
                );
            }
            reader.Close();
            return units;
        }
    }
}