namespace Skywalker.Webshop.ViewModels
{
    public class UpdateShoppingCartItemViewModel
    {
        public int ProductId { get; set; }
        public bool IsRemoved { get; set; }
        public int Quantity { get; set; }
    }
}