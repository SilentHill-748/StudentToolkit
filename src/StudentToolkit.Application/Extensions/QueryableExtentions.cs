namespace StudentToolkit.Application.Extensions;

public static class QuerableExtentions
{
    public static IQueryable<TEntity> AsTrackingWithStrategy<TEntity>(
        this IQueryable<TEntity> query,
        QueryTrackingBehavior trackingBehavior = QueryTrackingBehavior.NoTracking)
            where TEntity : class
    {
        return trackingBehavior switch
        {
            QueryTrackingBehavior.NoTracking =>
                query.AsNoTracking(),

            QueryTrackingBehavior.NoTrackingWithIdentityResolution =>
                query.AsNoTrackingWithIdentityResolution(),

            _ => query.AsTracking()
        };
    }
}
