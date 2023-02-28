namespace NonDockerMinAPI;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        //Mapp to API's
        app.MapGet(pattern: "/OrderHeaders", GetOrderHeaders);
        app.MapGet(pattern: "/OrderHeader/{Id}", GetOrderHeader);
    }

    private static async Task<IResult> GetOrderHeaders(IOrderHeaderData data)
    {
        try 
        {
            return Results.Ok(await data.GetOrderHeaders());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetOrderHeader(int Id, IOrderHeaderData data)
    {
        try 
        {
            var results = await data.GetOrderHeader(Id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) 
        {
            return Results.Problem(ex.Message);
        }

    }
}
