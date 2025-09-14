namespace CaRentalProject.CQRS.Queries.EmployeeQueries
{
    public class GetEmployeeByIdQuery
    {

        public int Id { get; set; }

        public GetEmployeeByIdQuery(int id)
        {
            Id = id;
        }

    }
}
