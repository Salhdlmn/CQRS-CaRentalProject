﻿namespace CaRentalProject.CQRS.Queries.ServiceQueries
{
    public class GetServiceByIdQuery
    {
        public int Id { get; set; }

        public GetServiceByIdQuery(int id)
        {
            Id = id;
        }
    }
}
