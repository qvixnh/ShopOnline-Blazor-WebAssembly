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
        public async Task<List<CartItemDto>> GetCollection()
        {
            return await this.localStorageService.GetItemAsync<List<CartItemDto>>(key)
                ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await localStorageService.RemoveItemAsync(key);
        }
        public async Task SaveCollection(List<CartItemDto> cartItemDtos)
        {
            await localStorageService.SetItemAsync(key,cartItemDtos); 
        }

        private async Task<List<CartItemDto>> AddCollection()
        {
            var shoppingCartCollection = await shoppingCartService.GetItems(HardCoded.UserId);
            if (shoppingCartCollection != null)
            {

                await this.localStorageService.SetItemAsync(key, shoppingCartCollection);

            }
            return shoppingCartCollection;
        }
    }
}
