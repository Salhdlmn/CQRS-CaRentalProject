﻿namespace CaRentalProject.CQRS.Results.EmployeeResults
{
    public class GetEmployeeQueryResult
    {

        public int EmployeeId { get; set; }
        public string NameSurname { get; set; }
        public string Profession { get; set; }
        public string ImageUrl { get; set; }
    }
}
