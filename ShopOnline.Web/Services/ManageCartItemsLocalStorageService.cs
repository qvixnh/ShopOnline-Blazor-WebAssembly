using Blazored.LocalStorage;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Services
{
    public class ManageCartItemsLocalStorageService : IManageCartItemsLocalStorageService
    {
        private readonly ILocalStorageService localStorageService;
        private readonly IShoppingCartService shoppingCartService;
        private const string key = "ManageCartItemsCollection";


        public ManageCartItemsLocalStorageService(ILocalStorageService localStorageService, IShoppingCartService shoppingCartService)
        {
            this.localStorageService = localStorageService;
            this.shoppingCartService = shoppingCartService;
        }
        public Task<List<CartItemDto>> GetCollection()
        {
            return await this.localStorageService.GetItemAsync<IEnumerable<ProductDto>>(key)
                ?? await AddCollection();
        }

        public Task RemoveCollection()
        {
            throw new NotImplementedException();
        }
        public Task SaveCollection(List<CartItemDto> cartItemDtos)
        {
            throw new NotImplementedException();
        }

        private async Task<List<CartItemDto>> AddCollection()
        {
            var shoppingCartCollection = await shoppingCartService.GetItems(HardCoded.UserId);

        }
    }
}
