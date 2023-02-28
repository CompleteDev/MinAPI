using DataAccess.Data.Velociti;

namespace MMSMinAPI.APIs;

public static class Velociti
{
    public static void ConfigureVelocitApi(this WebApplication app)
    {
        //Mapp to API's
        app.MapGet(pattern: "/GetRoutFileInfo/{Id}", GetRoutFileInfo);
    }

    private static async Task<IResult> GetRoutFileInfo(int Id, IRouteFileData data)
    {
        try {
            var results = await data.GetRoutFileInfo(Id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }

    }
}
