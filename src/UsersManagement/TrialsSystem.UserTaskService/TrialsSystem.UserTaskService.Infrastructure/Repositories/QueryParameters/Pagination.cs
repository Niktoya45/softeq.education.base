namespace TrialsSystem.UserTaskService.Infrastructure.Repositories.QueryParameters
{
    public record Pagination(int? Skip=0, int? Take=null)
    {
        static int _maxScope = 20;
        public int? Skip { get; init; } = Skip??0;

        public int? Take { get; init; } = Take??(Take > _maxScope ? _maxScope : Take);

    }
}
