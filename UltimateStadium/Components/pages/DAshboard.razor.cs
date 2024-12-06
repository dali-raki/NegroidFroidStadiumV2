using Microsoft.AspNetCore.Components;
using UltimateStadium.Services;

namespace UltimateStadium.Components.Pages
{
    public partial class Dashboard : ComponentBase
    {
        [Inject] public IDashBoardService DashBoard { get; set; } = default!;

        protected int managerCount = 0;
        protected int usersCount = 0;
        protected int stadiumsCount = 0;

        protected override async Task OnInitializedAsync()
        {
            managerCount = await DashBoard.getManagersCount();
            usersCount = await DashBoard.getUsersCount();
            stadiumsCount = await DashBoard.getStadiumsCount();
        }
    }
}