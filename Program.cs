namespace LHPets;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Projeto Web - LH Pets Versão 1");

        app.UseStaticFiles();
        app.MapGet("/index", (HttpContext contexto)=> {
            contexto.Response.Redirect("index.html", false);
});

    Banco banco = new Banco();
    app.MapGet("/listaClientes", (HttpContext context) => {
    context.Response.WriteAsync(banco.GetListaString());
});

    app.Run();

    }
}






