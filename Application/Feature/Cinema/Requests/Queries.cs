namespace Application.Queries
{
    public class GetCinemaByIdQuery
    {
        public int Id { get; }

        public GetCinemaByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetCinemasByIdQuery
    {
        public int Id { get; }

        public GetCinemasByIdQuery(int id)
        {
            Id = id;
        }
    }

}
