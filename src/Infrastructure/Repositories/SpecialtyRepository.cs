using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinAgenda.src.Application.DTOs.Specialty;
using Dapper;
using MySql.Data.MySqlClient;

namespace ClinAgenda.src.Infrastructure.Repositories
{
    public class SpecialtyRepository
    {
        private readonly MySqlConnection _connection;

        public SpecialtyRepository(MySqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<SpecialtyDTO> GetByIdAsync(int id)
        {
            const string query = @"
                SELECT 
                    ID, 
                    NAME,
                    SCHEDULEDURATION 
                FROM SPECIALTY
                WHERE ID = @Id";

            var specialty = await _connection.QueryFirstOrDefaultAsync<SpecialtyDTO>(query, new { Id = id });

            return specialty;
        }

    }

}