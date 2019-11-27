using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EventStoreResponsitory : DataHelper, IEventStoreResponsitory<EventStore>
    {
        public EventStoreResponsitory(AppDb db) : base(db)
        {
        }

        public async Task<bool> Save(EventStore eventstore)
        {
            string[] name = { "p_Id", "p_Type", "p_Content", "p_Created", "p_User" };
            object[] value = { eventstore.Id, eventstore.Type, eventstore.Content, eventstore.Created, eventstore.User };
            List<MySql.Data.MySqlClient.MySqlParameter> parameters = GetParameter(name, value);
            int rs = await ExecuteNonQueryAsync("usp_eventstore_Insert", System.Data.CommandType.StoredProcedure, parameters);
            return rs > 0;
        }
    }
}
