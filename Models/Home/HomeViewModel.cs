namespace OnlineStore.Models.Home
{
    public class HomeViewModel
    {
        public IEnumerable<CarouselItemViewModel> CarouselItems { get; set; }
        public SpecialOfferViewModel? SpecialOffer { get; set;}

    }
}
