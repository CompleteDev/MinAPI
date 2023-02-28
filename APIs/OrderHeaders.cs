namespace MMSMinAPI.APIs;

public static class OrderHeaders
{
    public static void ConfigureOrderHeaderApi(this WebApplication app)
    {
        //Mapp to API's
        app.MapGet(pattern: "/OrderHeaders", GetOrderHeaders);
        app.MapGet(pattern: "/OrderHeader/{Id}", GetOrderHeader);
        app.MapGet(pattern: "/GetResetOrders", GetResetOrders);
        app.MapPut(pattern: "/UpdateOrderHeaderReset", UpdateOrderHeaderReset);
        app.MapGet(pattern: "/GetOrderDetails/{Id}", GetOrderDetails);
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
        try {
            var results = await data.GetOrderHeader(Id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetOrderDetails(int Id, IOrderHeaderData data)
    {
        try {
            var results = await data.GetOrderDetails(Id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> GetResetOrders(IOrderHeaderData data)
    {
        try {
            return Results.Ok(await data.GetResetOrders());
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }

    }

    private static async Task<IResult> UpdateOrderHeaderReset(OrderHeaderMDL orderHeader,IOrderHeaderData data)
    {
        try {
            await data.UpdateOrderHeaderReset(orderHeader);
            return Results.Ok(data);
        }
        catch (Exception ex) {
            return Results.Problem(ex.Message);
        }

    }
}
