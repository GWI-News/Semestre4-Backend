namespace GwiNews.Application.DTOs
{
    public enum UserRole
    {
        Administrator = 0,
        Editor = 1,
        Author = 2,
        Reader = 3,
        Marketing = 4,
        Financial = 5
    }

    public enum NewsStatus
    {
        Published = 0,
        InRevision = 1,
        Draft = 2,
        Inactive = 3
    }
}
