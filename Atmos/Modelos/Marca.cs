namespace Atmos.Modelos
{
    public class Marca
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        //Propiedad de navegacion EF
        virtual public ICollection<Producto>? Productos { get; set; }
    }
}
