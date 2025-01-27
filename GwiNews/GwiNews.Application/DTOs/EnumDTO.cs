namespace GwiNews.Application.DTOs
{
    public enum UserRoleDTO
    {
        Administrator = 0,
        Editor = 1,
        Author = 2,
        Reader = 3,
        Marketing = 4,
        Financial = 5
    }

    public enum NewsStatusDTO
    {
        Published = 0,
        InRevision = 1,
        Draft = 2,
        Inactive = 3
    }
}
