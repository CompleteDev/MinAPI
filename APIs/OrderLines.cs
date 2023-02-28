using DataAccess.Data.OrderLines;

namespace MMSMinAPI.APIs;

public static class OrderLines
{
    public static void ConfigureOrderLineApi(this WebApplication app)
    {
        //Mapp to API's
        app.MapGet(pattern: "/OrderLine/{Id}", GetOrderLine);
        app.MapGet(pattern: "/OrderLines/{Id}", GetOrderLinesFromHeader);
    }

    private static async Task<IResult> GetOrderLinesFromHeader(int Id, IOrderLinesData data)
    {
        try 
         {
            var results = await data.GetOrderLinesFromHeaderID(Id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) 
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetOrderLine(int Id, IOrderLinesData data)
    {
        try 
        {
            var results = await data.GetOrderLine(Id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }

    }
}
